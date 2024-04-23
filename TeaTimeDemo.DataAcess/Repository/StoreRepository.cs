using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAcess.Data;
using TeaTimeDemo.DataAcess.Repository.IRepository;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAcess.Repository
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private ApplicationDbContext _db;
        public StoreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //   _db.SaveChanges();
        //}

        public void Update(Store obj)
        {
           _db.Stores.Update(obj);
        }
    }
}
