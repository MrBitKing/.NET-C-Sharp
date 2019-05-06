
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ass1.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId
        {
            get;
            set;

        }

        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title
        {
            get;
            set;

        }

        [Required]
        [StringLength(5000)]
        public string Content
        {
            get;
            set;

        }

        [DataType(DataType.Date)]
        public DateTime Posted
        {
            get;
            set;

        }
    }
}