using DevIO.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces.Service
{
    public interface ISupplierService
    {
        Task Create(Supplier supplier);
        Task Update(Supplier supplier);
        Task Delete(Guid id);
        Task UpdateAddress(Address address);
    }
}
