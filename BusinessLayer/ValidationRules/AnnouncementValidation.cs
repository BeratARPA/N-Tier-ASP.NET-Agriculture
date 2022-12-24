using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidation : AbstractValidator<Announcement>
    {
        public AnnouncementValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olabilir!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakter olabilir!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir!");
            RuleFor(x => x.Description).MinimumLength(25).WithMessage("Açıklama en az 25 karakter olabilir!");
        }
    }
}
