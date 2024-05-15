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

namespace StoreManagmentSystem.Forms.Measures
{
    public partial class EditMeasure : Form
    {
        MeasureDb db = new MeasureDb();
        Assistant assisstant = new Assistant();
        public EditMeasure()
        {
            InitializeComponent();
            assisstant.FillCb<Measure>(comboBox1, "Main_Measure", "ID", db.GetAllMeasures());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Measure measure = db.GetMeasureById(int.Parse(comboBox1.SelectedValue.ToString()));

            textBox1.Text = measure.ID.ToString();
            textBox2.Text = measure.Main_Measure;
            textBox3.Text = measure.Sub_Measure;
            textBox4.Text = measure.Quantity.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox2))
            {
                Measure measure = new Measure
                {
                    ID = int.Parse(textBox1.Text),
                    Main_Measure = textBox2.Text,
                    Sub_Measure = textBox3.Text,
                    Quantity = int.Parse(textBox4.Text)
                };

                try
                {
                    db.EditMeasure(measure);
                    MessageBox.Show("Measure Updated Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("something went wrong");
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
            comboBox1.DataSource = null;
            textBox1.Text = "";
            assisstant.FillCb<Measure>(comboBox1, "Main_Measure", "ID", db.GetAllMeasures());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }
    }
}
