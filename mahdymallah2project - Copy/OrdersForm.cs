using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace mahdymallah2project
{
    public partial class OrdersForm : Form
    {
        private SqlConnection connection;
        private List<Order> orders;

        public OrdersForm(List<Order> orders)
        {
            InitializeComponent();
            this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BurgerPalaceDB"].ConnectionString);
            this.orders = orders;
            SetupDataGridView();
            LoadOrders();
        }

        private void SetupDataGridView()
        {
            ordersDataGridView.AutoGenerateColumns = false;
            ordersDataGridView.Columns.Clear();

            ordersDataGridView.Columns.Add("OrderId", "Order #");
            ordersDataGridView.Columns.Add("OrderDate", "Date");
            ordersDataGridView.Columns.Add("CustomerName", "Customer");
            ordersDataGridView.Columns.Add("TotalAmount", "Total");
            ordersDataGridView.Columns.Add("Status", "Status");
        }

        private void LoadOrders()
        {
            ordersDataGridView.Rows.Clear();
            foreach (var order in orders.OrderByDescending(o => o.OrderDate))
            {
                ordersDataGridView.Rows.Add(
                    order.OrderId,
                    order.OrderDate.ToString("g"),
                    order.CustomerName,
                    order.TotalAmount.ToString("C"),
                    order.IsCompleted ? "Completed" : "Pending"
                );
            }
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (ordersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order first.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int orderId = (int)ordersDataGridView.SelectedRows[0].Cells[0].Value;
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order != null && !order.IsCompleted)
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Orders SET IsCompleted = 1 WHERE OrderID = @OrderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.ExecuteNonQuery();

                    order.IsCompleted = true;
                    LoadOrders();

                    MessageBox.Show($"Order #{orderId} marked as completed.", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order: " + ex.Message, "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}