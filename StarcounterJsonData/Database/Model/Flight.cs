using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Starcounter;

namespace StarcounterJsonData.Database.Model
{
    [Database]
    public class Flight
    {
        public Aircraft Aircraft { get; set; }
        public string FlightStatus { get; set; }
        public string Departure { get; set; }
        public string DepartureDelay { get; set; }
        public string Arrival { get; set; }
        public string ArrivalDelay { get; set; }
        public string AvgFlightTime { get; set; }
        public int Distance { get; set; }

        public AirportCollection Airports
        {
            get
            {                
                return new AirportCollection(this);
            }
        }

        public int GetFuelCost()
        {
            int cost = 0;
            int fuelCost = Aircraft.FuelConsumption;
            cost = Distance * fuelCost;
            return cost;
        }
        public object ToJson()
        {
            return new
            {
                this.FlightStatus,  
                this.Departure,
                this.DepartureDelay,
                this.Arrival,
                this.ArrivalDelay,
                this.AvgFlightTime,
                this.Distance,
                Airports = this.Airports.Select(x => x.ToJson()),                                           
            };
        }
    }
}
