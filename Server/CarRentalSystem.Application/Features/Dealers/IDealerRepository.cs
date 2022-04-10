namespace CarRentalSystem.Application.Features.Dealers
{
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Domain.Models.Dealers;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDealerRepository : IRepository<Dealer>
    {
        Task Save(Dealer dealer, CancellationToken cancellationToken = default);
    }
}
