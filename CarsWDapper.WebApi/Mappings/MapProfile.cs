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
            CreateMap<Vehicle, DisplayCaseTypeResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayBrandResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayCityNrResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayFuelResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayColorResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayShiftTypeResponse>().ReverseMap();
        }
    }
}
