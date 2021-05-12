using DevIO.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        /// <summary>
        /// Get a list of products by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns>List of products with supplier model.</returns>
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);
        
        /// <summary>
        /// Gets a list of products and the supplier to that product.
        /// </summary>
        /// <param name="productId">Product id (pk).</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsSupplier();

        /// <summary>
        /// Gets a single product and the supplier to that product.
        /// </summary>
        /// <param name="productId">Product id (pk).</param>
        /// <returns></returns>
        Task<Product> GetProductSupplier(Guid productId);


    }
}
