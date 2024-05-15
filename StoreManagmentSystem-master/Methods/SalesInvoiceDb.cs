using StoreManagmentSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentSystem.Methods
{
    class SalesInvoiceDb
    {
        StoreManagmentContext db = new StoreManagmentContext();
        public List<Sales_Invoice> GetAllSalesInvoices()
        {
            return db.Sales_Invoice.ToList();
        }
        public void AddSalesInvoice(FullSalesInvoice salesInvoices)
        {
            foreach (var salesInvoice in salesInvoices.SalesInvoiceDetails)
            {
                Store_Item store_Item = new Store_Item
                {
                    Store_ID = salesInvoice.StoreId,
                    Item_ID = salesInvoice.ItemId
                };

                db.Store_Item.Add(store_Item);
                db.SaveChanges();

                Store_Item_Quantity store_Item_Quantity = new Store_Item_Quantity
                {
                    Measure_Name = salesInvoice.UsedUnit,
                    Notes = salesInvoice.Note,
                    Quantity = salesInvoice.Quantity,
                    Increment_Decrement = true,
                    Is_Transferred = false,
                    Store_Item_ID = store_Item.ID
                };

                db.Store_Item_Quantity.Add(store_Item_Quantity);
                db.SaveChanges();

                Sales_Invoice sales_Invoice = new Sales_Invoice
                {
                    Date = salesInvoices.InvoiceDate,
                    Invoice_No = salesInvoices.InvoiceNo,
                    Customer_ID = salesInvoices.CustomerId,
                    Store_Item_Quantity_ID = store_Item_Quantity.ID
                };

                db.Sales_Invoice.Add(sales_Invoice);
                db.SaveChanges();

            }
        }
        public List<Sales_Invoice> GetSalesInvoicesByInvoiceNo(int invoiceNo)
        {
            return db.Sales_Invoice.Where(w => w.Invoice_No == invoiceNo).ToList();
        }

        public void EditSalesInvoice(FullSalesInvoice fullSalesInvoice)
        {
            List<SalesInvoiceViewModel> details = fullSalesInvoice.SalesInvoiceDetails;
            List<Sales_Invoice> rows = db.Sales_Invoice.Where(w => w.Invoice_No == fullSalesInvoice.InvoiceNo).ToList();
            foreach (var row in rows)
            {
                row.Customer_ID = fullSalesInvoice.CustomerId;
            }

            for (int i = 0; i < fullSalesInvoice.SalesInvoiceDetails.Count; i++)
            {
                rows[i].Store_Item_Quantity.Measure_Name = details[i].UsedUnit;
                rows[i].Store_Item_Quantity.Quantity = details[i].Quantity;
                rows[i].Store_Item_Quantity.Notes = details[i].Note;
                rows[i].Store_Item_Quantity.Store_Item.Store_ID = details[i].StoreId;
                rows[i].Store_Item_Quantity.Store_Item.Item_ID = details[i].ItemId;
            }

            db.SaveChanges();

        }
    }
}
