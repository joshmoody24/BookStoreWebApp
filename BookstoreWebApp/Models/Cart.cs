using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApp.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public virtual void AddItem(Book book, int qty)
        {
            CartLineItem item = Items.Where(b => b.Book.BookId == book.BookId).FirstOrDefault();
            if(item == null)
            {
                Items.Add(
                    new CartLineItem { Book = book, Quantity = qty }
                );
            }
            else
            {
                item.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(b => b.Book.Price * b.Quantity);
            return sum;
        }
    }

    public class CartLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
