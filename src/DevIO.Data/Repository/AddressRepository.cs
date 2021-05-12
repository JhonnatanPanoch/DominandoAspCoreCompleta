using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(CustomDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Gets the address of supplier by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns></returns>
        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await _db.Addresses
                .AsNoTracking()
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(s => s.Id == supplierId);
        }
    }
}
