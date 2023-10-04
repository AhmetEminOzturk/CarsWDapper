using AutoMapper;
using CarsWDapper.WebUI.Context;
using CarsWDapper.WebUI.Dtos.Responses;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarsWDapper.WebUI.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly EfContext _efContext;
        private readonly IMapper _mapper;

        public VehicleService(EfContext efContext, IMapper mapper)
        {
            _efContext = efContext;
            _mapper = mapper;
        }

        public async Task<List<DisplayVehicleResponse>> EFSearch(string keyword)
        {
            var query = _efContext.Vehicles
            .Where(v => v.Brand.Contains(keyword) ||
                    v.Plate.Contains(keyword) ||
                    v.ShiftType.Contains(keyword) ||
                    v.Fuel.Contains(keyword) ||
                    v.CaseType.Contains(keyword) ||
                    v.Color.Contains(keyword));

            var result = await query.Select(v => _mapper.Map<DisplayVehicleResponse>(v)).AsNoTracking().ToListAsync();

            return result;

        }
    }
}
