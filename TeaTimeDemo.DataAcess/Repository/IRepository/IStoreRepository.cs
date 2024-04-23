using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAcess.Repository.IRepository
{
    public interface IStoreRepository : IRepository<Store>
    {
        void Update(Store obj);
        //void Save();

    }
}
