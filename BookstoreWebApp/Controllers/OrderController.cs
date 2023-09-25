using BookstoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repo;
        private Cart cart { get; set; }

        public OrderController(IOrderRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Items.ToArray();
                repo.SaveOrder(order);
                cart.ClearCart();
                return RedirectToPage("/OrderConfirmation");
            }
            else
            {
                return View(new Order());
            }
        }

    }
}
