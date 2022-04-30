namespace CarRentalSystem.Application.Features.Identity
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Features.Identity.Commands;
    using CarRentalSystem.Application.Features.Identity.Commands.ChangePassword;
    using CarRentalSystem.Application.Features.Identity.Commands.LoginUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInpur);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInputModel);
    }
}
