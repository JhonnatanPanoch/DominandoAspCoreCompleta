using DevIO.Bussiness.Interfaces.Service;
using DevIO.Bussiness.Models;
using DevIO.Bussiness.Models.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Services
{
    public class ProductService : BaseService, IProductService
    {
        public async Task Create(Product product)
        {
            if (!await RunValidation(new ProductValidation(), product))
                return;
        }

        public async Task Update(Product product)
        {
            if (!await RunValidation(new ProductValidation(), product))
                return;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
