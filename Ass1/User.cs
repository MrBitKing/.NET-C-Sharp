
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ass1.Models
{

    [Table("Users")]
    public class User
    {

        [Key]
        [Required]
       public int UserId
        {
            get;
            set;

        }

        [ForeignKey("Standard")]
        [Required]
        public int RoleId
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string LastName
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string EmailAddress
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string Password
        {
            get;
            set;

        }
    }
}