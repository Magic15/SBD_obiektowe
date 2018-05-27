using System;
using Starcounter;

namespace StarcounterJsonData.Database.Model
{
    public class AircraftCollection : StarcounterCollection<Aircraft>
    {
        protected override string GetSqlQuery()
        {
            return "SELECT b FROM StarcounterJsonData.Database.Model.Aircraft b";
        }
    }
}
