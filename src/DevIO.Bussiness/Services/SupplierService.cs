using DevIO.Bussiness.Interfaces;
using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Interfaces.Service;
using DevIO.Bussiness.Models;
using DevIO.Bussiness.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;

        public SupplierService(
            ISupplierRepository supplierRepository,
            IAddressRepository addressRepository,
            INotificator notificator) : base(notificator)
        {
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
        }

        public async Task Insert(Supplier supplier)
        {
            if (!await RunValidation(new SupplierValidation(_supplierRepository), supplier)
                || !await RunValidation(new AddressValidation(), supplier.Address))
                return;

            await _supplierRepository.Insert(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!await RunValidation(new SupplierValidation(_supplierRepository), supplier))
                return;

            await _supplierRepository.Update(supplier);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!await RunValidation(new AddressValidation(), address))
                return;

            await _addressRepository.Update(address);
        }

        public async Task Delete(Guid id)
        {
            bool hasProducts = _supplierRepository.GetSupplierProductsAdress(id).Result.Products.Any();
            if (hasProducts)
            {
                Notificar("O fornecedor possui produtos cadastrados.");
                return;
            }

            await _supplierRepository.Delete(id);
        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
            _supplierRepository?.Dispose();
        }
    }
}
