using System;
using System.Collections.Generic;
using System.Text;

namespace Voyages.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public int IdFile { get; set; }
    }
}
