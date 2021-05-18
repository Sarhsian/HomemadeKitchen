using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        void SaveCategories(Category category);
        void DeleteCategories(Category category);
    }
}
