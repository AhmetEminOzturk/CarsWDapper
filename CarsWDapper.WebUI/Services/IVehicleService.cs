using CarsWDapper.WebUI.Dtos.Responses;

namespace CarsWDapper.WebUI.Services
{
    public interface IVehicleService
    {
        Task<List<DisplayVehicleResponse>> EFSearch(string keyword);
    }
}
