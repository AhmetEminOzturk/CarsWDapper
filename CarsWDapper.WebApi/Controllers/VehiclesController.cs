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
