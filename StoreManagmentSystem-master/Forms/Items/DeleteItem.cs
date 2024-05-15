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

namespace StoreManagmentSystem.Forms.Items
{
    public partial class DeleteItem : Form
    {
        ItemDb db = new ItemDb();
        MeasureDb measureDb = new MeasureDb();
        Assistant assisstant = new Assistant();
        public DeleteItem()
        {
            InitializeComponent();
            assisstant.FillCb<Item>(comboBox1, "Name", "ID", db.GetAllItems());
            assisstant.FillCb<Measure>(comboBox2, "Main_Measure", "ID", measureDb.GetAllMeasures());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item item = db.GetItemById(int.Parse(comboBox1.SelectedValue.ToString()));
            Measure measure = measureDb.GetMeasureById(int.Parse(comboBox2.SelectedValue.ToString()));

            textBox1.Text = item.ID.ToString();
            textBox2.Text = item.Name;
            textBox3.Text = item.Code;
            comboBox2.SelectedValue = item.Measure_Unit_ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Deleting This Item ?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    db.DeleteItemById(int.Parse(textBox1.Text));
                    MessageBox.Show("Item Deleted Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                groupBox2.Visible = false;
            }
        }
        private void RefreshAll()
        {
            assisstant.ClearForm(groupBox2);
            textBox1.Text = "";
            comboBox1.DataSource = null;
            assisstant.FillCb<Item>(comboBox1, "Name", "ID", db.GetAllItems());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }
    }
}
