﻿namespace ProductCatalog.UI.Models
{
    public class ProductCreateRequestModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
    }
}