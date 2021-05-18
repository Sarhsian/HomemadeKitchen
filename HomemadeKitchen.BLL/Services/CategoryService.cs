using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class CategoryService
    {
        private DataManager _dataManager;
        public CategoryService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<CategoryDto> GetCategoriesList()
        {
            var _categories = _dataManager.Categories.GetAllCategories();
            List<CategoryDto> _modelsList = new List<CategoryDto>();
            foreach (var item in _categories)
            {
                _modelsList.Add(CategoryDBToViewModelById(item.Id));
            }
            return _modelsList;
        }


        public CategoryDto CategoryDBToViewModelById(int categoryId)
        {
            var _categories = _dataManager.Categories.GetCategoryById(categoryId);

            return new CategoryDto() {
                Id = _categories.Id,
                Name = _categories.Name
            };
        }
    }
}
