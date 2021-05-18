using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFDishesRepository : IDishesRepository
    {
        private EFDBContext context;

        public EFDishesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Dishes> GetAllDishes()
        {
            return context.Set<Dishes>().Include(x => x.Category).Include(x => x.Tag).Include(x => x.Image).ToList();
        }

        public Dishes GetDishesById(int dishesIdId)
        {
            return context.Set<Dishes>().Include(x => x.Category).Include(x => x.Tag).Include(x => x.Image).FirstOrDefault(x => x.Id == dishesIdId);
        }

        public void SaveDishes(Dishes dishes)
        {
            context.Entry(dishes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDishes(Dishes dishes)
        {
            context.Dishes.Remove(dishes);
            context.SaveChanges();
        }



    }
}
