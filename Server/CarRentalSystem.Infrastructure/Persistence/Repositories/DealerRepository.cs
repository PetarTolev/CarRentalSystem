namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using CarRentalSystem.Application.Features.Dealers;
    using CarRentalSystem.Domain.Models.Dealers;
    using System.Threading;
    using System.Threading.Tasks;

    internal class DealerRepository : DataRepository<Dealer>, IDealerRepository
    {
        public DealerRepository(CarRentalDbContext db)
            : base(db)
        {
        }

        public async Task Save(
            Dealer dealer, 
            CancellationToken cancellationToken = default)
        {
            this.Data.Add(dealer);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
