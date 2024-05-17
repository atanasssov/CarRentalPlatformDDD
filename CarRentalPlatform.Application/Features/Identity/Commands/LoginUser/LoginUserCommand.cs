using CarRentalPlatform.Application.Contracts;

using MediatR;

namespace CarRentalPlatform.Application.Features.Identity.Commands.LoginUser
{
    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public LoginUserCommand(string email, string password)
            : base(email, password)
        {
        }

      

        public class LoginUserCommandHandler(IIdentity identity) : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            public async Task<Result<LoginOutputModel>> Handle( LoginUserCommand request,
                                                                CancellationToken cancellationToken)
            {
                return await identity.Login(request);
            }
        }
    }
}
