using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if(!context.Dishes.Any())
            {
                context.Tags.Add(new Entities.Tag() { Name = "Shoes" });
                context.Tags.Add(new Entities.Tag() { Name = "Shirt" });
                context.Tags.Add(new Entities.Tag() { Name = "Jeans" });
                context.Tags.Add(new Entities.Tag() { Name = "Leather" });
                context.Tags.Add(new Entities.Tag() { Name = "Soft" });
                context.SaveChanges();

                context.Categories.Add(new Entities.Category() { Name = "Gucci" });
                context.Categories.Add(new Entities.Category() { Name = "Nike" });
                context.Categories.Add(new Entities.Category() { Name = "Adidas" });
                context.Categories.Add(new Entities.Category() { Name = "Prada" });
                context.SaveChanges();

                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Original Nike Top 2020",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 2),
                    Description = "Red with white dno",
                    //Image
                    Price = 300,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 1)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Gucci flip flap",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 1),
                    Description = "Gucci flip flap nara nara nana",
                    //Image
                    Price = 1500,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 5)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Dishes.Add(new Entities.Dishes()
                {
                    Name = "Red evil selection",
                    Category = context.Categories.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.SaveChanges();

            }

        }
    }
}
