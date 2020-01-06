using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public decimal Price { get; set; }
        public decimal Rate { get; set; }
        public int Votes { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public string Another1 { get; set; }
        public string Another2 { get; set; }
        public string Another3 { get; set; }
        public string Another4 { get; set; }
    }
}
