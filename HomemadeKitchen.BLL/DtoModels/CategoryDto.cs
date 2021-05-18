using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class CategoryDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }
    }

    public class CategoryEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
