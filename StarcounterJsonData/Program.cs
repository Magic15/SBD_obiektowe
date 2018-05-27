using System;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Starcounter;
using StarcounterJsonData.Database;
using StarcounterJsonData.Database.Model;

namespace StarcounterJsonData
{
    class Program
    {
    
        static void Main()
        {
           
            Handle.GET("/StarcounterJsonData/Import", () =>
            {
                string path = Path.Combine(Application.Current.WorkingDirectory, "wwwroot", "Data2.json");

                string json = null;
                using (TextReader reader = new StreamReader(path, true))
                {
                    try
                    {
                        json = reader.ReadToEnd();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }                    
                }
                             
                                
                return "data import successful";
            });

            Handle.GET("/StarcounterJsonData/Pilot", () =>
            {
                string path = Path.Combine(Application.Current.WorkingDirectory, "wwwroot", "Data2.json");
                string strOutput = "";                
                try
                {                    
                    var pilots = Db.SQL<Pilot>("SELECT p FROM StarcounterJsonData.Database.Model.Pilot p");                    
                    foreach(Pilot p in pilots)
                    {
                        strOutput += String.Format("{0}, Total flights number: {1}\n", p.GetFullName(), p.GetTotalFlightsNumber());                        
                    }
                }
                catch (SqlException exception)
                {
                    Console.WriteLine("Incorrect query: " + exception.Message);
                }
                return strOutput;
            });

            Handle.GET("/StarcounterJsonData/Stewardess", () =>
            {
                string path = Path.Combine(Application.Current.WorkingDirectory, "wwwroot", "Data2.json");
                string strOutput = "";
                try
                {
                    var stewardessses = Db.SQL<Stewardess>("SELECT p FROM StarcounterJsonData.Database.Model.Stewardess p");
                    foreach (Stewardess s in stewardessses)
                    {
                        strOutput += String.Format("{0}, Age: {1}, Total flights number: {2}\n", s.GetFullName(), s.Age, s.GetTotalFlightsNumber());
                    }
                }
                catch (SqlException exception)
                {
                    Console.WriteLine("Incorrect query: " + exception.Message);
                }
                return strOutput;
            });

            Handle.GET("/StarcounterJsonData/Flight", () =>
            {
                string path = Path.Combine(Application.Current.WorkingDirectory, "wwwroot", "Data2.json");
                string strOutput = "";
                try
                {
                    var flights = Db.SQL<Flight>("SELECT p FROM StarcounterJsonData.Database.Model.Flight p");
                    foreach (Flight f in flights)
                    {
                        strOutput += String.Format("Distance cost: {0}\n", f.GetFuelCost());
                    }
                }
                catch (SqlException exception)
                {
                    Console.WriteLine("Incorrect query: " + exception.Message);
                }
                return strOutput;
            });


            Handle.GET("/StarcounterJsonData/Aircraft", () =>
            {
                string path = Path.Combine(Application.Current.WorkingDirectory, "wwwroot", "Data2.json");
                string strOutput = "";
                try
                {
                    var aircrafts = Db.SQL<Aircraft>("SELECT p FROM StarcounterJsonData.Database.Model.Aircraft p");
                    foreach (Aircraft a in aircrafts)
                    {
                        strOutput += String.Format("Fuel price for all flights: {0}\n", a.GetFuelPrice4AllFlights());
                    }
                }
                catch (SqlException exception)
                {
                    Console.WriteLine("Incorrect query: " + exception.Message);
                }
                return strOutput;
            });


        }
    }
}