using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Movie()
        {

        }

        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:d MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name ="Date Added")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:d MMM yyyy}")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name ="Number in Stock")]
        [Range(minimum:1,maximum:20)]
        public short NumberInStock { get; set; }

        public Genre Genre { get; set; }
        //Forign Key from Genre Class
        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }

        public byte NumberAvailable { get; set; }
    }
}