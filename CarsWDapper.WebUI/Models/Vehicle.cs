﻿namespace CarsWDapper.WebUI.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int? CarId { get; set; }
        public string? Plate { get; set; }
        public DateTime? LicenceDate { get; set; }
        public int? CityNr { get; set; }
        public string? Title { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Year_ { get; set; }
        public string? Fuel { get; set; }
        public string? ShiftType { get; set; }
        public string? MotorVolume { get; set; }
        public string? MotorPower { get; set; }
        public string? Color { get; set; }
        public string? CaseType { get; set; }
    }
}
