using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using VideoClub.Core.Enumerations;

namespace VideoClub.Web.Areas.Movies.Models
{
    public class MovieBindingModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public MovieGenre Genre { get; set; }

        public MovieBindingModel(int id, string title, string description, MovieGenre genre)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
        }
    }
}