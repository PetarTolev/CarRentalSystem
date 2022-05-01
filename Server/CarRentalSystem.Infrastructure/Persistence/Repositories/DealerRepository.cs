namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using AutoMapper;
    using CarRentalSystem.Application.Features.Dealers;
    using CarRentalSystem.Application.Features.Dealers.Queries.Details;
    using CarRentalSystem.Domain.Exceptions;
    using CarRentalSystem.Domain.Models.Dealers;
    using CarRentalSystem.Infrastructure.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    internal class DealerRepository : DataRepository<Dealer>, IDealerRepository
    {
        private readonly IMapper mapper;

        public DealerRepository(CarRentalDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public Task<Dealer> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, u => u.Dealer!, cancellationToken);

        public Task<int> GetDealerId(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, u => u.Dealer!.Id, cancellationToken);

        public async Task<DealerDetailsOutputModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .mapper
                .ProjectTo<DealerDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<bool> HasCarAd(
            int dealerId, 
            int carAdId, 
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(d => d.Id == dealerId)
                .AnyAsync(d => d.CarAds
                    .Any(ad => ad.Id == carAdId), cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var dealer = await this
               .Data
               .Users
               .Where(u => u.Id == userId)
               .Select(selector)
               .FirstOrDefaultAsync(cancellationToken);

            if (dealer == null)
            {
                throw new InvalidDealerException("This user is not a dealer.");
            }

            return dealer;
        }
    }
}
