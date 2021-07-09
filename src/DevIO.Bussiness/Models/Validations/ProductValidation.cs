using DevIO.Bussiness.Interfaces.Repository;
using FluentValidation;

namespace DevIO.Bussiness.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        private const string NotEmptyMsg = "O campo {PropertyName} precisa ser fornecido.";
        private const string MinMaxLengthMsg = "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.";
        private const string GreaterThanMsg = "O campo {PropertyName} precisa ser maior que {ComparisonValue}.";

        public ProductValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(NotEmptyMsg)
                .Length(2, 200).WithMessage(MinMaxLengthMsg);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(NotEmptyMsg)
                .Length(2, 100).WithMessage(MinMaxLengthMsg);

            RuleFor(x => x.Value)
               .GreaterThan(0).WithMessage(GreaterThanMsg);
        }
    }
}
