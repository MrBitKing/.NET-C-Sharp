using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Title { get; set; }


        [Required]
        [StringLength(1000)]
        public string SubTitle { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        [RangeAttribute(1, 5)]
        public int Rating { get; set; }

    }
}