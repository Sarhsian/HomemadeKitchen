using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFCategoriesRepository : ICategoriesRepository
    {
        private EFDBContext context;

        public EFCategoriesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteCategories(Category brand)
        {
            context.Categories.Remove(brand);
            context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryById(int brandId)
        {
            return context.Categories.FirstOrDefault(x => x.Id == brandId);
        }

        public void SaveCategories(Category brands)
        {
            context.Entry(brands).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
