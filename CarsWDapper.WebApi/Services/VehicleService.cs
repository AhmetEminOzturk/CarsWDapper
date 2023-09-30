using AutoMapper;
using CarsWDapper.WebApi.Context;
using CarsWDapper.WebApi.Dtos.Requests;
using CarsWDapper.WebApi.Dtos.Responses;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

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

        public async Task TDelete(int id)
        {
            await _dbConnection.ExecuteAsync("delete from Vehicles where VehicleId=@VehicleId",new { VehicleId= id});
        }

        public async Task<List<DisplayVehicleResponse>> TGetById(int id)
        {
            var value = await _dbConnection.QueryAsync<DisplayVehicleResponse>("select * from Vehicles where VehicleId=@VehicleId", new { VehicleId = id });
            return (_mapper.Map<List<DisplayVehicleResponse>>(value));
        }

        public async Task<List<DisplayVehicleResponse>> TGetLeastPlates()
        {
            var values = await _dbConnection.QueryAsync<DisplayVehicleResponse>("SELECT TOP 5[CityNr] , Count(*) FROM Vehicles WHERE[CityNr] <> '0' GROUP BY[CityNr] Order BY COUNT(*) ASC");
            return (_mapper.Map<List<DisplayVehicleResponse>>(values));          
        }

        public async Task<List<DisplayVehicleResponse>> TGetList()
        {
            var values = await _dbConnection.QueryAsync<DisplayVehicleResponse>("select * from Vehicles");
            return (_mapper.Map<List<DisplayVehicleResponse>>(values));
        }

        public async Task<List<DisplayVehicleResponse>> TGetMostPopularPlates()
        {
            var values = await _dbConnection.QueryAsync<DisplayVehicleResponse>("SELECT TOP 5 [CityNr], COUNT(*) FROM Vehicles GROUP BY [CityNr] ORDER BY COUNT(*) DESC;");
            return (_mapper.Map<List<DisplayVehicleResponse>>(values));
        }

        public async Task TInsert(CreateVehicleRequest createVecihleRequest)
        {
             await _dbConnection.ExecuteAsync("insert into Vehicles (CarId,Plate,LicenceDate,CityNr,Title,Brand,Model,Year_,Fuel,ShiftType,MotorVolume,MotorPower,Color,CaseType) Values (@CarId,@Plate,@LicenceDate,@CityNr,@Title,@Brand,@Model,@Year_,@Fuel,@ShiftType,@MotorVolume,@MotorPower,@Color,@CaseType)", createVecihleRequest);                  
        }

        public async Task TUpdate(UpdateVehicleRequest updateVehicleRequest)
        {
            string sql= "update Vehicles set CarId=@CarId,Plate=@Plate,LicenceDate=@LicenceDate,CityNr=@CityNr,Title=@Title,Brand=@Brand,Model=@Model,Year_=@Year_,Fuel=@Fuel,ShiftType=@ShiftType,MotorVolume=@MotorVolume,MotorPower=@MotorPower,Color=@Color,CaseType=@CaseType where VehicleId=@VehicleId";

            var parameters = new DynamicParameters();
            parameters.Add("@VehicleId", updateVehicleRequest.VehicleId);
            parameters.Add("@CarId", updateVehicleRequest.CarId);
            parameters.Add("@CarId", updateVehicleRequest.CarId);
            parameters.Add("@Plate", updateVehicleRequest.Plate);
            parameters.Add("@LicenceDate", updateVehicleRequest.LicenceDate);
            parameters.Add("@CityNr", updateVehicleRequest.CityNr);
            parameters.Add("@Title", updateVehicleRequest.Title);
            parameters.Add("@Brand", updateVehicleRequest.Brand);
            parameters.Add("@Model", updateVehicleRequest.Model);
            parameters.Add("@Year_", updateVehicleRequest.Year_);
            parameters.Add("@Fuel", updateVehicleRequest.Fuel);
            parameters.Add("@ShiftType", updateVehicleRequest.ShiftType);
            parameters.Add("@MotorVolume", updateVehicleRequest.MotorVolume);
            parameters.Add("@MotorPower", updateVehicleRequest.MotorPower);
            parameters.Add("@Color", updateVehicleRequest.Color);
            parameters.Add("@CaseType", updateVehicleRequest.CaseType);

            await _dbConnection.ExecuteAsync(sql, parameters);
        }
    }
}
