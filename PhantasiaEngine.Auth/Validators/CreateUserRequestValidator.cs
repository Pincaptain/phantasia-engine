using FluentValidation;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Auth.Services;

namespace PhantasiaEngine.Auth.Validators
{
    /// <summary>
    /// <c>CreateUserRequestValidator</c> class contains the validation rules for
    /// <c>CreateUserRequest</c><see cref="CreateUserRequest"/>.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator(IUserService userService)
        {
            RuleFor(createUserRequest => createUserRequest.Username)
                .NotNull()
                .NotEmpty()
                .Must(username => userService.GetUserByUsername(username) == null)
                .WithMessage("'Username' must be unique.");
            
            RuleFor(createUserRequest => createUserRequest.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(createUserRequest => createUserRequest.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}