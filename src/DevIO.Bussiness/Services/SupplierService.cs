using DevIO.Bussiness.Interfaces.Service;
using DevIO.Bussiness.Models;
using DevIO.Bussiness.Models.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        public async Task Create(Supplier supplier)
        {
            if (!await RunValidation(new SupplierValidation(), supplier)
                && !await RunValidation(new AddressValidation(), supplier.Address))
                return;
        }

        public async Task Update(Supplier supplier)
        {
            if (!await RunValidation(new SupplierValidation(), supplier))
                return;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!await RunValidation(new AddressValidation(), address))
                return;
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
