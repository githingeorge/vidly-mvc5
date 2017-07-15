using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(0,20)]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}