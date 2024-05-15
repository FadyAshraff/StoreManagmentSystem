using StoreManagmentSystem.Forms.Invoices.SalesInvoices;
using StoreManagmentSystem.Forms.Invoices.SupplyInvoices;
using StoreManagmentSystem.Forms.Items;
using StoreManagmentSystem.Forms.Measures;
using StoreManagmentSystem.Forms.Stackholders.Customers;
using StoreManagmentSystem.Forms.Stackholders.Vendors;
using StoreManagmentSystem.Forms.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManagmentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }

        private void newStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStore addStore = new AddStore();
            addStore.MdiParent = this;
            addStore.Show();
        }

        private void editStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditStore editStore = new EditStore();
            editStore.MdiParent = this;
            editStore.Show();
        }

        private void deleteStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteStore deleteStore = new DeleteStore();
            deleteStore.MdiParent = this;
            deleteStore.Show();
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.MdiParent = this;
            addItem.Show();
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditItem editItem = new EditItem();
            editItem.MdiParent = this;
            editItem.Show();
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItem deleteItem = new DeleteItem();
            deleteItem.MdiParent = this;
            deleteItem.Show();
        }

        private void newMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMeasure addMeasure = new AddMeasure();
            addMeasure.MdiParent = this;
            addMeasure.Show();
        }

        private void editMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMeasure editMeasure = new EditMeasure();
            editMeasure.MdiParent = this;
            editMeasure.Show();
        }

        private void deleteMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMeasure deleteMeasure = new DeleteMeasure();
            deleteMeasure.MdiParent = this;
            deleteMeasure.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.MdiParent = this;
            addCustomer.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCustomer editCustomer = new EditCustomer();
            editCustomer.MdiParent = this;
            editCustomer.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.MdiParent = this;
            deleteCustomer.Show();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddVendor addVendor = new AddVendor();
            addVendor.MdiParent = this;
            addVendor.Show();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditVendor editVendor = new EditVendor();
            editVendor.MdiParent = this;
            editVendor.Show();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteVendor deleteVendor = new DeleteVendor();
            deleteVendor.MdiParent = this;
            deleteVendor.Show();
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddSupplyInvoice supplyInvoice = new AddSupplyInvoice();
            supplyInvoice.MdiParent = this;
            supplyInvoice.Show();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EditSupplyInvoice editSupplyInvoice = new EditSupplyInvoice();
            editSupplyInvoice.MdiParent = this;
            editSupplyInvoice.Show();
        }

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddSalesInvoice addSalesInvoice = new AddSalesInvoice();
            addSalesInvoice.MdiParent = this;
            addSalesInvoice.Show();
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            EditSalesInvoice editSalesInvoice = new EditSalesInvoice();
            editSalesInvoice.MdiParent = this;
            editSalesInvoice.Show();
        }

        private void changeToArabicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
            {
                case "ar-EG":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    break;

                case "en-US":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
                    break;

                default:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    break;
            }

            this.Controls.Clear();
            InitializeComponent();
        }
    }
}
