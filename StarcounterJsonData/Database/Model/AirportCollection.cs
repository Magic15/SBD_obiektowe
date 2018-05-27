using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarcounterJsonData.Database.Model
{
    public class AirportCollection : StarcounterRelationCollection<Airport, Flight>
    {            
        public AirportCollection(Flight Flight) : base(Flight)
        {
        }

        protected override string GetSqlQuery()
        {
            return "SELECT c FROM StarcounterJsonData.Database.Model.Airport c WHERE c.Flight = ?";
        }

        protected override Flight GetSubject(Airport Entity)
        {
            return Entity.Flight;
        }

        protected override void RemoveSubject(Airport Entity)
        {
            Entity.Flight = null;
        }

        protected override void SetSubject(Airport Entity, Flight Subject)
        {
            Entity.Flight = Subject;
        }

    }
}
