using System;
using System.Collections.Generic;
using System.Text;

namespace Voyages.SqlDataAccess.Entities
{
    public class File
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Type { get; set; }
        public string ArrivalDate { get; set; }
        public int Duration { get; set; }
        public string FlightNumber { get; set; }
        public string Place { get; set; }
        public int Travelers { get; set; }
        public decimal Price { get; set; }
    }
}
