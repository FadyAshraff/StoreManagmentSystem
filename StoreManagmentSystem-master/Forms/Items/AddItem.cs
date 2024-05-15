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
    public partial class AddItem : Form
    {
        ItemDb db = new ItemDb();
        MeasureDb MeasureDb = new MeasureDb();
        Assistant assisstant = new Assistant();
        public AddItem()
        {
            InitializeComponent();
            //SettingCb_Measures();
            assisstant.FillCb<Measure>(comboBox1, "Main_Measure", "ID", MeasureDb.GetAllMeasures());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox1))
            {
                Item item = new Item
                {
                    Name = textBox1.Text,
                    Code = textBox2.Text,
                    Measure_Unit_ID = int.Parse(comboBox1.SelectedValue.ToString())
                };

                try
                {
                    db.AddItem(item);
                    MessageBox.Show("Item Added Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong try again");
                }

            }
            else
            {
                MessageBox.Show("All fields are required");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assisstant.ClearForm(groupBox1);
        }
        //private void SettingCb_Measures()
        //{
        //    assisstant.FillCb<AllMeasuresCb>(comboBox1, "Description", "Id", assisstant.settingDisplayOfCb_AllMeasures(MeasureDb.GetAllMeasures()));
        //}
    }
}
