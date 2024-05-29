using Microsoft.EntityFrameworkCore;

namespace _01.Exercise_Image.Models.ORM
{
    public class BlogContenxt : DbContext
    {
        public BlogContenxt(DbContextOptions<BlogContenxt> options) : base(options) 
        {
            
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<PostImages> PostImages { get; set; }
    }
}
