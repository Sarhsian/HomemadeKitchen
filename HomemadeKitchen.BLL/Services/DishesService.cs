using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class DishesService
    {
        private DataManager _dataManager;
        private CategoryService _categoryService;
        private ImageService _imageService;
        //private TagService _tagService;

        public DishesService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _categoryService = new CategoryService(dataManager);
            _imageService = new ImageService(dataManager);
        }

        public List<DishesDto> GetDishesList()
        {
            var _dishes = _dataManager.Dishes.GetAllDishes();
            List<DishesDto> _modelList = new List<DishesDto>();

            foreach (var item in _dishes)
            {
                _modelList.Add(GetDishesModelById(item.Id));
            }
            return _modelList;
        }

        public DishesDto GetDishesModelById(int dishesId)
        {
            var _dishes = _dataManager.Dishes.GetDishesById(dishesId);
            if (_dishes.Image == null)
            {
                return new DishesDto()
                {
                    Id = _dishes.Id,
                    Name = _dishes.Name,
                    DishesCategory = new CategoryDto() { Id = _dishes.Category.Id, Name = _dishes.Category.Name },
                    Description = _dishes.Description,
                    Price = _dishes.Price,
                    //Tag = new TagDto { Id = _dishes.Tag.Id, Name = _dishes.Tag.Name }
                };
            }
            else
            {
                return new DishesDto()
                {
                    Id = _dishes.Id,
                    Name = _dishes.Name,
                    DishesCategory = new CategoryDto() { Id = _dishes.Category.Id, Name = _dishes.Category.Name },
                    Description = _dishes.Description,
                    Price = _dishes.Price,
                    Image = new ImageDto() { Id = _dishes.Image.Id, Title = _dishes.Image.Title, ImageName = _dishes.Image.ImageName },
                    //Tag = new TagDto { Id = _dishes.Tag.Id, Name = _dishes.Tag.Name }
                };
            }
        }
        
        public DishesEditDto GetDishesEditDto(int dishesId = 0)
        {
            if (dishesId != 0)
            {
                var _dishesDb = _dataManager.Dishes.GetDishesById(dishesId);
                var _dishesEditDto = new DishesEditDto()
                {
                    Id = _dishesDb.Id,
                    DishesCategory = new CategoryEditDto
                    {
                        Id = _dishesDb.Category.Id,
                        Name = _dishesDb.Category.Name
                    },
                    Tag = new TagEditDto
                    {
                        Id = _dishesDb.Tag.Id,
                        Name = _dishesDb.Name
                    },
                    Description = _dishesDb.Description,
                    Image = new ImageDto
                    {
                        Id = _dishesDb.Image.Id,
                        Title = _dishesDb.Image.Title,
                        ImageName = _dishesDb.Image.ImageName
                    },
                    Name = _dishesDb.Name,
                    Price = _dishesDb.Price
                };
                return _dishesEditDto;
            }
            else { return new DishesEditDto() { }; }
        }

        public DishesDto SaveDishesEditDtoToDb(DishesEditDto dishesEditDto)
        {
            Dishes _dishesDbModel;
            if (dishesEditDto.Id != 0)
            {
                _dishesDbModel = _dataManager.Dishes.GetDishesById(dishesEditDto.Id);
            }
            else
            {
                _dishesDbModel = new Dishes();
            }
            _dishesDbModel.Name = dishesEditDto.Name;
            _dishesDbModel.Price = dishesEditDto.Price;
            _dishesDbModel.Image = new Image
            {
                Id = _dishesDbModel.Image.Id,
                Title = _dishesDbModel.Image.Title,
                ImageName = _dishesDbModel.Image.ImageName
            };
            _dishesDbModel.Description = dishesEditDto.Description;
            _dishesDbModel.Category = new Category
            {
                Id = dishesEditDto.DishesCategory.Id,
                Name = dishesEditDto.DishesCategory.Name
            };
            _dishesDbModel.Tag = new Tag
            {
                Id = dishesEditDto.Tag.Id,
                Name = dishesEditDto.Tag.Name
            };

            _dataManager.Dishes.SaveDishes(_dishesDbModel);

            return GetDishesModelById(_dishesDbModel.Id);
        }

        public DishesEditDto CreateDishesEditDto()
        {
            return new DishesEditDto() { };
        }



    }
}
