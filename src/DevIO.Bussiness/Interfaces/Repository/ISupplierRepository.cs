using DevIO.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces.Repository
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        /// <summary>
        /// Get Supplier and address by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns>A sigle supplier with corresponding address.</returns>
        Task<Supplier> GetSupplierAdress(Guid supplierId);

        /// <summary>
        /// Get Supplier, address and products by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns>A sigle supplier with corresponding address and products.</returns>
        Task<Supplier> GetSupplierProductsAdress(Guid supplierId);
    }
}
