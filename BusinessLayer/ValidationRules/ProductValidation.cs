using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Ad boş geçilemez!");
            RuleFor(x => x.value).NotEmpty().WithMessage("Değer boş geçilemez!");
        }
    }
}
