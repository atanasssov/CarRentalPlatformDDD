using CarRentalPlatform.Application.Features.Identity;

namespace CarRentalPlatform.Application.Contracts
{
    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
    }
}
