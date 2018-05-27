using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace StarcounterJsonData.Database.Model
{
    public class Stewardess : Person
    {
        public Aircraft Aircraft { get; set; }
    
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
                this.Country
            };
        }
    }
}
