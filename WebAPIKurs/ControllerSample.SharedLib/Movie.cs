#nullable disable 
using System.ComponentModel.DataAnnotations;

namespace ControllerSample.SharedLib
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public GenreType Genre { get; set; } // -> richtung DB wird ein Enum ein integeger-Feld
    }

    public enum GenreType { Action, Thriller, Drama, Comedy, Horro, Romance, Docu }
}