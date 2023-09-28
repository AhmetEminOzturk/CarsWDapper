using AutoMapper;
using CarsWDapper.WebApi.Dtos.Requests;
using CarsWDapper.WebApi.Dtos.Responses;
using CarsWDapper.WebApi.Models;

namespace CarsWDapper.WebApi.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Vehicle, CreateVehicleRequest>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleRequest>().ReverseMap();
            CreateMap<Vehicle, DisplayVehicleResponse>().ReverseMap();
        }
    }
}
