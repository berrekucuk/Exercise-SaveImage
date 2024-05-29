using Microsoft.AspNetCore.Http;

namespace _01.Exercise_Image.Models.DTO
{
    public class CreateBlogPostRequestDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
