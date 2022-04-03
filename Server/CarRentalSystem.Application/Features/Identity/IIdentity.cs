namespace CarRentalSystem.Application.Features.Identity
{
    using CarRentalSystem.Application;
    using CarRentalSystem.Application.Features.Identity.Commands.LoginUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel userInpur);
    }
}
