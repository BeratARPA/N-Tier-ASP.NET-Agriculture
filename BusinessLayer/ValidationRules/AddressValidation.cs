using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta boş geçilemez!");            
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita bilgisi boş geçilemez!");
        }
    }
}
