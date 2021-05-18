using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface IDishesRepository
    {
        IEnumerable<Dishes> GetAllDishes();
        Dishes GetDishesById(int dishesId);
        void SaveDishes(Dishes dishes);
        void DeleteDishes(Dishes dishes);
    }
}
