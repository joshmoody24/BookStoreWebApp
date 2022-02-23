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

        public CartPageModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(b => b.BookId == bookId);
            // null coalescing operator
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
