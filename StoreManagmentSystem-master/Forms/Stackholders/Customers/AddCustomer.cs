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
    public partial class AddCustomer : Form
    {
        CustomerDb db = new CustomerDb();
        Assistant assisstant = new Assistant();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox1))
            {
                StoreManagmentSystem.Customer cst = new StoreManagmentSystem.Customer
                {
                    Name = textBox1.Text,
                    Mobile = textBox2.Text,
                    Email = textBox3.Text,
                };

                try
                {
                    db.AddCustomer(cst);
                    MessageBox.Show("Customer Added Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something Went Wrong");
                }

            }
            else
            {
                MessageBox.Show("All fields are requires");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assisstant.ClearForm(groupBox1);
        }
    }
}
