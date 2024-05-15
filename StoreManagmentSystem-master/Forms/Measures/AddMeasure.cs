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
    public partial class AddMeasure : Form
    {
        MeasureDb db = new MeasureDb();
        Assistant assisstant = new Assistant();
        public AddMeasure()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!assisstant.CheckIfFormIsEmpty(groupBox1))
            {
                Measure measure = new Measure
                {
                    Main_Measure = textBox1.Text,
                    Sub_Measure = textBox2.Text,
                    Quantity = int.Parse(textBox3.Text),
                };

                try
                {
                    db.addMeasure(measure);
                    MessageBox.Show("Measure Is Added Successfully");
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
