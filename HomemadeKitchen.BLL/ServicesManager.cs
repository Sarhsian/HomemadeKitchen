using CasualShop.BLL.Services;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private DishesService _dishesService;
        private TagService _tagService;
        private CategoryService _categoryService;
        private BasketService _basketService;
        private ImageService _imageService;
        private OrderInfoService _orderInfoService;
        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
            _categoryService = new CategoryService(_dataManager);
            _tagService = new TagService(_dataManager);
            _dishesService = new DishesService(_dataManager);
            _basketService = new BasketService(_dataManager);
            _imageService = new ImageService(_dataManager);
            _orderInfoService = new OrderInfoService(_dataManager);
        }
        public CategoryService Categories { get { return _categoryService; } }
        public DishesService Dishes { get { return _dishesService; } }
        public BasketService Baskets { get { return _basketService; } }
        public ImageService Images { get; set; }
        public TagService Tags { get { return _tagService; } }
        public OrderInfoService OrderInfos { get { return _orderInfoService; } }
    }
}
