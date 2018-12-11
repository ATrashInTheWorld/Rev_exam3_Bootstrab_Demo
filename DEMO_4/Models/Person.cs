using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DEMO_4.Models
{
    public enum MusicGenre
    {
        Rock,
        [Display(Name = "Rhythm and Blues")]
        RB,
        [Display(Name = "Hip Hop")]
        HipHop,
        Country,
        Pop,
        Gospel
    }

    public class Person
    {
      


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool LikesMusic { get; set; }
        public ICollection<string> Skills { get; set; }


        public MusicGenre FavoriteMusic { get; set; }
    }

}