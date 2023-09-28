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
        Task<DisplayVehicleResponse> TGetById(int id);
    }
}
