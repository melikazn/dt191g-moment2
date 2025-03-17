using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace bibliotek.Models
{
    // Denna klass representerar en bokmodell
    public class Book
    {
        // Bokens unika identifierare
        public int Id { get; set; }

        // Titel på boken - är ett obligatoriskt fält
        [Required]
        public string? Title { get; set; }

        // Författare till boken - är ett obligatoriskt fält
        [Required]
        public string? Author { get; set; }

        // Årtal för när boken publicerades - är ett obligatoriskt fält
        [Required]
        public int Year { get; set; }

        // Om boken är en favorit eller inte (boolesk värde)
        public bool IsFavorite { get; set; }

        // Om boken är läst eller inte (boolesk värde)
        public bool IsRead { get; set; }

        // Genre för boken - är ett obligatoriskt fält
        [Required]
        public string Genre { get; set; }
    }
}
