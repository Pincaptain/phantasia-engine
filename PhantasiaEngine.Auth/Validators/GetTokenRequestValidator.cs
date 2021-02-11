using FluentValidation;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Auth.Services;

namespace PhantasiaEngine.Auth.Validators
{
    // ReSharper disable once UnusedType.Global
    public class GetTokenRequestValidator : AbstractValidator<GetTokenRequest>
    {
        public GetTokenRequestValidator(IUserService userService)
        {
            RuleFor(getTokenRequest => getTokenRequest.Username)
                .Must(username => userService.GetUserByUsername(username) != null)
                .WithMessage("'Username' does not exist.")
                .NotNull()
                .NotEmpty();

            RuleFor(getTokenRequest => getTokenRequest.Password)
                .NotNull()
                .NotEmpty();

            RuleFor(getTokenRequest => new {getTokenRequest.Username, getTokenRequest.Password})
                .Must(pair => userService.ValidateUserCredential(pair.Username, pair.Password))
                .WithMessage("'Username' and 'Password' combination is not matching.")
                .WithName("Global");
        }
    }
}