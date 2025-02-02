﻿using StoreManagmentSystem.AssistanatClasses;
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

namespace StoreManagmentSystem.Forms.Invoices.SupplyInvoices
{
    public partial class AddSupplyInvoice : Form
    {
        SupplyInvoiceDb db = new SupplyInvoiceDb();
        VendorDb venDb = new VendorDb();
        StoreDb storeDb = new StoreDb();
        ItemDb ItemDb = new ItemDb();
        MeasureDb measureDb = new MeasureDb();
        Assistant assisstant = new Assistant();

        List<SupplyInvoiceDataGridViewModel> dataGridViewModels = new List<SupplyInvoiceDataGridViewModel>();
        FullSupplyInvoice fullSupplyInvoice = new FullSupplyInvoice();
        public AddSupplyInvoice()
        {
            InitializeComponent();
            SettingMainInfoSection();
        }
        private void SettingMainInfoSection()
        {
            txt_currentDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txt_invoiceNo.Text = assisstant.GetCurrnetInvoiceNo(db.GetAllSupplyInvoices().Select(s => s.Invoice_No.Value).ToList()).ToString();
            assisstant.FillCB_ViewBy(cb_viewBy);
            cb_viewBy.SelectedIndex = 0;
        }

        private void cb_viewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = cb_viewBy.SelectedValue.ToString();

            if (cb_viewBy.SelectedIndex != 0)
            {
                assisstant.FillCb<Vendor>(cb_ven, filter, "ID", venDb.GetAllVedors());
                pl_vendor.Visible = true;
                lb_selectVendor.Text = "Vendor " + filter;
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
                lb_vendor.Text = venDb.GetVendorById(int.Parse(cb_ven.SelectedValue.ToString())).Name;

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
            fullSupplyInvoice.VendorId = int.Parse(cb_ven.SelectedValue.ToString());
            fullSupplyInvoice.InvoiceDate = Convert.ToDateTime(lb_date.Text);
            fullSupplyInvoice.InvoiceNo = int.Parse(lb_invoiceNumber.Text);

            SupplyInvoiceViewModel supplyInvoiceViewModel = new SupplyInvoiceViewModel
            {
                ExpiringDate = Convert.ToDateTime(dp_ExpiringDate.Value),
                ItemId = int.Parse(cb_item.SelectedValue.ToString()),
                Note = txt_note.Text,
                ProductionDate = Convert.ToDateTime(dp_productionDate.Value),
                Quantity = (int)nud_quantity.Value,
                StoreId = int.Parse(cb_store.SelectedValue.ToString()),
                UsedUnit = cb_measures.SelectedItem.ToString()
            };

            fullSupplyInvoice.SupplyInvoiceDetails.Add(supplyInvoiceViewModel);

            DisplayDataGridView(fullSupplyInvoice);
        }
        private void DisplayDataGridView(FullSupplyInvoice supplyInvoice)
        {

            if (dg_invoiceDetails.Visible == false)
            {
                dg_invoiceDetails.Visible = true;
            }
            dataGridViewModels.Clear();

            foreach (var details in supplyInvoice.SupplyInvoiceDetails)
            {
                SupplyInvoiceDataGridViewModel supplyInvoiceDataGrid = new SupplyInvoiceDataGridViewModel
                {
                    ExpiringDate = details.ExpiringDate.ToString("dd/MM/yyyy"),
                    UsedUnit = details.UsedUnit,
                    ItemName = ItemDb.GetItemById(details.ItemId).Name,
                    Note = details.Note,
                    ProductionDate = details.ProductionDate.ToString("dd/MM/yyyy"),
                    Quantity = details.Quantity,
                    StoreName = storeDb.GetStoreById(details.StoreId).Name
                };
                dataGridViewModels.Add(supplyInvoiceDataGrid);
            }

            dg_invoiceDetails.DataSource = null;
            dg_invoiceDetails.DataSource = dataGridViewModels;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                db.AddSupplyInvoice(fullSupplyInvoice);
                MessageBox.Show("Supply Invoice Saved Successfully");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }
    }
}
