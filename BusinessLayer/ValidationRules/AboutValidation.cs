using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.History).NotEmpty().WithMessage("Tarihçe boş geçilemez!");
            RuleFor(x => x.AboutUs).NotEmpty().WithMessage("Hakkında boş geçilemez!");
        }
    }
}
