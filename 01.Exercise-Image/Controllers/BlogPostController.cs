using _01.Exercise_Image.Models.DTO;
using _01.Exercise_Image.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01.Exercise_Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly BlogContenxt _db;
        public BlogPostController(BlogContenxt db)
        {
            _db= db;
        }

        [HttpPost]
        public IActionResult Post(CreateBlogPostRequestDto model)
        {
            List<string> imagePaths = new List<string>();

            foreach(var image in model.Images)
            {
                if(image.ContentType != "image/jpeg" &&  image.ContentType != "image/jpg" && image.ContentType != "image/png")
                {
                    return BadRequest("Lütfen sadece jpeg, jpg ve png formatında resim yükleyiniz");
                }

                var guidName = Guid.NewGuid() + Path.GetExtension(image.FileName);

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", guidName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                imagePaths.Add(guidName);
            }

            BlogPost blogPost = new BlogPost()
            {
                Name = model.Name,
                Content = model.Content,
            };

            _db.BlogPosts.Add(blogPost);
            _db.SaveChanges();

            foreach(var item in imagePaths)
            {
                PostImages postImage = new PostImages()
                {
                    BlogPostID = blogPost.Id,
                    Path = item
                };
                _db.PostImages.Add(postImage);
            }
            _db.SaveChanges();

            return Ok();
        }
    }
}
