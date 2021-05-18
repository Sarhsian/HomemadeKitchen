using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class DishesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public CategoryDto DishesCategory { get; set; }
        public TagDto Tag { get; set; }
        public string Description { get; set; }
        public ImageDto Image { get; set; }
    }

    public class DishesEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public CategoryEditDto DishesCategory { get; set; }
        public TagEditDto Tag { get; set; }
        public string Description { get; set; }
        public ImageDto Image { get; set; }
    }
}
