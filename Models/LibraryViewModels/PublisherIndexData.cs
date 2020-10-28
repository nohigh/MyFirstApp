using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nohai_Dragos_Ionut_Lab2.Models.LibraryViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
