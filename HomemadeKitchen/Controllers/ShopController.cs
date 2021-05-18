using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasualShop.Models;
using Microsoft.AspNetCore.Authorization;
using CasualShop.DAL.Repository;
using CasualShop.BLL;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Mvc.Rendering;
using CasualShop.BLL.DtoModels;

namespace CasualShop.Controllers
{
    //[Authorize]
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private DataManager _dataManager;
        private ServicesManager _serviceManager;

        public ShopController(ILogger<ShopController> logger, DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(dataManager);
        }

        public IActionResult Index(int page = 1)
        {
            //SelectList categorys = new SelectList(_serviceManager.Brands.GetBrandsList(), "Id", "Name");
            //ViewBag.Brands = categorys;
            //SelectList tags = new SelectList(_serviceManager.Tags.GetTagsList(), "Id", "Name");
            //ViewBag.Tags = tags;

            var _dishes = _serviceManager.Dishes.GetDishesList();
            var model = PagingList.Create(_dishes, 9, page);
            //var _dishes = _serviceManager.Clothes.GetClothesList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Index(int? category, int? tag, int page = 1)
        {
            List<CategoryDto> categorysList = _serviceManager.Categories.GetCategoriesList();
            categorysList.Insert(0, new CategoryDto { Name = "All", Id = 0 });
            SelectList categorys = new SelectList(categorysList, "Id", "Name");
            ViewBag.Brands = categorys;
            List<CategoryDto> categories = _serviceManager.Categories.GetCategoriesList();
            ViewBag.Categories = categories;

            List<TagDto> tagsList = _serviceManager.Tags.GetTagsList();
            tagsList.Insert(0, new TagDto { Name = "All", Id = 0 });
            SelectList tags = new SelectList(tagsList, "Id", "Name");
            ViewBag.Tags = tags;

            IEnumerable<DishesDto> dishes = _serviceManager.Dishes.GetDishesList();

            if (category != null && category != 0)
            {
                dishes = dishes.Where(c => c.DishesCategory.Id == category);
            }
            if (tag != null && tag != 0)
            {
                dishes = dishes.Where(c => c.Tag.Id == tag);
            }
            if (category != null && category != 0 && tag != null && tag != 0)
            {
                dishes = dishes.Where(c => c.DishesCategory.Id == category && c.Tag.Id == tag);
            }

            var model = PagingList.Create(dishes, 9, page);

            return View(model);
        }

        public IActionResult ClothesInfo(int id)
        {
            return View(_serviceManager.Dishes.GetDishesModelById(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
