using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
    }

}