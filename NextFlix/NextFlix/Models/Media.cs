using System;
using System.ComponentModel.DataAnnotations;

namespace NextFlix.Models
{
    public class Media
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Release Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "The Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "The Genre is required.")]
        public Genre Genre { get; set; }

        public bool IsWatched { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }

        public string Review { get; set; } // Não obrigatório (sem [Required])

        [Required(ErrorMessage = "The Type is required.")]
        public MediaType Type { get; set; }
    }

    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Romance
    }

    public enum MediaType
    {
        Movie,
        Series
    }
}