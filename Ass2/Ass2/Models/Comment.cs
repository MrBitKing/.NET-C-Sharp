
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass2.Models
{

    public class Comment
    {
        [Key]
        public int CommentId
        {
            get;
            set;

        }

        [ForeignKey("BlogPostId")]
        public int BlogPostId
        {
            get;
            set;

        }

        [ForeignKey("UserId")]
        public int UserId
        {
            get;
            set;

        }

        [Required]
        [StringLength(1000)]
        public string Content
        {
            get;
            set;

        }

        [Required]
        public int Rating
        {
            get;
            set;
        }
    }
}