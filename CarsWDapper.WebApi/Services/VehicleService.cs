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

        public async Task<List<DisplayBrandResponse>> TGetLeastBrands()
        {
            var values = await _dbConnection.QueryAsync<DisplayBrandResponse>("SELECT TOP 5 [Brand] , Count(*) as Count FROM Vehicles WHERE [Brand] <> 'string' GROUP BY [Brand] Order BY Count ASC;");
            return (_mapper.Map<List<DisplayBrandResponse>>(values));
        }

        public async Task<List<DisplayCaseTypeResponse>> TGetLeastCaseType()
        {
            var values = await _dbConnection.QueryAsync<DisplayCaseTypeResponse>("SELECT TOP 1 [CaseType] , Count(*) FROM Vehicles WHERE [CaseType] <> 'string' GROUP BY [CaseType] Order BY COUNT(*) ASC;");
            return (_mapper.Map<List<DisplayCaseTypeResponse>>(values));
        }

        public async Task<List<DisplayColorResponse>> TGetLeastColor()
        {
            var values = await _dbConnection.QueryAsync<DisplayColorResponse>("SELECT TOP 1 [Color] , Count(*) FROM Vehicles WHERE [Color] <> 'string' GROUP BY [Color] Order BY COUNT(*) ASC;");
            return (_mapper.Map<List<DisplayColorResponse>>(values));
        }

        public async Task<List<DisplayFuelResponse>> TGetLeastFuel()
        {
            var values = await _dbConnection.QueryAsync<DisplayFuelResponse>("SELECT TOP 1 [Fuel] , Count(*) FROM Vehicles WHERE [Fuel] <> 'string' GROUP BY [Fuel] Order BY COUNT(*) ASC;");
            return (_mapper.Map<List<DisplayFuelResponse>>(values));
        }

        public async Task<List<DisplayCityNrResponse>> TGetLeastPlates()
        {
            var values = await _dbConnection.QueryAsync<DisplayCityNrResponse>("SELECT TOP 5[CityNr] , Count(*) as Count FROM Vehicles WHERE[CityNr] <> '0' GROUP BY[CityNr] Order BY Count ASC");
            return (_mapper.Map<List<DisplayCityNrResponse>>(values));
        }

        public async Task<List<DisplayShiftTypeResponse>> TGetLeastShiftType()
        {
            var values = await _dbConnection.QueryAsync<DisplayShiftTypeResponse>("SELECT TOP 1 [ShiftType] , Count(*) FROM Vehicles WHERE [ShiftType] <> 'string' GROUP BY [ShiftType] Order BY COUNT(*) ASC;");
            return (_mapper.Map<List<DisplayShiftTypeResponse>>(values));
        }

        public async Task<List<DisplayVehicleResponse>> TGetList()
        {
            var values = await _dbConnection.QueryAsync<DisplayVehicleResponse>("select * from Vehicles");
            return (_mapper.Map<List<DisplayVehicleResponse>>(values));
        }

        public async Task<List<DisplayBrandResponse>> TGetMostPopularBrands()
        {
            var values = await _dbConnection.QueryAsync<DisplayBrandResponse>("SELECT TOP 9 [Brand], COUNT(*) as Count FROM Vehicles GROUP BY [Brand] ORDER BY Count DESC;");
            return (_mapper.Map<List<DisplayBrandResponse>>(values));
        }

        public async Task<List<DisplayCaseTypeResponse>> TGetMostPopularCaseType()
        {
            var values = await _dbConnection.QueryAsync<DisplayCaseTypeResponse>("SELECT TOP 1 [CaseType], COUNT(*) FROM Vehicles WHERE [CaseType] <> 'string' GROUP BY [CaseType] ORDER BY COUNT(*) DESC;");
            return (_mapper.Map<List<DisplayCaseTypeResponse>>(values));
        }

        public async Task<List<DisplayColorResponse>> TGetMostPopularColor()
        {
            var values = await _dbConnection.QueryAsync<DisplayColorResponse>("SELECT TOP 1 [Color], COUNT(*) FROM Vehicles WHERE [Color] <> 'string' GROUP BY [Color] ORDER BY COUNT(*) DESC;;");
            return (_mapper.Map<List<DisplayColorResponse>>(values));
        }

        public async Task<List<DisplayFuelResponse>> TGetMostPopularFuel()
        {
            var values = await _dbConnection.QueryAsync<DisplayFuelResponse>("SELECT TOP 1 [Fuel], COUNT(*) FROM Vehicles WHERE [Fuel] <> 'string' GROUP BY [Fuel] ORDER BY COUNT(*) DESC;");
            return (_mapper.Map<List<DisplayFuelResponse>>(values));
        }

        public async Task<List<DisplayCityNrResponse>> TGetMostPopularPlates()
        {
            var values = await _dbConnection.QueryAsync<DisplayCityNrResponse>("SELECT TOP 5 [CityNr], COUNT(*) as Count FROM Vehicles GROUP BY [CityNr] ORDER BY Count DESC;");
            return (_mapper.Map<List<DisplayCityNrResponse>>(values));
        }

        public async Task<List<DisplayShiftTypeResponse>> TGetMostPopularShiftType()
        {
            var values = await _dbConnection.QueryAsync<DisplayShiftTypeResponse>("SELECT TOP 1 [ShiftType], COUNT(*) FROM Vehicles GROUP BY [ShiftType] ORDER BY COUNT(*) DESC;");
            return (_mapper.Map<List<DisplayShiftTypeResponse>>(values));
        }

        public async Task TInsert(CreateVehicleRequest createVecihleRequest)
        {
             await _dbConnection.ExecuteAsync("insert into Vehicles (CarId,Plate,LicenceDate,CityNr,Title,Brand,Model,Year_,Fuel,ShiftType,MotorVolume,MotorPower,Color,CaseType) Values (@CarId,@Plate,@LicenceDate,@CityNr,@Title,@Brand,@Model,@Year_,@Fuel,@ShiftType,@MotorVolume,@MotorPower,@Color,@CaseType)", createVecihleRequest);                  
        }

        public async Task<List<DisplayVehicleResponse>> TSearch(string keyword)
        {
            // You can construct your SQL query here, searching for the keyword in relevant columns.
            // For example, searching in the 'Title' and 'Brand' columns.
            string sql = @"SELECT TOP 10 * FROM Vehicles WHERE Title LIKE @Keyword 
                                                           OR Brand LIKE @Keyword
                                                           OR Plate LIKE @Keyword
                                                           OR CityNr LIKE @Keyword 
                                                           OR ShiftType LIKE @Keyword 
                                                           OR Fuel LIKE @Keyword 
                                                           OR CaseType LIKE @Keyword 
                                                           OR Color LIKE @Keyword";


            // Define the parameters for your query.
            var parameters = new DynamicParameters();
            parameters.Add("@Keyword", "%" + keyword + "%"); // Add '%' to search for partial matches.

            // Execute the query.
            var values = await _dbConnection.QueryAsync<DisplayVehicleResponse>(sql, parameters);

            return _mapper.Map<List<DisplayVehicleResponse>>(values);
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
