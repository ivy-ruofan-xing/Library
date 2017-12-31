using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"\d{13}", ErrorMessage="ISBN must be 13 digits.")]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        public string Description { get; set; }
    }
}