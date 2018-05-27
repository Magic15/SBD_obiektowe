using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarcounterJsonData.Database.Model
{
    public class StewardessCollection : StarcounterRelationCollection<Stewardess, Aircraft>
    {
        public StewardessCollection(Aircraft Aircraft) : base(Aircraft)
        {
        }

        protected override string GetSqlQuery()
        {
            return "SELECT c FROM StarcounterJsonData.Database.Model.Stewardess c WHERE c.Aircraft = ?";
        }

        protected override Aircraft GetSubject(Stewardess Entity)
        {
            return Entity.Aircraft;
        }

        protected override void RemoveSubject(Stewardess Entity)
        {
            Entity.Aircraft = null;
        }

        protected override void SetSubject(Stewardess Entity, Aircraft Subject)
        {
            Entity.Aircraft = Subject;
        }
    }
}
