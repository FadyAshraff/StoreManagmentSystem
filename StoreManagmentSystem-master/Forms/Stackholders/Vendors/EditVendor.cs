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
    public partial class EditVendor : Form
    {
        VendorDb db = new VendorDb();
        Assistant assisstant = new Assistant();
        public EditVendor()
        {
            InitializeComponent();
            assisstant.SettingCbFromLabelsText(groupBox2, comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();

            label2.Text = "Vendor " + filter;

            List<Vendor> vendors = db.GetAllVedors();

            assisstant.FillCb<Vendor>(comboBox2, filter, "ID", vendors);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vendor vendor = db.GetVendorById(int.Parse(comboBox2.SelectedValue.ToString()));

            textBox1.Text = vendor.ID.ToString();
            textBox2.Text = vendor.Name;
            textBox3.Text = vendor.Mobile;
            textBox4.Text = vendor.Email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox2))
            {
                Vendor vendor = new Vendor
                {
                    ID = int.Parse(textBox1.Text),
                    Name = textBox2.Text,
                    Mobile = textBox3.Text,
                    Email = textBox4.Text,
                };

                try
                {
                    db.EditVendor(vendor);
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
