namespace CarRentalSystem.Application.Features.Identity.Commands.ChangePassword
{
    public class ChangePasswordInputModel
    {
        internal ChangePasswordInputModel(
            string userId,
            string currentPassword,
            string newPassword)
        {
            this.UserId = userId;
            this.CurrentPassword = currentPassword;
            this.NewPassword = newPassword;
        }
        public string UserId { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
