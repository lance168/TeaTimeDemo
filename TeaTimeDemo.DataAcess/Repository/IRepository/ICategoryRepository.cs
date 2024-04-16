﻿using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAcess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        //void Save();

    }
}
