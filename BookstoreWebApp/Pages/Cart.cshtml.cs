using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookstoreWebApp.Models;
using BookstoreWebApp.Infrastructure;

namespace BookstoreWebApp.Pages
{
    public class CartPageModel : PageModel
    {
        private IBookstoreRepository repo;

        public CartPageModel(IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            Cart = c;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(b => b.BookId == bookId);

            Cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int projectId, string returnUrl)
        {
            Cart.RemoveItem(Cart.Items.First(x => x.Book.BookId == projectId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
