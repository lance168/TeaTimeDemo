using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAcess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        //void Save();

    }
}
