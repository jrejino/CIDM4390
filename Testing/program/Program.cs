using System;

using api;
using api.Data;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync();
        }

        static async void RunAsync()
        {
            // string result = await METARStation.GetMETARStationStringAsync(METARStation.METAR_STATION_SOURCE_URL);
            var list = await METARStation.GetMETARStations(METARStation.METAR_STATION_SOURCE_URL);
            Console.WriteLine("result");
        }
    }
}
