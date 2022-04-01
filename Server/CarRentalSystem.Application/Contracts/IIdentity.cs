namespace CarRentalSystem.Application.Contracts
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Features.Identity;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel userInpur);
    }
}
