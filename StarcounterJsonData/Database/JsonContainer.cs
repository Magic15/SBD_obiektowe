using System;
using System.Linq;
using Starcounter;
using StarcounterJsonData.Database.Model;

namespace StarcounterJsonData.Database
{
    public class JsonContainer
    {
        public JsonContainer()
        {            
            this.Aircrafts = new AircraftCollection();          
        }      
        public AircraftCollection Aircrafts { get; protected set; }

        public object ToJson()
        {
            return new
            {                
                Aircrafts = this.Aircrafts.Select(x => x.ToJson())
            };
        }
    }
}
