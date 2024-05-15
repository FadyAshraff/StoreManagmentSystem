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
    public partial class EditCustomer : Form
    {
        CustomerDb db = new CustomerDb();
        Assistant assisstant = new Assistant();
        public EditCustomer()
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
            if (!assisstant.CheckIfFormIsEmpty(groupBox2))
            {
                StoreManagmentSystem.Customer cst = new StoreManagmentSystem.Customer
                {
                    ID = int.Parse(textBox1.Text),
                    Name = textBox2.Text,
                    Mobile = textBox3.Text,
                    Email = textBox4.Text,
                };

                try
                {
                    db.EditCustomer(cst);
                    MessageBox.Show("Customer Updated Successfully");

                }
                catch (Exception)
                {
                    MessageBox.Show("Something Went Wrong");
                }
            }
            else
            {
                MessageBox.Show("All fields are required to update");
            }
        }

        private void RefreshAll()
        {
            assisstant.ClearForm(groupBox2);
            comboBox2.DataSource = null;
            comboBox1.Items.Clear();
            textBox1.Text = "";
            assisstant.SettingCbFromLabelsText(groupBox2, comboBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }
    }
}
