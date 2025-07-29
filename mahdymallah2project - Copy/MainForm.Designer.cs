namespace mahdymallah2project
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.orderItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Burgers = new System.Windows.Forms.TabPage();
            this.listBoxBurgers = new System.Windows.Forms.ListBox();
            this.Sides = new System.Windows.Forms.TabPage();
            this.listBoxSides = new System.Windows.Forms.ListBox();
            this.Drinks = new System.Windows.Forms.TabPage();
            this.listBoxDrinks = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsDataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Burgers.SuspendLayout();
            this.Sides.SuspendLayout();
            this.Drinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(467, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 45);
            this.label1.TabIndex = 15;
            this.label1.Text = "Burger Palace - Order ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.BackColor = System.Drawing.Color.White;
            this.btnViewOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrders.Location = new System.Drawing.Point(993, 474);
            this.btnViewOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(238, 47);
            this.btnViewOrders.TabIndex = 14;
            this.btnViewOrders.Text = "View Orders";
            this.btnViewOrders.UseVisualStyleBackColor = false;
            this.btnViewOrders.Click += new System.EventHandler(this.btnViewOrders_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackColor = System.Drawing.Color.PaleGreen;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPlaceOrder.Location = new System.Drawing.Point(993, 388);
            this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(238, 78);
            this.btnPlaceOrder.TabIndex = 13;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.AutoSize = true;
            this.lblOrderTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderTotal.Font = new System.Drawing.Font("Segoe UI Variable Text", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.ForeColor = System.Drawing.Color.White;
            this.lblOrderTotal.Location = new System.Drawing.Point(990, 326);
            this.lblOrderTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(248, 58);
            this.lblOrderTotal.TabIndex = 12;
            this.lblOrderTotal.Text = "total label ";
            // 
            // orderItemsDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.orderItemsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.orderItemsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderItemsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.orderItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderItemsDataGridView.GridColor = System.Drawing.Color.LightGray;
            this.orderItemsDataGridView.Location = new System.Drawing.Point(521, 128);
            this.orderItemsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.orderItemsDataGridView.Name = "orderItemsDataGridView";
            this.orderItemsDataGridView.RowHeadersWidth = 62;
            this.orderItemsDataGridView.RowTemplate.Height = 28;
            this.orderItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderItemsDataGridView.Size = new System.Drawing.Size(710, 188);
            this.orderItemsDataGridView.TabIndex = 11;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRemoveItem.Location = new System.Drawing.Point(718, 324);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(182, 60);
            this.btnRemoveItem.TabIndex = 10;
            this.btnRemoveItem.Text = " Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.BackColor = System.Drawing.Color.Lavender;
            this.btnAddToOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddToOrder.Location = new System.Drawing.Point(521, 324);
            this.btnAddToOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(184, 60);
            this.btnAddToOrder.TabIndex = 9;
            this.btnAddToOrder.Text = "Add to Order";
            this.btnAddToOrder.UseVisualStyleBackColor = false;
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.Burgers);
            this.tabControl1.Controls.Add(this.Sides);
            this.tabControl1.Controls.Add(this.Drinks);
            this.tabControl1.Location = new System.Drawing.Point(38, 96);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 415);
            this.tabControl1.TabIndex = 8;
            // 
            // Burgers
            // 
            this.Burgers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Burgers.BackgroundImage")));
            this.Burgers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Burgers.Controls.Add(this.listBoxBurgers);
            this.Burgers.Location = new System.Drawing.Point(4, 32);
            this.Burgers.Margin = new System.Windows.Forms.Padding(4);
            this.Burgers.Name = "Burgers";
            this.Burgers.Padding = new System.Windows.Forms.Padding(4);
            this.Burgers.Size = new System.Drawing.Size(457, 379);
            this.Burgers.TabIndex = 0;
            this.Burgers.Text = "Burgers";
            this.Burgers.UseVisualStyleBackColor = true;
            // 
            // listBoxBurgers
            // 
            this.listBoxBurgers.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxBurgers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxBurgers.FormattingEnabled = true;
            this.listBoxBurgers.ItemHeight = 20;
            this.listBoxBurgers.Location = new System.Drawing.Point(22, 21);
            this.listBoxBurgers.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxBurgers.Name = "listBoxBurgers";
            this.listBoxBurgers.Size = new System.Drawing.Size(398, 160);
            this.listBoxBurgers.TabIndex = 0;
            // 
            // Sides
            // 
            this.Sides.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sides.BackgroundImage")));
            this.Sides.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sides.Controls.Add(this.listBoxSides);
            this.Sides.Location = new System.Drawing.Point(4, 32);
            this.Sides.Margin = new System.Windows.Forms.Padding(4);
            this.Sides.Name = "Sides";
            this.Sides.Padding = new System.Windows.Forms.Padding(4);
            this.Sides.Size = new System.Drawing.Size(457, 379);
            this.Sides.TabIndex = 1;
            this.Sides.Text = "Sides";
            this.Sides.UseVisualStyleBackColor = true;
            // 
            // listBoxSides
            // 
            this.listBoxSides.FormattingEnabled = true;
            this.listBoxSides.ItemHeight = 20;
            this.listBoxSides.Location = new System.Drawing.Point(33, 24);
            this.listBoxSides.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxSides.Name = "listBoxSides";
            this.listBoxSides.Size = new System.Drawing.Size(384, 144);
            this.listBoxSides.TabIndex = 0;
            // 
            // Drinks
            // 
            this.Drinks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Drinks.BackgroundImage")));
            this.Drinks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Drinks.Controls.Add(this.listBoxDrinks);
            this.Drinks.Location = new System.Drawing.Point(4, 32);
            this.Drinks.Margin = new System.Windows.Forms.Padding(4);
            this.Drinks.Name = "Drinks";
            this.Drinks.Padding = new System.Windows.Forms.Padding(4);
            this.Drinks.Size = new System.Drawing.Size(457, 379);
            this.Drinks.TabIndex = 2;
            this.Drinks.Text = "Drinks";
            this.Drinks.UseVisualStyleBackColor = true;
            // 
            // listBoxDrinks
            // 
            this.listBoxDrinks.FormattingEnabled = true;
            this.listBoxDrinks.ItemHeight = 20;
            this.listBoxDrinks.Location = new System.Drawing.Point(26, 31);
            this.listBoxDrinks.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxDrinks.Name = "listBoxDrinks";
            this.listBoxDrinks.Size = new System.Drawing.Size(393, 124);
            this.listBoxDrinks.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1303, 632);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewOrders);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.orderItemsDataGridView);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddToOrder);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Burger Place ";
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsDataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Burgers.ResumeLayout(false);
            this.Sides.ResumeLayout(false);
            this.Drinks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.DataGridView orderItemsDataGridView;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Burgers;
        private System.Windows.Forms.ListBox listBoxBurgers;
        private System.Windows.Forms.TabPage Sides;
        private System.Windows.Forms.ListBox listBoxSides;
        private System.Windows.Forms.TabPage Drinks;
        private System.Windows.Forms.ListBox listBoxDrinks;
    }
}

