using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//model for the form we created with getters and setters as well as the required

namespace JoelHilton_Elijah_McKay.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int QuoteID { get; set; }
        
        [Required]
        public string Quote { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int Subject { get; set; }


        public string Citation { get; set; }


    }
}
