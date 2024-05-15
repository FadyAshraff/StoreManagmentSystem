using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentSystem.ViewModels
{
    class SalesInvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public string UsedUnit { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
