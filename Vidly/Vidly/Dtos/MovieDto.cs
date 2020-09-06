using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 20)]
        public short NumberInStock { get; set; }

        public GenreDto Genre { get; set; }

        //Forign Key from Genre Class
        [Required]
        public byte GenreId { get; set; }
    }
}
