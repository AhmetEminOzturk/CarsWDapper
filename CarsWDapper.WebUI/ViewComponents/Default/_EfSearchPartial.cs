using CarsWDapper.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarsWDapper.WebUI.ViewComponents.Default
{
    public class _EfSearchPartial : ViewComponent
    {
        private readonly IVehicleService _vehicleService;

        public _EfSearchPartial(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        
        public async Task<IViewComponentResult> InvokeAsync(string keyword)
        {
            var result = await _vehicleService.EFSearch(keyword);
            return View(result);
        }
    }
}
