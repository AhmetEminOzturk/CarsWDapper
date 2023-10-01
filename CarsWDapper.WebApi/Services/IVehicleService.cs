using CarsWDapper.WebApi.Dtos.Requests;
using CarsWDapper.WebApi.Dtos.Responses;

namespace CarsWDapper.WebApi.Services
{
    public interface IVehicleService
    {
        Task TInsert(CreateVehicleRequest createVecihleRequest);
        Task TDelete(int id);
        Task TUpdate(UpdateVehicleRequest updateVehicleRequest);
        Task<List<DisplayVehicleResponse>> TGetList();
        Task<List<DisplayCityNrResponse>> TGetMostPopularPlates();
        Task<List<DisplayCityNrResponse>> TGetLeastPlates();
        Task<List<DisplayBrandResponse>> TGetMostPopularBrands();
        Task<List<DisplayBrandResponse>> TGetLeastBrands();
        Task<List<DisplayShiftTypeResponse>> TGetMostPopularShiftType();
        Task<List<DisplayShiftTypeResponse>> TGetLeastShiftType();
        Task<List<DisplayFuelResponse>> TGetMostPopularFuel();
        Task<List<DisplayFuelResponse>> TGetLeastFuel();
        Task<List<DisplayCaseTypeResponse>> TGetMostPopularCaseType();
        Task<List<DisplayCaseTypeResponse>> TGetLeastCaseType();
        Task<List<DisplayColorResponse>> TGetMostPopularColor();
        Task<List<DisplayColorResponse>> TGetLeastColor();
        Task<List<DisplayVehicleResponse>> TGetById(int id);
    }
}
