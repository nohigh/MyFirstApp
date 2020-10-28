using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nohai_Dragos_Ionut_Lab2.Models;

namespace Nohai_Dragos_Ionut_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();
            if(context.Books.Any())
            {
                return;
            }

            var books = new Book[]
            {
                new Book{Title="Baltagul",Author="Mihail Sadoveanu",Price=Decimal.Parse("22")},
                new Book{Title="Enigma Otiliei",Author="George Calinescu",Price=Decimal.Parse("18")},
                new Book{Title="Maytrei",Author="Mircea Eliade",Price=Decimal.Parse("27")},
                new Book{Title="Panza de paianjen",Author="Cella Serghi",Price=Decimal.Parse("45")},
                new Book{Title="Fata de hartie",Author="Guillame Musso",Price=Decimal.Parse("38")},
                new Book{Title="De veghe in lanul de secara",Author="J.D.Salinger",Price=Decimal.Parse("28")}
            };
            foreach(Book b in books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{CustomerID=1050, Name="Popescu Ioan", BirthDate=DateTime.Parse("1979-09-01")},
                new Customer{CustomerID=1045, Name="Nohai Dragos", BirthDate=DateTime.Parse("1998-01-15")},
            };
            foreach(Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{BookID=1, CustomerID=1050, OrderDate=DateTime.Parse("08-01-2020")},
                new Order{BookID=3, CustomerID=1045, OrderDate=DateTime.Parse("09-09-2020")},
                new Order{BookID=1, CustomerID=1045, OrderDate=DateTime.Parse("10-10-2020")},
                new Order{BookID=2, CustomerID=1050, OrderDate=DateTime.Parse("11-11-2020")},
                new Order{BookID=4, CustomerID=1050, OrderDate=DateTime.Parse("11-11-2020")},
                new Order{BookID=6, CustomerID=1050, OrderDate=DateTime.Parse("11-11-2020")}

            };
            foreach(Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();

            var publishers = new Publisher[]
            {
                new Publisher{PublisherName="Humanitas", Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
                new Publisher{PublisherName="Nemira", Adress="Str. Plopilor, nr. 35, Ploiesti"},
                new Publisher{PublisherName="Paralela 45", Adress="Str. Cascadelor, nr.22, Cluj-Napoca"},
            };

            foreach (Publisher p in publishers)
            {
                context.Publishers.Add(p);
            }
            context.SaveChanges();

            var publishedbooks = new PublishedBook[]
            {
                new PublishedBook {BookID = books.Single(c => c.Title == "Maytrei").ID, 
                    PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                },
                new PublishedBook {BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID, 
                    PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                },
                new PublishedBook {BookID = books.Single(c => c.Title == "Baltagul" ).ID, 
                    PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID
                },
                new PublishedBook {BookID = books.Single(c => c.Title == "Fata de hartie" ).ID, 
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                },
                new PublishedBook {BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID, 
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                },
                new PublishedBook {BookID = books.Single(c => c.Title == "De veghe in lanul de secara" ).ID, 
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                },
            };

            foreach (PublishedBook pb in publishedbooks)
            {
                context.PublishedBooks.Add(pb);
            }
            context.SaveChanges();
        }
    }
}
