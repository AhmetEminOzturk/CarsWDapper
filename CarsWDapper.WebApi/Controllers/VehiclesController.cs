using CarsWDapper.WebApi.Dtos.Requests;
using CarsWDapper.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsWDapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListVehicle()
        {
            var values = await _vehicleService.TGetList();
            return Ok(values);
        }
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Search(string keyword)
        {
            var values = await _vehicleService.TSearch(keyword);
            return Ok(values);
        }
        [HttpGet ("[controller]/[action]")]
        public async Task<IActionResult> GetMostPopularPlates()
        {
            var values = await _vehicleService.TGetMostPopularPlates();
            return Ok(values);
        }
        [HttpGet ("[controller]/[action]")]
        public async Task<IActionResult> GetLeastPlates()
        {
            var values = await _vehicleService.TGetLeastPlates();
            return Ok(values);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetMostPopularBrands()
        {
            var values = await _vehicleService.TGetMostPopularBrands();
            return Ok(values);
        }
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetLeastBrands()
        {
            var values = await _vehicleService.TGetLeastBrands();
            return Ok(values);
        }
        
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetMostPopularShiftType()
        {
            var values = await _vehicleService.TGetMostPopularShiftType();
            return Ok(values);
        }
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetLeastShiftType()
        {
            var values = await _vehicleService.TGetLeastShiftType();
            return Ok(values);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetMostPopularFuel()
        {
            var values = await _vehicleService.TGetMostPopularFuel();
            return Ok(values);
        }
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetLeastFuel()
        {
            var values = await _vehicleService.TGetLeastFuel();
            return Ok(values);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetMostPopularCaseType()
        {
            var values = await _vehicleService.TGetMostPopularCaseType();
            return Ok(values);
        }
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetLeastCaseType()
        {
            var values = await _vehicleService.TGetLeastCaseType();
            return Ok(values);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetMostPopularColor()
        {
            var values = await _vehicleService.TGetMostPopularColor();
            return Ok(values);
        }
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetLeastColor()
        {
            var values = await _vehicleService.TGetLeastColor();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var values = await _vehicleService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleRequest createVehicleRequest)
        {
            await _vehicleService.TInsert(createVehicleRequest);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleRequest updateVehicleRequest)
        {
            await _vehicleService.TUpdate(updateVehicleRequest);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleService.TDelete(id);
            return Ok();
        }
       
    }
}
