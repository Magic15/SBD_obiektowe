using System.Runtime.CompilerServices;
using Starcounter;

namespace StarcounterJsonData.Database.Model
{
    public class Pilot : Person
    {                
        public Aircraft Aircraft { get; set; }         
        public string Experience { get; set; }

        public int GetTotalFlightsNumber()
        {
            return Aircraft.Flights.Count;
        }

        public object ToJson()
        {
            return new
            {
                this.FirstName,
                this.Surname,
                this.Age,
                this.Country,                
                this.Experience                              
            };
        }
    }
}
