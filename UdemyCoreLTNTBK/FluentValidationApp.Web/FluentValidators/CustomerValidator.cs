using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz")
                .EmailAddress().WithMessage("Email değeri doğru formatta değil");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age alanı boş bırakılamaz")
                .InclusiveBetween(18,60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());

        }
    }
}
