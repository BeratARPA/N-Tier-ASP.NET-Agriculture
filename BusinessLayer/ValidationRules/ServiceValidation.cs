using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidation : AbstractValidator<Service>
    {
        public ServiceValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Başlık en fazla 30 karakter olabilir!");
            RuleFor(x => x.Title).MinimumLength(30).WithMessage("Başlık en az 30 karakter olabilir!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.Description).MaximumLength(55).WithMessage("Açıklama en fazla 55 karakter olabilir!");
            RuleFor(x => x.Description).MinimumLength(55).WithMessage("Açıklama en az 55 karakter olabilir!");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolu boş geçilemez!");

            RuleFor(x => x.Class1).NotEmpty().WithMessage("1.Sınıf boş geçilemez!");

            RuleFor(x => x.Class2).NotEmpty().WithMessage("2.Sınıf boş geçilemez!");
        }
    }
}
