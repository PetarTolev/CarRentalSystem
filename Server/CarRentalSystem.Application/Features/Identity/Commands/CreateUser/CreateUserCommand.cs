namespace CarRentalSystem.Application.Features.Identity.Commands.RegisterUser
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Features.Dealers;
    using CarRentalSystem.Application.Features.Identity.Commands;
    using CarRentalSystem.Domain.Factories.Dealers;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public CreateUserCommand(string email, string password, string name, string phoneNumber)
            : base(email, password)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; }

        public string PhoneNumber { get; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IDealerFactory dealerFactory;
            private readonly IDealerRepository dealerRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IDealerFactory dealerFactory,
                IDealerRepository dealerRepository)
            {
                this.identity = identity;
                this.dealerFactory = dealerFactory;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var dealer = this.dealerFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                user.BecomeDealer(dealer);

                await this.dealerRepository.Save(dealer, cancellationToken);

                return result;
            }
        }
    }
}
