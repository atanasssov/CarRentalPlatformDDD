using CarRentalPlatform.Application.Features.Identity;
using CarRentalPlatform.Application.Features.Identity.Commands.LoginUser;

namespace CarRentalPlatform.Application.Contracts
{
    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
    }
}
