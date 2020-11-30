using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using webapi.Models;

/* helpful: 
    https://exceptionnotfound.net/ef-core-inmemory-asp-net-core-store-database/ 
    https://github.com/exceptionnotfound/InMemoryEFCoreDemo
*/
namespace webapi.Data{
    public class LoadMetarData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApiDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<WebApiDbContext>>()))
            {
                // Look for any stations
                if (context.Stations.Any())
                {
                    Console.WriteLine("FOUND SOME");
                    return;   // Data was already seeded
                }

                Console.WriteLine($"READING FROM STATIONS");
                List<NOAAStation> stationList = NOAAStation.GetNOAAStationsList();

                Console.WriteLine($"FINDING DUPLICATES");
                // as it turns out, there are duplicates in the data
                var duplicates = stationList.GroupBy(s => s.ICAO)
                                            .Where(grp => grp.Count() > 1)
                                            .Select(grp => grp.Key);

                Console.WriteLine($"{duplicates.Count()} DUPLICATES FOUND");

                //find the duplicate ICAO values
                //store one
                //remove all
                //re-insert the one
                Console.WriteLine($"REMOVING DUPLICATES");                
                foreach(var item in duplicates){
                    NOAAStation m = stationList.First(s => s.ICAO == item);
                    stationList.RemoveAll(s => s.ICAO == item);
                    stationList.Add(m);
                }                                            

                //WRITE TO DB
                try{
                    context.Stations.AddRange(stationList);
                    context.SaveChanges();
                    Console.WriteLine($"LOADING COMPLETE: {context.Stations.Count()}");                    
                }
                catch(Exception exp){
                    Console.WriteLine(exp.Message);
                }
            }
        }
    }
}
