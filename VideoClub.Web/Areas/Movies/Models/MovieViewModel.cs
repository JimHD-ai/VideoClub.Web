using System.ComponentModel.DataAnnotations;
using VideoClub.Core.Enumerations;

namespace VideoClub.Web.Areas.Movies.Models
{
    public class MovieViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Genre")]
        public MovieGenre Genre { get; set; }

        public MovieViewModel(int id, string title, string description, MovieGenre genre)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
        }
    }


}