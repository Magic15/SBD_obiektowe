using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarcounterJsonData.Database.Model
{
    public class PilotCollection : StarcounterRelationCollection<Pilot, Aircraft>
    {
        public PilotCollection(Aircraft Aircraft) : base(Aircraft)
        {
        }

        protected override string GetSqlQuery()
        {
            return "SELECT c FROM StarcounterJsonData.Database.Model.Pilot c WHERE c.Aircraft = ?";
        }

        protected override Aircraft GetSubject(Pilot Entity)
        {
            return Entity.Aircraft;
        }

        protected override void RemoveSubject(Pilot Entity)
        {
            Entity.Aircraft = null;
        }

        protected override void SetSubject(Pilot Entity, Aircraft Subject)
        {
            Entity.Aircraft = Subject;
        }
    }          
}
