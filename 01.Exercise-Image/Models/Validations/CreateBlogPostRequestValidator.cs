using _01.Exercise_Image.Models.DTO;
using FluentValidation;

namespace _01.Exercise_Image.Models.Validations
{
    public class CreateBlogPostRequestValidator : AbstractValidator<CreateBlogPostRequestDto>
    {
        public CreateBlogPostRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş geçilemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content alanı boş geçilemez.");
        }
    }
}
