using FluentValidation;

namespace CoinJarGK.Application.CoinJar.Commands.AddCoinToJar
{
    public class AddCoinToJarCommandValidator : AbstractValidator<AddCoinToJarCommand>
    {
        public AddCoinToJarCommandValidator()
        {
            RuleFor(c => c).NotEmpty().WithMessage("Coin cannot be null or empty");

            When(c => c != null, () =>
            {
                RuleFor(c => c.Volume).GreaterThan(0).WithMessage("Volume must be greater than 0");
                RuleFor(c => c.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
            });
        }
    }
}
