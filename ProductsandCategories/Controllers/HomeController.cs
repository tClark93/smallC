using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsandCategories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ProductsandCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
 
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewModel Views = new ViewModel()
            {
                Product = new Product(),
                AllProducts = _context.Product.ToList(),
                Category = new Category(),
                AllCategories = _context.Category.ToList(),
                Categorized = new Categorized(),
                AllPairs = new List<Categorized>()
            };
            return View(Views);
        }

        [HttpGet("product")]
        public IActionResult Product()
        {
            return View();
        }

        [HttpGet("category")]
        public IActionResult Category()
        {
            return View();
        }

        [HttpPost("addProduct")]
        public IActionResult addProduct(Product product)
        {
            System.Console.WriteLine(product.Name);
            System.Console.WriteLine(product.Description);
            System.Console.WriteLine(product.Price);
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*");
                _context.Product.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Product");
        }

        [HttpPost("addCategory")]
        public IActionResult addCategory(Category category)
        {
            System.Console.WriteLine(category.Name);
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*");
                _context.Category.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Category");
        }

        [HttpGet("product/{num}")]
        public IActionResult ProductID(int num)
        {
            Product product = _context.Product.SingleOrDefault(p =>p.id == num);
            ViewModel Views = new ViewModel()
            {
                Product = _context.Product.SingleOrDefault(p => p.id == num),
                AllProducts = _context.Product
                        .Include(p =>p.Categories)
                        .ThenInclude(g => g.Category)
                        .ToList(),
                Category = new Category(),
                AllCategories = _context.Category
                        .Include(c => c.CategorizedProducts)
                        .ThenInclude(p => p.Product)
                        .ToList(),
                Categorized = new Categorized(),
                AllPairs = _context.Categorized.ToList()
            };
            return View(Views);
        }

        [HttpGet("pair/product/{num}")]
        public IActionResult PairProduct(int num, ViewModel FormData)
        {
            Product product = _context.Product.SingleOrDefault(p =>p.id == num);
            Category category = _context.Category.SingleOrDefault(c => c.id == FormData.Category.id);
            Categorized pair = new Categorized()
            {
                    Productid = num,
                    Categoryid = FormData.Category.id,
                    Product = product,
                    Category = category
            };
            _context.Categorized.Add(pair);
            _context.SaveChanges();
            pair.Category.CategorizedProducts.Add(pair);
            _context.SaveChanges();
            pair.Product.Categories.Add(pair);
            _context.SaveChanges();

            return RedirectToAction("ProductID", new{num=num});
        }
    }
}
