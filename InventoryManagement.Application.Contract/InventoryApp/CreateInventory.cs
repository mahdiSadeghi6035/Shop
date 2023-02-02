﻿using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.InventoryApp
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public string Color { get; set; }
        public double UnitPrice { get; set; }
        public List<ViewModelProduct> ModelProducts{ get; set; }
    }
}