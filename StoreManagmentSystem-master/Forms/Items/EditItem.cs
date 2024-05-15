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
    public partial class EditItem : Form
    {
        MeasureDb MeasureDb = new MeasureDb();
        ItemDb ItemDb = new ItemDb();
        Assistant assisstant = new Assistant();
        public EditItem()
        {
            InitializeComponent();
            assisstant.FillCb<Item>(comboBox1, "Name", "ID", ItemDb.GetAllItems());
            assisstant.FillCb<Measure>(comboBox2, "Main_Measure", "ID", MeasureDb.GetAllMeasures());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item item = ItemDb.GetItemById(int.Parse(comboBox1.SelectedValue.ToString()));

            textBox1.Text = item.ID.ToString();
            textBox2.Text = item.Name;
            textBox3.Text = item.Code;
            comboBox2.SelectedValue = item.Measure_Unit_ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox2))
            {
                Item item = new Item
                {
                    ID = int.Parse(textBox1.Text.ToString()),
                    Name = textBox2.Text,
                    Code = textBox3.Text,
                    Measure_Unit_ID = int.Parse(comboBox2.SelectedValue.ToString())
                };

                try
                {
                    ItemDb.EditItem(item);
                    MessageBox.Show("Item Updated Successfully");

                }
                catch (Exception)
                {
                    MessageBox.Show("Something Went wrong");
                }
            }
            else
            {
                MessageBox.Show("All fields are required to edit");
            }
        }
        private void RefreshAll()
        {
            assisstant.ClearForm(groupBox2);
            textBox1.Text = "";
            comboBox1.DataSource = null;
            comboBox2.DataSource = null;
            assisstant.FillCb<Item>(comboBox1, "Name", "ID", ItemDb.GetAllItems());
            assisstant.FillCb<Measure>(comboBox2, "Main_Measure", "ID", MeasureDb.GetAllMeasures());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }
    }
}
