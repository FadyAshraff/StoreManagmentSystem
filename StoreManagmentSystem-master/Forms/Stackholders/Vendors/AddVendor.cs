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

namespace StoreManagmentSystem.Forms.Stackholders.Vendors
{
    public partial class AddVendor : Form
    {
        VendorDb db = new VendorDb();
        Assistant assisstant = new Assistant();
        public AddVendor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox1))
            {
                Vendor vendor = new Vendor
                {
                    Name = textBox1.Text,
                    Mobile = textBox2.Text,
                    Email = textBox3.Text,
                };

                try
                {
                    db.AddVendor(vendor);
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
