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
    }
}
