using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarcounterJsonData.Database.Model
{
    public class FlightCollection : StarcounterRelationCollection<Flight, Aircraft>
    {
        public FlightCollection(Aircraft Aircraft) : base(Aircraft)
        {
        }

        protected override string GetSqlQuery()
        {
            return "SELECT c FROM StarcounterJsonData.Database.Model.Flight c WHERE c.Aircraft = ?";
        }

        protected override Aircraft GetSubject(Flight Entity)
        {
            return Entity.Aircraft;
        }

        protected override void RemoveSubject(Flight Entity)
        {
            Entity.Aircraft = null;
        }

        protected override void SetSubject(Flight Entity, Aircraft Subject)
        {
            Entity.Aircraft = Subject;
        }
    }
}
