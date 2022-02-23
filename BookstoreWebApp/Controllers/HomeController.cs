using BookstoreWebApp.Models;
using BookstoreWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApp.Controllers
{
    public class HomeController : Controller
    {

        public IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string? category, int pageNum = 1)
        {
            ViewBag.SelectedCategory = category;
            const int RESULTS_PER_PAGE = 5;
            var books = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip(RESULTS_PER_PAGE * (pageNum - 1))
                .Take(RESULTS_PER_PAGE),

                PageInfo = new PageInfo
                {
                    TotalBooks = repo.Books.Where(b => b.Category == category || category == null).Count(),
                    ResultsPerPage = RESULTS_PER_PAGE,
                    CurrentPage = pageNum
                }
            };

            return View(books);
        }

    }
}
