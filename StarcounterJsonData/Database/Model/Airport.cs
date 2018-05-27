using System.Collections;
using Starcounter;

namespace StarcounterJsonData.Database.Model
{
    [Database]
    public class Airport
    {
        public Flight Flight { get; set; }        
        public string Designation { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public int Passengers { get; set; }
        public string Destination { get; set; }

        public object ToJson()
        {
            return new
            {
               this.Designation, this.Type, this.Country, this.Passengers, this.Destination      
            };
        }
    }
}
