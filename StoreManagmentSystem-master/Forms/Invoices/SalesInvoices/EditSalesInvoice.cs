using StoreManagmentSystem.AssistanatClasses;
using StoreManagmentSystem.Methods;
using StoreManagmentSystem.Reports;
using StoreManagmentSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManagmentSystem.Forms.Invoices.SalesInvoices
{
    public partial class EditSalesInvoice : Form
    {
        SalesInvoiceDb db = new SalesInvoiceDb();
        CustomerDb custDb = new CustomerDb();
        StoreDb storeDb = new StoreDb();
        ItemDb itemDb = new ItemDb();
        MeasureDb measureDb = new MeasureDb();

        Assistant assisstant = new Assistant();

        FullSalesInvoice fullSalesInvoice = new FullSalesInvoice();
        public EditSalesInvoice()
        {
            InitializeComponent();
            SettingSalesInvoiceData();
        }
        private void SettingSalesInvoiceData()
        {
            List<Sales_Invoice> allInvoices = db.GetAllSalesInvoices();
            List<string> invoiceDates = assisstant.SettingCb_DateDisplay(allInvoices.Select(s => s.Date.Value).Distinct().ToList());
            assisstant.FillCb(cb_invoiceDate, null, null, invoiceDates);
        }

        private void cb_invoiceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Sales_Invoice> allInvoices = db.GetAllSalesInvoices();

            if (cb_invoiceDate.SelectedIndex != 0)
            {
                allInvoices = allInvoices.Where(w => w.Date.Value.ToString("dd/MM/yyyy") == cb_invoiceDate.SelectedValue.ToString()).ToList();
            }

            assisstant.FillCb(cb_invoiceNo, null, null, allInvoices.Select(s => s.Invoice_No.Value).Distinct().ToList());
            pl_invoiceNo.Visible = true;
        }

        private void cb_invoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fullSalesInvoice = new FullSalesInvoice();

            assisstant.FillCB_ViewBy(cb_viewBy);
            cb_viewBy.SelectedIndex = 0;
            fullSalesInvoice.InvoiceNo = int.Parse(cb_invoiceNo.SelectedValue.ToString());
            FillData();
            pl_vendorData.Visible = true;
        }
        private void FillData()
        {
            List<Sales_Invoice> invoices = db.GetSalesInvoicesByInvoiceNo(fullSalesInvoice.InvoiceNo).ToList();
            fullSalesInvoice.CustomerId = invoices[0].Customer_ID.Value;
            fullSalesInvoice.InvoiceDate = invoices[0].Date.Value;

            foreach (var invoice in invoices)
            {
                SalesInvoiceViewModel salesInvoiceViewModel = new SalesInvoiceViewModel
                {
                    InvoiceId = invoice.ID,
                    ItemId = invoice.Store_Item_Quantity.Store_Item.Item.ID,
                    Note = invoice.Store_Item_Quantity.Notes,
                    Quantity = invoice.Store_Item_Quantity.Quantity.Value,
                    StoreId = invoice.Store_Item_Quantity.Store_Item.Store.ID,
                    UsedUnit = invoice.Store_Item_Quantity.Measure_Name
                };

                fullSalesInvoice.SalesInvoiceDetails.Add(salesInvoiceViewModel);
            }

        }

        private void cb_viewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = cb_viewBy.SelectedValue.ToString();
            if (cb_viewBy.SelectedIndex != 0)
            {
                pl_vendorName.Visible = true;
                assisstant.FillCb<Customer>(cb_ven, filter, "ID", custDb.GetAllCustomers());
                lb_selectVendor.Text = "Customer " + filter;
                cb_ven.SelectedValue = fullSalesInvoice.CustomerId;
            }
        }

        private void btn_cont_Click(object sender, EventArgs e)
        {
            if (cb_viewBy.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Valid Data");
            }
            else
            {
                gb_invoice.Visible = true;
                btn_editVendor.Visible = false;
                lb_date.Text = fullSalesInvoice.InvoiceDate.ToString("dd/MM/yyyy");
                lb_invoiceNumber.Text = fullSalesInvoice.InvoiceNo.ToString();
                lb_vendor.Text = custDb.GetCustomerById(int.Parse(cb_ven.SelectedValue.ToString())).Name;
                fullSalesInvoice.CustomerId = int.Parse(cb_ven.SelectedValue.ToString());
                gb_mainInfo.Enabled = false;

                DisplayDataGrid();

            }
        }
        private void DisplayDataGrid()
        {
            dg_invoiceDetails.DataSource = null;

            List<SalesInvoiceDataGridViewModel> source = new List<SalesInvoiceDataGridViewModel>();

            foreach (var invoice in fullSalesInvoice.SalesInvoiceDetails)
            {
                SalesInvoiceDataGridViewModel row = new SalesInvoiceDataGridViewModel
                {
                    InvoiceId = invoice.InvoiceId,
                    ItemName = itemDb.GetItemById(invoice.ItemId).Name,
                    Note = invoice.Note,
                    Quantity = invoice.Quantity,
                    StoreName = storeDb.GetStoreById(invoice.StoreId).Name,
                    UsedUnit = invoice.UsedUnit
                };

                source.Add(row);
            }

            dg_invoiceDetails.DataSource = source;
            dg_invoiceDetails.Columns[0].Visible = false;
        }

        private void btn_editVendor_Click(object sender, EventArgs e)
        {
            btn_editVendor.Visible = false;
            cb_ven.Enabled = true;
        }

        private void dg_invoiceDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_invoiceDetails.SelectedRows.Count != 0)
            {
                int invoiceId = int.Parse(dg_invoiceDetails.SelectedRows[0].Cells[0].Value.ToString());

                fillFields(invoiceId);
            }
        }

        private void fillFields(int invoiceId)
        {

            SalesInvoiceViewModel invoice = fullSalesInvoice.SalesInvoiceDetails.FirstOrDefault(f => f.InvoiceId == invoiceId);

            assisstant.FillCb(cb_item, "Name", "ID", itemDb.GetAllItems());
            cb_item.SelectedValue = invoice.ItemId;

            assisstant.FillCb(cb_store, "Name", "ID", storeDb.GetAllStores());
            cb_store.SelectedValue = invoice.StoreId;

            assisstant.FillCb(cb_measures, null, null, measureDb.GetMeasureItem(invoiceId));
            cb_measures.SelectedItem = invoice.UsedUnit;

            nud_quantity.Value = invoice.Quantity;

            txt_note.Text = invoice.Note;

            gb_itemData.Visible = true;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            SalesInvoiceViewModel invoice = fullSalesInvoice.SalesInvoiceDetails.FirstOrDefault(f => f.InvoiceId == int.Parse(dg_invoiceDetails.SelectedRows[0].Cells[0].Value.ToString()));

            invoice.ItemId = int.Parse(cb_item.SelectedValue.ToString());
            invoice.Quantity = (int)nud_quantity.Value;
            invoice.StoreId = int.Parse(cb_store.SelectedValue.ToString());
            invoice.Note = txt_note.Text;
            invoice.UsedUnit = cb_measures.SelectedItem.ToString();

            DisplayDataGrid();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                db.EditSalesInvoice(fullSalesInvoice);
                MessageBox.Show("Sales Invoice Updated Successfully");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }
    }
}
