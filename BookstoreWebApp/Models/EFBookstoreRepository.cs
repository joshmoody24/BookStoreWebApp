using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApp.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        public BookstoreContext context { get; set; }
        public IQueryable<Book> Books => context.Books;

        public EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteProject(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
