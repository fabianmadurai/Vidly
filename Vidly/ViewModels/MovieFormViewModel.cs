using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        //for the dropdown of genres
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}