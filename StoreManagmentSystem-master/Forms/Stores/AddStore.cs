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
    public partial class AddStore : Form
    {
        StoreDb db = new StoreDb();
        Assistant assisstant = new Assistant();

        public AddStore()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox1))
            {
                Store store = new Store
                {
                    Name = textBox1.Text,
                    Address = textBox2.Text,
                    Responsible_Employee = textBox3.Text
                };

                try
                {
                    db.AddStore(store);
                    MessageBox.Show("Store Is Added Successfully");
                    //assisstant.ClearForm(groupBox1);
                }
                catch (Exception)
                {
                    MessageBox.Show("Data Is Incorrect");
                }
            }
            else
            {
                MessageBox.Show("Fill All Data!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assisstant.ClearForm(groupBox1);
        }
    }
}
