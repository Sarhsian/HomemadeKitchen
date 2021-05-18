using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository
{
    public class DataManager
    {
        private readonly IDishesRepository _dishesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IBasketsRepository _basketsRepository;
        private readonly IImagesRepository _imagesRepository;
        private readonly IOrderInfoRepository _orderInfoRepository;

        public DataManager(IDishesRepository dishesRepository, 
            ITagsRepository tagsRepository, 
            ICategoriesRepository categoriesRepository,
            IBasketsRepository basketsRepository,
            IImagesRepository imagesRepository,
            IOrderInfoRepository orderInfoRepository)
        {
            _dishesRepository = dishesRepository;
            _categoriesRepository = categoriesRepository;
            _tagsRepository = tagsRepository;
            _basketsRepository = basketsRepository;
            _imagesRepository = imagesRepository;
            _orderInfoRepository = orderInfoRepository;

        }

        public IDishesRepository Dishes { get { return _dishesRepository; } }
        public ICategoriesRepository Categories { get { return _categoriesRepository; } }
        public ITagsRepository Tags { get { return _tagsRepository; } }
        public IBasketsRepository Baskets { get { return _basketsRepository; } }
        public IImagesRepository Images { get { return _imagesRepository; } }
        public IOrderInfoRepository OrderInfos { get { return _orderInfoRepository; } }

    }
}
