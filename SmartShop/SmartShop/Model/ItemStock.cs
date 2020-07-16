using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShop.Model
{
    public class ItemStock
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public int Qty { get; set; }
    }
}
