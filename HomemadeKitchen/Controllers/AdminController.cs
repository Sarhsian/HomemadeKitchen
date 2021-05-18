using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasualShop.DAL;
using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CasualShop.Areas.Identity.Data;

namespace CasualShop.Controllers
{    
    public class AdminController : Controller
    {
        private readonly EFDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private UserManager<CasualShopUser> _userManager;
        string adminId;

        public AdminController(EFDBContext context,
            IWebHostEnvironment hostEnvironment,
            UserManager<CasualShopUser> userManager)
        {
            adminId = "a121b06b-064d-4fe5-9c2d-9647efa12bd7";
            _userManager = userManager;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
       
        public IActionResult Permission()
        {
            return Content("You don't have permission");
        }
        public async Task<IActionResult> Index()
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                var dishes = _context.Dishes.Include(b => b.Category).Include(t => t.Tag).Include(i => i.Image);
                return View(await dishes.ToListAsync());
            }
            else return Permission();
        }
       
        public async Task<IActionResult> Details(int? id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var dishes = await _context.Dishes.Include(b => b.Category).Include(t => t.Tag).Include(i => i.Image)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (dishes == null)
                {
                    return NotFound();
                }

                return View(dishes);
            }
            else return Permission();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                //list of commands for sending to view
                SelectList brands = new SelectList(_context.Categories, "Id", "Name");
                ViewBag.Brands = brands;
                SelectList tags = new SelectList(_context.Tags, "Id", "Name");
                ViewBag.Tags = tags;

                return View();
            }
            else return Permission();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dishes dishes)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (ModelState.IsValid)
                {
                    //save image to wwwroot/Image
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(dishes.Image.ImageFile.FileName);
                    string extention = Path.GetExtension(dishes.Image.ImageFile.FileName);
                    dishes.Image.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await dishes.Image.ImageFile.CopyToAsync(fileStream);
                    }

                    Image img = new Image
                    {
                        ImageName = dishes.Image.ImageName,
                        Title = dishes.Image.Title
                    };

                    await _context.Images.AddAsync(img);
                    await _context.SaveChangesAsync();

                    dishes.Image = null;
                    dishes.ImageId = _context.Images.FirstOrDefault(i => i.ImageName == img.ImageName).Id;

                    await _context.Dishes.AddAsync(dishes);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            else return Permission();
        }        

        public async Task<IActionResult> Edit(int? id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Dishes dishes = await _context.Dishes.Include(i => i.Image).FirstOrDefaultAsync(i => i.Id == id);
                if (dishes != null)
                {
                    SelectList brands = new SelectList(_context.Categories, "Id", "Name", dishes.CategoryId);
                    ViewBag.Brands = brands;
                    SelectList tags = new SelectList(_context.Tags, "Id", "Name", dishes.TagId);
                    ViewBag.Tags = tags;

                    return View(dishes);
                }
                return RedirectToAction("Index");
            }
            else return Permission();
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Dishes dishes, int imgId)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                //if (ModelState.IsValid)
                //{
                if (dishes.Image.ImageFile != null)
                {

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(dishes.Image.ImageFile.FileName);
                    string extention = Path.GetExtension(dishes.Image.ImageFile.FileName);
                    dishes.Image.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await dishes.Image.ImageFile.CopyToAsync(fileStream);
                    }

                    Image img = new Image
                    {
                        ImageName = dishes.Image.ImageName,
                        Title = dishes.Image.Title
                    };

                    await _context.Images.AddAsync(img);
                    await _context.SaveChangesAsync();

                    dishes.Image = null;
                    dishes.ImageId = _context.Images.FirstOrDefault(i => i.ImageName == img.ImageName).Id;
                    _context.Entry(dishes).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    dishes.ImageId = imgId;
                    _context.Entry(dishes).State = EntityState.Modified;
                    //_context.Add(dishes);
                    await _context.SaveChangesAsync();
                }
                //}

                //_context.Entry(dishes).State = EntityState.Modified;
                //await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return Permission();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var dishes = await _context.Dishes
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (dishes == null)
                {
                    return NotFound();
                }

                return View(dishes);
            }
            else return Permission();
        }
        
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_userManager.GetUserId(User) == adminId)
            {
                var dishes = await _context.Dishes.FindAsync(id);
                if (dishes.ImageId != null)
                {
                    var image = await _context.Images.FindAsync(dishes.ImageId);
                    //delete image from wwwroot/image
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", image.ImageName);
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                    //delete the record
                    _context.Images.Remove(image);
                }
                _context.Dishes.Remove(dishes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return Permission();
        }
       
        private bool DishesExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
