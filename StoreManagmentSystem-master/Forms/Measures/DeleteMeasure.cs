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
    public partial class DeleteMeasure : Form
    {
        MeasureDb db = new MeasureDb();
        Assistant assisstant = new Assistant();
        public DeleteMeasure()
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
            DialogResult dialogResult = MessageBox.Show("Are You Sure Deleting This Measure ?", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    db.DeleteMeasureById(int.Parse(textBox1.Text));
                    MessageBox.Show("Measure Deleted Successfully");
                }
                catch (Exception)
                {
                    throw;
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
            assisstant.FillCb<Measure>(comboBox1, "Main_Measure", "ID", db.GetAllMeasures());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }
    }
 }
