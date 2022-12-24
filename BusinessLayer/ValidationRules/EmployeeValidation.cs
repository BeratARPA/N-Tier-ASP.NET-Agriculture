using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad soyad boş geçilemez!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ad soyad en fazla 50 karakter olabilir!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Ad soyad en az 5 karakter olabilir!");

            RuleFor(x => x.Position).NotEmpty().WithMessage("Pozisyon boş geçilemez!");
            RuleFor(x => x.Position).MaximumLength(50).WithMessage("Pozisyon en fazla 50 karakter olabilir!");
            RuleFor(x => x.Position).MinimumLength(5).WithMessage("Pozisyon en az 5 karakter olabilir!");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolu boş geçilemez!");        
        }
    }
}
