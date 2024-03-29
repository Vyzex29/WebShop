﻿namespace DataAccess.Context.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string? ImageName { get; set; }

        public byte[]? Image { get; set; } 

        public SubCategory Subcategory { get; set; }
    }
}
