using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShop.Model
{
    public class StockBalance
    {
        [PrimaryKey]
        public int ItemId { get; set; }
        public int Qty { get; set; }
    }
}
