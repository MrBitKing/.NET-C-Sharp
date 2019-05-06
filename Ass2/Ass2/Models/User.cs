

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;



namespace Ass2.Models
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

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string City
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string Address
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string PostalCode
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string Country
        {
            get;
            set;
        }
    }
}
