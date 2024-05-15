using StoreManagmentSystem.AssistanatClasses;
using StoreManagmentSystem.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManagmentSystem.Forms.Stackholders.Customers
{
    public partial class DeleteCustomer : Form
    {
        CustomerDb db = new CustomerDb();
        Assistant assisstant = new Assistant();
        public DeleteCustomer()
        {
            InitializeComponent();
            assisstant.SettingCbFromLabelsText(groupBox2, comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();

            label2.Text = "Customer " + filter;

            List<StoreManagmentSystem.Customer> customers = db.GetAllCustomers();

            assisstant.FillCb<StoreManagmentSystem.Customer>(comboBox2, filter, "ID", customers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreManagmentSystem.Customer cst = db.GetCustomerById(int.Parse(comboBox2.SelectedValue.ToString()));

            textBox1.Text = cst.ID.ToString();
            textBox2.Text = cst.Name;
            textBox3.Text = cst.Mobile;
            textBox4.Text = cst.Email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Deleting This Customer ?", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    db.DeleteCustomerById(int.Parse(textBox1.Text));
                    MessageBox.Show("Customer Deleted Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong try again");
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                groupBox2.Visible = false;
            }
        }
        private void RefreshCb_AllCustomers()
        {
            assisstant.ClearForm(groupBox2);
            textBox1.Text = "";
            comboBox1.Items.Clear();
            comboBox2.DataSource = null;
            assisstant.SettingCbFromLabelsText(groupBox2, comboBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshCb_AllCustomers();
        }
    }
}
