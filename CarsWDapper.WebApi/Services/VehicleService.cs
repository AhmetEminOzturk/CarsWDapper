using AutoMapper;
using CarsWDapper.WebApi.Context;
using CarsWDapper.WebApi.Dtos.Requests;
using CarsWDapper.WebApi.Dtos.Responses;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarsWDapper.WebApi.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dapperContext;

        public VehicleService(IConfiguration configuration, IMapper mapper, DapperContext dapperContext)
        {
            _configuration = configuration;
            _mapper = mapper;
            _dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            _dapperContext = dapperContext;
        }

        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DisplayVehicleResponse> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DisplayVehicleResponse>> TGetList()
        {
            throw new NotImplementedException();
        }

        public async Task TInsert(CreateVehicleRequest createVecihleRequest)
        {
            var status = await _dbConnection.ExecuteAsync("insert into Vehicles (CarId,Plate,LicenceDate,CityNr,Title,Brand,Model,Year_,Fuel,ShiftType,MotorVolume,MotorPower,Color,CaseType) Values (@CarId,@Plate,@LicenceDate,@CityNr,@Title,@Brand,@Model,@Year_,@Fuel,@ShiftType,@MotorVolume,@MotorPower,@Color,@CaseType)");
            var parameters = new DynamicParameters();
            parameters.Add("@CarId", createVecihleRequest.CarId);
            parameters.Add("@Plate", createVecihleRequest.Plate);
            parameters.Add("@LicenceDate", createVecihleRequest.LicenceDate);
            parameters.Add("@CitNr", createVecihleRequest.CityNr);
            parameters.Add("@Title", createVecihleRequest.Title);
            parameters.Add("@Brand", createVecihleRequest.Brand);
            parameters.Add("@Model", createVecihleRequest.Model);
            parameters.Add("@Year_", createVecihleRequest.Year_);
            parameters.Add("@Fuel", createVecihleRequest.Fuel);
            parameters.Add("@ShiftType", createVecihleRequest.ShiftType);
            parameters.Add("@MotorVolume", createVecihleRequest.MotorVolume);
            parameters.Add("@MotorPower", createVecihleRequest.MotorPower);
            parameters.Add("@Color", createVecihleRequest.Color);
            parameters.Add("@CaseType", createVecihleRequest.CaseType);
           
            
        }

        public Task TUpdate(UpdateVehicleRequest updateVehicleRequest)
        {
            throw new NotImplementedException();
        }
    }
}
