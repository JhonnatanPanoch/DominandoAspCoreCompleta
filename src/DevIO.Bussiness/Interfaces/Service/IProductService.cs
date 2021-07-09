using DevIO.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces.Service
{
    public interface IProductService : IDisposable
    {
        Task Insert(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
    }
}
