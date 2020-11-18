using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nohai_Dragos_Ionut_Lab2.Models;
using Microsoft.EntityFrameworkCore;
using LibraryModel.Data;
using LibraryModel.Models;
using Nohai_Dragos_Ionut_Lab2.Models.LibraryViewModels;

namespace Nohai_Dragos_Ionut_Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
         //   _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Orders
            group order by order.OrderDate into dateGroup
            select new OrderGroup()
            {
                OrderDate = dateGroup.Key,
                BookCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
