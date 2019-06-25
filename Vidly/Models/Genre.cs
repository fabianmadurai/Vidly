using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [StringLength(255)]
        [Display(Name = "Genre")]
        public string Genres { get; set; }
    }
}