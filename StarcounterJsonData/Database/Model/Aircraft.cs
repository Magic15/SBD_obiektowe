using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
using StarcounterJsonData.Database.Model;

namespace StarcounterJsonData.Database.Model
{
    [Database]
    public class Aircraft
    {           
        public string Type { get; set; }
        public string Registration { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string Manufacturer { get; set; }
        public int Seats { get; set; }                
        public int FuelConsumption { get; set; }

        public PilotCollection Pilots
        {
            get
            {
                return new PilotCollection(this);
            }
        }

        public StewardessCollection Stewardesses
        {
            get
            {
                return new StewardessCollection(this);
            }
        }


        public FlightCollection Flights
        {
            get
            {
                return new FlightCollection(this);
            }
        }

        public int GetFuelPrice4AllFlights()
        {
            int distance = 0;
            foreach (Flight f in Flights)
            {
                distance += f.Distance;
            }

            int price = distance * this.FuelConsumption;

            return price;
        }

        public object ToJson()
        {
            return new
            {
               this.Type, this.Registration, this.Age, this.Role, this.Manufacturer, this.Seats, this.FuelConsumption,
               Pilots = this.Pilots.Select(x => x.ToJson()),
               Flights = this.Flights.Select(x => x.ToJson()),
               Stewardesses = this.Stewardesses.Select(x => x.ToJson())
            };
        }
    }
}
