using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class SearchViewModel
    {
        public string Title { get; set; }
        
        [RegularExpression(@"\d{13}", ErrorMessage = "ISBN must be 13 digits.")]
        public string ISBN { get; set; }
        
        public string Author { get; set; }
    }

    public class EditViewModel
    {
        public string Title { get; set; }

        [RegularExpression(@"\d{13}", ErrorMessage = "ISBN must be 13 digits.")]
        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}