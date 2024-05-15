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
    public partial class AddSalesInvoice : Form
    {
        SalesInvoiceDb db = new SalesInvoiceDb();
        CustomerDb custDb = new CustomerDb();
        StoreDb storeDb = new StoreDb();
        ItemDb ItemDb = new ItemDb();
        MeasureDb measureDb = new MeasureDb();
        Assistant assisstant = new Assistant();

        List<SalesInvoiceDataGridViewModel> dataGridViewModels = new List<SalesInvoiceDataGridViewModel>();
        FullSalesInvoice fullSalesInvoice = new FullSalesInvoice();
        public AddSalesInvoice()
        {
            InitializeComponent();
            SettingMainInfoSection();
        }
        private void SettingMainInfoSection()
        {
            txt_currentDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txt_invoiceNo.Text = assisstant.GetCurrnetInvoiceNo(db.GetAllSalesInvoices().Select(s => s.Invoice_No.Value).ToList()).ToString();
            assisstant.FillCB_ViewBy(cb_viewBy);
            cb_viewBy.SelectedIndex = 0;
        }

        private void cb_viewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = cb_viewBy.SelectedValue.ToString();

            if (cb_viewBy.SelectedIndex != 0)
            {
                assisstant.FillCb<Customer>(cb_cust, filter, "ID", custDb.GetAllCustomers());
                pl_vendor.Visible = true;
                lb_selectVendor.Text = "Customer " + filter;
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
                lb_invoiceNumber.Text = txt_invoiceNo.Text;
                lb_date.Text = txt_currentDate.Text;
                lb_vendor.Text = custDb.GetCustomerById(int.Parse(cb_cust.SelectedValue.ToString())).Name;

                pl_invoiceLabels.Visible = true;
                gb_invoice.Visible = true;
                gb_itemData.Visible = true;

                assisstant.FillCb<Store>(cb_store, "Name", "ID", storeDb.GetAllStores());
                assisstant.FillCb<AllItemsCb>(cb_item, "NameAndCode", "Id", assisstant.SettingDisplayOfCb_AllItems(ItemDb.GetAllItems()));

                gb_mainInfo.Enabled = false;
            }
        }

        private void cb_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            var measure = measureDb.GetMeasureByItem(int.Parse(cb_item.SelectedValue.ToString()));

            assisstant.FillCb(cb_measures, null, null, new List<string> { measure.Main_Measure, measure.Sub_Measure });
            pl_afterStore.Visible = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            fullSalesInvoice.CustomerId = int.Parse(cb_cust.SelectedValue.ToString());
            fullSalesInvoice.InvoiceDate = Convert.ToDateTime(lb_date.Text);
            fullSalesInvoice.InvoiceNo = int.Parse(lb_invoiceNumber.Text);

            SalesInvoiceViewModel salesInvoiceViewModel = new SalesInvoiceViewModel
            {
                ItemId = int.Parse(cb_item.SelectedValue.ToString()),
                Note = txt_note.Text,
                Quantity = (int)nud_quantity.Value,
                StoreId = int.Parse(cb_store.SelectedValue.ToString()),
                UsedUnit = cb_measures.SelectedItem.ToString()
            };

            fullSalesInvoice.SalesInvoiceDetails.Add(salesInvoiceViewModel);

            DisplayDataGridView(fullSalesInvoice);
        }
        private void DisplayDataGridView(FullSalesInvoice salesInvoice)
        {

            if (dg_invoiceDetails.Visible == false)
            {
                dg_invoiceDetails.Visible = true;
            }
            dataGridViewModels.Clear();

            foreach (var details in salesInvoice.SalesInvoiceDetails)
            {
                SalesInvoiceDataGridViewModel salesInvoiceDataGrid = new SalesInvoiceDataGridViewModel
                {
                    UsedUnit = details.UsedUnit,
                    ItemName = ItemDb.GetItemById(details.ItemId).Name,
                    Note = details.Note,
                    Quantity = details.Quantity,
                    StoreName = storeDb.GetStoreById(details.StoreId).Name
                };
                dataGridViewModels.Add(salesInvoiceDataGrid);
            }

            dg_invoiceDetails.DataSource = null;
            dg_invoiceDetails.DataSource = dataGridViewModels;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                db.AddSalesInvoice(fullSalesInvoice);
                MessageBox.Show("Sales Invoice Saved Successfully");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }
    }
}
