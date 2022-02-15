using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApp.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalBooks { get; set; }
        public int ResultsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalBooks / ResultsPerPage);
    }
}
