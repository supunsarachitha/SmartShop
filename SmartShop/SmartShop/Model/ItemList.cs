using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShop.Model
{
    public class ItemList
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }
    }
}
