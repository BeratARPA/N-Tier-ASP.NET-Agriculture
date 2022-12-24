using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SocialMediaValidation : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidation()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İcon boş geçilemez!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url boş geçilemez!");
        }
    }
}
