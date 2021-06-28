using FluentValidation;

namespace DevIO.Bussiness.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        private const string NotEmptyMsg = "O campo {PropertyName} precisa ser fornecido.";
        private const string MinMaxLengthMsg = "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.";
        private const string MinLengthMsg = "O campo {PropertyName} precisa ter {MaxLength} caracteres.";

        public AddressValidation()
        {
            RuleFor(x => x.PublicPlace)
                .NotEmpty().WithMessage(NotEmptyMsg)
                .Length(2, 200).WithMessage(MinMaxLengthMsg);

            RuleFor(x => x.District)
                .NotEmpty().WithMessage(NotEmptyMsg)
                .Length(2, 100).WithMessage(MinMaxLengthMsg);

            RuleFor(x => x.Cep)
               .NotEmpty().WithMessage(NotEmptyMsg)
               .Length(8).WithMessage(MinLengthMsg);

            RuleFor(x => x.City)
               .NotEmpty().WithMessage(NotEmptyMsg)
               .Length(2, 100).WithMessage(MinMaxLengthMsg);

            RuleFor(x => x.State)
               .NotEmpty().WithMessage(NotEmptyMsg)
               .Length(2, 50).WithMessage(MinMaxLengthMsg);

            RuleFor(x => x.Number)
               .NotEmpty().WithMessage(NotEmptyMsg)
               .Length(2, 50).WithMessage(MinMaxLengthMsg);
        }
    }
}
