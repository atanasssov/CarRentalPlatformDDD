using CarRentalPlatform.Application.Contracts;

using MediatR;

namespace CarRentalPlatform.Application.Features.Identity.Commands.CreateUser
{
    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public CreateUserCommand(string email, string password)
            : base(email, password)
        {
        }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }

            public Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                return this.identity.Register(request);
            }
        }
    }
}
