using System;
using System.Collections.Generic;
using System.Text;

namespace Voyages.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string PhotoLink { get; set; }
    }
}
