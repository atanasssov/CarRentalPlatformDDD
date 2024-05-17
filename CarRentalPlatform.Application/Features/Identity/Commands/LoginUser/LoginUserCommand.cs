using CarRentalPlatform.Application.Contracts;

using MediatR;

namespace CarRentalPlatform.Application.Features.Identity.Commands.LoginUser
{
    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        internal LoginUserCommand(string email, string password)
            : base(email, password)
        {
        }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;

            public LoginUserCommandHandler(IIdentity identity) => this.identity = identity;

            public async Task<Result<LoginOutputModel>> Handle( LoginUserCommand request,
                                                                CancellationToken cancellationToken)
            {
                return await this.identity.Login(request);
            }
        }
    }
}
