using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CustomDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Get a list of products by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns>List of products with supplier model.</returns>
        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await List(p => p.SupplierId == supplierId);
        }

        /// <summary>
        /// Gets a list of products and the supplier to that product.
        /// </summary>
        /// <param name="productId">Product id (pk).</param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductsSupplier()
        {
            return await _db.Products
                .AsNoTracking()
                .Include(p => p.Supplier)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Gets a single product and the supplier to that product.
        /// </summary>
        /// <param name="productId">Product id (pk).</param>
        public async Task<Product> GetProductSupplier(Guid productId)
        {
            return await _db.Products
                .AsNoTracking()
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(s => s.Id == productId);
        }
    }
}
