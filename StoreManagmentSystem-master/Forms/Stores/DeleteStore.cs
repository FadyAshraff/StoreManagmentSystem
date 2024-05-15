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

namespace StoreManagmentSystem.Forms.Stores
{
    public partial class DeleteStore : Form
    {
        StoreDb db = new StoreDb();
        Assistant assisstant = new Assistant();
        public DeleteStore()
        {
            InitializeComponent();
            assisstant.FillCb<Store>(comboBox1, "Name", "ID", db.GetAllStores());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;

            int id = int.Parse(comboBox1.SelectedValue.ToString());
            Store store = db.GetStoreById(id);

            textBox1.Text = store.ID.ToString();
            textBox2.Text = store.Name;
            textBox3.Text = store.Address;
            textBox4.Text = store.Responsible_Employee;
            groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Deleting This Store ?", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    db.DeleteStoreById(int.Parse(textBox1.Text));
                    MessageBox.Show("Store Deleted Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("something went wrong");
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                groupBox2.Visible = false;
            }
        }
        private void RefreshCb_AllStores()
        {
            assisstant.ClearForm(groupBox2);
            textBox1.Text = "";
            comboBox1.DataSource = null;
            assisstant.FillCb<Store>(comboBox1, "Name", "ID", db.GetAllStores());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RefreshCb_AllStores();
        }
    }
}
