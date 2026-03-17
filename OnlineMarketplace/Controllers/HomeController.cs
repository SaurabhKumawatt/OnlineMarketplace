using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMarketplace.Data;
using OnlineMarketplace.Models;

namespace OnlineMarketplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search, int? categoryId, string? city)
        {
            // Categories for dropdown
            ViewBag.Categories = _context.Categories.ToList();

            var products = _context.Products
                .Include(p => p.Category)
                .AsQueryable();

            // Search by title
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Title.Contains(search));
                ViewBag.Search = search;
            }

            // Filter by category
            if (categoryId.HasValue && categoryId > 0)
            {
                products = products.Where(p => p.CategoryId == categoryId);
                ViewBag.SelectedCategory = categoryId;
            }

            // Filter by city
            if (!string.IsNullOrEmpty(city))
            {
                products = products.Where(p => p.City.Contains(city));
                ViewBag.City = city;
            }

            var result = await products
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();

            return View(result);
        }
    }
}