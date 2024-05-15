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
    public partial class DeleteVendor : Form
    {
        VendorDb db = new VendorDb();
        Assistant assisstant = new Assistant();
        public DeleteVendor()
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
            DialogResult dialogResult = MessageBox.Show("Are You Sure Deleting This Vendor ?", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    db.DeleteVendorById(int.Parse(textBox1.Text));
                    MessageBox.Show("Vendor Deleted Successfully");
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
        private void RefreshCb_AllVendors()
        {
            assisstant.ClearForm(groupBox2);
            textBox1.Text = "";
            comboBox1.Items.Clear();
            comboBox2.DataSource = null;
            assisstant.SettingCbFromLabelsText(groupBox2, comboBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshCb_AllVendors();
        }
    }
}
