using AutoMapper;
using CarsWDapper.WebUI.Dtos.Responses;
using CarsWDapper.WebUI.Models;

namespace CarsWDapper.WebUI.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Vehicle, DisplayVehicleResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayCaseTypeResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayBrandResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayCityNrResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayFuelResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayColorResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayShiftTypeResponse>().ReverseMap();
            CreateMap<Vehicle, DisplayCityNrResponse>().ReverseMap();

            
        }
    }
}
