using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Usey.Models;
using System;
using System.Diagnostics;
using System.Linq;
using Usey.Data;

namespace Usey.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Index()
        {
            var currentDate = DateTime.Now;
            var nextMonth = currentDate.AddMonths(1);

            var products = _context.Products
                .Where(p => p.ExpirationDate >= currentDate && p.ExpirationDate <= nextMonth)
                .ToList();

            var dashboardViewModel = new DashboardViewModel
            {
                TotalProducts = _context.Products.Count(),
                ExpiringProducts = products
            };

            return View(dashboardViewModel);
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
