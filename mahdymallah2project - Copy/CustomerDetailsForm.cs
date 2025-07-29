using System;
using System.Windows.Forms;

namespace mahdymallah2project
{
    public partial class CustomerDetailsForm : Form
    {
        public string CustomerName { get; private set; }
        public string DeliveryAddress { get; private set; }

        public CustomerDetailsForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            CustomerName = txtName.Text.Trim();
            DeliveryAddress = txtAddress.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your name.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter delivery address.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}