using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace mahdymallah2project
{
    public partial class MainForm : Form
    {
        private SqlConnection connection;
        private List<Product> products;
        private List<OrderItem> currentOrderItems;

        public MainForm()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BurgerPalaceDB"].ConnectionString);
            products = new List<Product>();
            currentOrderItems = new List<OrderItem>();
            SetupControls();
            LoadProductsFromDB();
        }

        private void SetupControls()
        {
            tabControl1.SelectedIndex = 0;
            SetupOrderGrid();
            UpdateOrderTotal();
        }

        private void LoadProductsFromDB()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
                SqlDataReader reader = command.ExecuteReader();

                products.Clear();
                while (reader.Read())
                {
                    Product product = null;
                    string type = reader["Type"].ToString();

                    switch (type)
                    {
                        case "Burger":
                            product = new Burger
                            {
                                Id = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Description = reader["Description"].ToString(),
                                HasCheese = Convert.ToBoolean(reader["HasCheese"]),
                                PattyType = reader["PattyType"].ToString()
                            };
                            break;
                        case "Side":
                            product = new Side
                            {
                                Id = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Description = reader["Description"].ToString(),
                                Size = reader["Size"].ToString()
                            };
                            break;
                        case "Drink":
                            product = new Drink
                            {
                                Id = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Description = reader["Description"].ToString(),
                                Size = reader["Size"].ToString(),
                                IsDiet = Convert.ToBoolean(reader["IsDiet"])
                            };
                            break;
                    }

                    if (product != null) products.Add(product);
                }

                LoadProductsByCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadProductsByCategory()
        {
            listBoxBurgers.Items.Clear();
            listBoxSides.Items.Clear();
            listBoxDrinks.Items.Clear();

            foreach (var burger in products.OfType<Burger>().OrderBy(b => b.Name))
                listBoxBurgers.Items.Add(burger);

            foreach (var side in products.OfType<Side>().OrderBy(s => s.Name))
                listBoxSides.Items.Add(side);

            foreach (var drink in products.OfType<Drink>().OrderBy(d => d.Name))
                listBoxDrinks.Items.Add(drink);
        }

        private void SetupOrderGrid()
        {
            orderItemsDataGridView.AutoGenerateColumns = false;
            orderItemsDataGridView.Columns.Clear();
            orderItemsDataGridView.Columns.Add("ProductName", "Product");
            orderItemsDataGridView.Columns.Add("Quantity", "Qty");
            orderItemsDataGridView.Columns.Add("Price", "Price");
            orderItemsDataGridView.Columns.Add("TotalPrice", "Total");
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            ListBox selectedListBox = GetSelectedListBox();
            if (selectedListBox?.SelectedItem == null)
            {
                MessageBox.Show("Please select an item first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedProduct = (Product)selectedListBox.SelectedItem;
            AddProductToOrder(selectedProduct);
        }

        private ListBox GetSelectedListBox()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: return listBoxBurgers;
                case 1: return listBoxSides;
                case 2: return listBoxDrinks;
                default: return null;
            }
        }

        private void AddProductToOrder(Product product)
        {
            var existingItem = currentOrderItems.FirstOrDefault(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                currentOrderItems.Add(new OrderItem
                {
                    Product = product,
                    Quantity = 1,
                    SpecialInstructions = ""
                });
            }

            RefreshOrderGrid();
            UpdateOrderTotal();
        }

        private void RefreshOrderGrid()
        {
            orderItemsDataGridView.Rows.Clear();
            foreach (var item in currentOrderItems)
            {
                orderItemsDataGridView.Rows.Add(
                    item.Product.Name,
                    item.Quantity,
                    item.Product.Price.ToString("C"),
                    item.TotalPrice.ToString("C")
                );
            }
        }

        private void UpdateOrderTotal()
        {
            decimal total = currentOrderItems.Sum(item => item.TotalPrice);
            lblOrderTotal.Text = $"Total: {total:C}";
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (orderItemsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = orderItemsDataGridView.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= currentOrderItems.Count) return;

            var itemToRemove = currentOrderItems[selectedIndex];

            if (itemToRemove.Quantity > 1)
            {
                itemToRemove.Quantity--;
            }
            else
            {
                currentOrderItems.RemoveAt(selectedIndex);
            }

            RefreshOrderGrid();
            UpdateOrderTotal();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (currentOrderItems.Count == 0)
            {
                MessageBox.Show("Your order is empty. Please add items first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var customerForm = new CustomerDetailsForm())
            {
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        connection.Open();

                        // Start transaction
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Insert order
                            string insertOrderQuery = @"INSERT INTO Orders (CustomerName, DeliveryAddress, OrderDate, IsCompleted) 
                                                     VALUES (@CustomerName, @DeliveryAddress, @OrderDate, @IsCompleted);
                                                     SELECT SCOPE_IDENTITY();";

                            SqlCommand orderCommand = new SqlCommand(insertOrderQuery, connection, transaction);
                            orderCommand.Parameters.AddWithValue("@CustomerName", customerForm.CustomerName);
                            orderCommand.Parameters.AddWithValue("@DeliveryAddress", customerForm.DeliveryAddress);
                            orderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                            orderCommand.Parameters.AddWithValue("@IsCompleted", false);

                            int orderId = Convert.ToInt32(orderCommand.ExecuteScalar());

                            // Insert order items
                            foreach (var item in currentOrderItems)
                            {
                                string insertItemQuery = @"INSERT INTO OrderItems (OrderID, ProductID, Quantity, SpecialInstructions)
                                                         VALUES (@OrderID, @ProductID, @Quantity, @SpecialInstructions)";

                                SqlCommand itemCommand = new SqlCommand(insertItemQuery, connection, transaction);
                                itemCommand.Parameters.AddWithValue("@OrderID", orderId);
                                itemCommand.Parameters.AddWithValue("@ProductID", item.Product.Id);
                                itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                                itemCommand.Parameters.AddWithValue("@SpecialInstructions", item.SpecialInstructions ?? "");
                                itemCommand.ExecuteNonQuery();
                            }

                            // Commit transaction
                            transaction.Commit();

                            currentOrderItems.Clear();
                            RefreshOrderGrid();
                            UpdateOrderTotal();

                            MessageBox.Show($"Order #{orderId} placed successfully!", "Order Confirmation",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving order: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            List<Order> orders = new List<Order>();

            try
            {
                connection.Open();
                string query = @"SELECT o.OrderID, o.CustomerName, o.DeliveryAddress, o.OrderDate, o.IsCompleted,
                                p.ProductID, p.Name, p.Price, p.Description, p.Type, 
                                p.HasCheese, p.PattyType, p.Size, p.IsDiet,
                                oi.Quantity, oi.SpecialInstructions
                                FROM Orders o
                                JOIN OrderItems oi ON o.OrderID = oi.OrderID
                                JOIN Products p ON oi.ProductID = p.ProductID
                                ORDER BY o.OrderDate DESC";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int orderId = Convert.ToInt32(reader["OrderID"]);
                    Order order = orders.FirstOrDefault(o => o.OrderId == orderId);

                    if (order == null)
                    {
                        order = new Order
                        {
                            OrderId = orderId,
                            CustomerName = reader["CustomerName"].ToString(),
                            DeliveryAddress = reader["DeliveryAddress"].ToString(),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            IsCompleted = Convert.ToBoolean(reader["IsCompleted"]),
                            Items = new List<OrderItem>()
                        };
                        orders.Add(order);
                    }

                    Product product = CreateProductFromReader(reader);
                    if (product != null)
                    {
                        order.Items.Add(new OrderItem
                        {
                            Product = product,
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            SpecialInstructions = reader["SpecialInstructions"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            using (var ordersForm = new OrdersForm(orders))
            {
                ordersForm.ShowDialog();
            }
        }

        private Product CreateProductFromReader(SqlDataReader reader)
        {
            string type = reader["Type"].ToString();
            switch (type)
            {
                case "Burger":
                    return new Burger
                    {
                        Id = Convert.ToInt32(reader["ProductID"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Description = reader["Description"].ToString(),
                        HasCheese = Convert.ToBoolean(reader["HasCheese"]),
                        PattyType = reader["PattyType"].ToString()
                    };
                case "Side":
                    return new Side
                    {
                        Id = Convert.ToInt32(reader["ProductID"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Description = reader["Description"].ToString(),
                        Size = reader["Size"].ToString()
                    };
                case "Drink":
                    return new Drink
                    {
                        Id = Convert.ToInt32(reader["ProductID"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Description = reader["Description"].ToString(),
                        Size = reader["Size"].ToString(),
                        IsDiet = Convert.ToBoolean(reader["IsDiet"])
                    };
                default:
                    return null;
            }
        }
    }
}