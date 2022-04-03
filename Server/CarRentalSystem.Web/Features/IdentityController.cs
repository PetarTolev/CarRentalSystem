namespace CarRentalSystem.Web.Features
{
    using CarRentalSystem.Application.Features.Identity;
    using CarRentalSystem.Application.Features.Identity.Commands.LoginUser;
    using CarRentalSystem.Application.Features.Identity.Commands.RegisterUser;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(CreateUserCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
            => await this.Send(command);
    }
}
