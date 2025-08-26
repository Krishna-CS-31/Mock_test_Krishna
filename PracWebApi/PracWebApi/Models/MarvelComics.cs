using System.ComponentModel.DataAnnotations;

namespace PracWebApi.Models
{
    public class MarvelComics
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }           // e.g. "Avengers #1"
        public string Hero { get; set; }            // e.g. "Iron Man"
        public string Publisher { get; set; }       // e.g. "Marvel Comics"
        public DateTime ReleaseDate { get; set; }   // e.g. 1963-09-10
        //public string ImageUrl { get; set; }
    }
}
