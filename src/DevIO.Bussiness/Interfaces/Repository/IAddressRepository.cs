using DevIO.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces.Repository
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        /// <summary>
        /// Gets the address of supplier by supplier id.
        /// </summary>
        /// <param name="supplierId">Supplier id (PK).</param>
        /// <returns></returns>
        Task<Address> GetAddressBySupplier(Guid supplierId);
    }
}
