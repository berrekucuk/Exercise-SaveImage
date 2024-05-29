using System.ComponentModel.DataAnnotations.Schema;

namespace _01.Exercise_Image.Models.ORM
{
    public class PostImages : BaseEntity
    {
        public string Path { get; set; }
        public Guid BlogPostID { get; set; }

        [ForeignKey("BlogPostID")]
        public BlogPost BlogPost { get; set; }
    }
}
