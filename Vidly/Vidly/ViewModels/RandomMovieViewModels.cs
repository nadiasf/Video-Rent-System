using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModels
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RandomMovieViewModels()
        {
          //Basic Initialize
        }

        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
