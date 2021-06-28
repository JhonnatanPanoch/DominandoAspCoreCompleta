using DevIO.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces.Service
{
    public interface IProductService
    {
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
    }
}
