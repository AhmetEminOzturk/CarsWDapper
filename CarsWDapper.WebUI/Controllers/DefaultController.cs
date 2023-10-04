using CarsWDapper.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing.Printing;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Diagnostics;

namespace CarsWDapper.WebUI.Controllers
{
    public class DefaultController : Controller
    {     
        private readonly IVehicleService _vehicleService;

        public DefaultController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        
        public async Task<IActionResult> Index(string keyword, int page = 1, int pageSize = 5)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = await _vehicleService.EFSearch(keyword);
            var totalCount = result.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = totalPages;
            }

            var startIndex = (page - 1) * pageSize;
            var pagedResult = result.Skip(startIndex).Take(pageSize).ToList();

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            ViewBag.timeSpanEf = elapsed.Milliseconds.ToString();

            ViewBag.Keyword = keyword;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
            

            return View(pagedResult);
        }


    }
}
