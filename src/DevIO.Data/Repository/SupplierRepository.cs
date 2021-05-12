using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(CustomDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Get Supplier and address by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns>A sigle supplier with corresponding address.</returns>
        public async Task<Supplier> GetSupplierAdress(Guid supplierId)
        {
            return await _db.Suppliers
                .AsNoTracking()
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == supplierId);
        }

        /// <summary>
        /// Get Supplier, address and products by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns>A sigle supplier with corresponding address and products.</returns>
        public async Task<Supplier> GetSupplierProductsAdress(Guid supplierId)
        {
            return await _db.Suppliers
               .AsNoTracking()
               .Include(s => s.Address)
               .Include(s => s.Products)
               .FirstOrDefaultAsync(s => s.Id == supplierId);
        }
    }
}
