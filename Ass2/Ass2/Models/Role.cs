

using System.ComponentModel.DataAnnotations;


namespace Ass2.Models
{

    public class Role
    {
        [Required]
        public int RoleId
        {
            get;
            set;

        }

        [Required]
        [StringLength(100)]
        public string Name
        {
            get;
            set;

        }
    }
}