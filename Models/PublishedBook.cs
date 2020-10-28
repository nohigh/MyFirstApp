using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nohai_Dragos_Ionut_Lab2.Models
{
    public class PublishedBook
    {
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public Publisher Publisher { get; set; }
        public Book Book { get; set; }
    }
}
