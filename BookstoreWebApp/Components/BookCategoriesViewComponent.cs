using BookstoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApp.Components
{
    public class BookCategoriesViewComponent : ViewComponent
    {
        public IBookstoreRepository repo;

        public BookCategoriesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct();
            return View(categories);
        }
    }
}
