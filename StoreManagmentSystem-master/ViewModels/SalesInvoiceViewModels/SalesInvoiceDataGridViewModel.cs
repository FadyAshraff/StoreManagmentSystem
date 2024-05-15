using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentSystem.ViewModels
{
    class SalesInvoiceDataGridViewModel
    {
        public int InvoiceId { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [DisplayName("Store Name")]
        public string StoreName { get; set; }
        [DisplayName("Used Unit")]
        public string UsedUnit { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
