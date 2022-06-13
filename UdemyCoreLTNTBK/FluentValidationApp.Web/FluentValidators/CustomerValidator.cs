using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş bırakılamaz";

        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage)
                .EmailAddress().WithMessage("Email değeri doğru formatta değil");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage)
                .InclusiveBetween(18,60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} Erkek için 1, Kadın için 2 değerini almalıdır.")
                .NotEmpty().WithMessage(NotEmptyMessage);

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());

        }
    }
}
