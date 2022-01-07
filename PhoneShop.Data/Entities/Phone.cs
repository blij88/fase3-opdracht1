﻿namespace PhoneShop.Data.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string FullName
        {
            get
            {
                return $"{Brand.Name} {Type}";
            }
        }
    }
}
