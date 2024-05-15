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
    public partial class EditStore : Form
    {
        StoreDb db = new StoreDb();
        Assistant assisstant = new Assistant();
        public EditStore()
        {
            InitializeComponent();
            assisstant.FillCb<Store>(comboBox1, "Name", "ID", db.GetAllStores());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int id = int.Parse(comboBox1.SelectedValue.ToString());
            Store store = db.GetStoreById(id);

            textBox1.Text = store.ID.ToString();
            textBox2.Text = store.Name;
            textBox3.Text = store.Address;
            textBox4.Text = store.Responsible_Employee;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox2))
            {
                Store newStore = new Store
                {
                    ID = int.Parse(textBox1.Text),
                    Name = textBox2.Text,
                    Address = textBox3.Text,
                    Responsible_Employee = textBox4.Text
                };

                try
                {
                    db.EditStore(newStore);
                    MessageBox.Show("Store Updated Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong try again");
                }
            }
            else
            {
                MessageBox.Show("All fields are required to edit");
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
