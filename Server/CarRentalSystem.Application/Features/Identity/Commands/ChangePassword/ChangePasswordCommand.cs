namespace CarRentalSystem.Application.Features.Identity.Commands.ChangePassword
{
    using CarRentalSystem.Application.Contracts;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangePasswordCommand : IRequest<Result>
    {
        public string CurrentPassword { get; set; } = default!;

        public string NewPassword { get; set; } = default!;

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IIdentity identity;

            public ChangePasswordCommandHandler(
                ICurrentUser currentUser,
                IIdentity identity)
            {
                this.currentUser = currentUser;
                this.identity = identity;
            }

            public Task<Result> Handle(
                ChangePasswordCommand request,
                CancellationToken cancellationToken)
                => this.identity.ChangePassword(new ChangePasswordInputModel(
                    this.currentUser.UserId,
                    request.CurrentPassword,
                    request.NewPassword));
        }
    }
}
