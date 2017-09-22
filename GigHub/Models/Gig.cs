using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }
        
        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        public CultureInfo CultureInfo
        { get
            { return new CultureInfo("en-US"); }
        }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

       
        
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }


    }
   
}