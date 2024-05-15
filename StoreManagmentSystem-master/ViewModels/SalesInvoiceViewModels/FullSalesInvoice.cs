using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentSystem.ViewModels
{
    class FullSalesInvoice
    {
        public DateTime InvoiceDate { get; set; }
        public int InvoiceNo { get; set; }
        public int CustomerId { get; set; }

        public List<SalesInvoiceViewModel> SalesInvoiceDetails = new List<SalesInvoiceViewModel>();
    }
}
