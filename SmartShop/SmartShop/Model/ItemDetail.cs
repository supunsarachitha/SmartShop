using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShop.Model
{
    public class ItemDetail
    {
        private int itemid;
        private string itemname;
        private string itemdescription;
        private int itemprice;

        public ItemDetail(int itemid, string itemname, string itemdescription, int itemprice)
        {
            this.ItemId = itemid;
            this.ItemName = itemname;
            this.ItemDescription = itemdescription;
            this.ItemPrice = itemprice;
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }
    }
}
