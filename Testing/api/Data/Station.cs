using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace api.Data
{

    public class METARStation
    {

        public static readonly string METAR_STATION_SOURCE_URL = "https://aviationweather.gov/docs/metar/stations.txt";

        public static List<METARStation> Stations { get; set; }

        public string StateAbbreviation { get; set; }
        public string StationName { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string SynopticNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
        public bool MetarReporting { get; set; }
        public bool NextRad { get; set; }
        public string AviationFlag { get; set; }
        public bool UpperAirSite { get; set; }
        public string Auto { get; set; }
        public string OfficeType { get; set; }
        public string PlottingPriority { get; set; }

        //static constructor
        static METARStation()
        {
            Stations = GetMETARStations(METAR_STATION_SOURCE_URL).Result;
        }

        public static async Task<string> GetMETARStationStringAsync(string url)
        {
            HttpClient client = new HttpClient();

            return await client.GetStringAsync(url);
        }

        public static async Task<List<METARStation>> GetMETARStations(string url)
        {
            HttpClient client = new HttpClient();

            string stations = await client.GetStringAsync(url);

            //credit: https://stackoverflow.com/a/1508217
            var lines = Regex.Split(stations, "\r\n|\r|\n");

            foreach(string line in lines)
            {
                if(line.Length == 83)
                {
                    string output = "";
                    string cd = line.Substring(0,3).Trim();
                    output += $"cd:{cd}|";
                    string station = line.Substring(3,17).Trim();
                    output += $"station:{station}|";
                    string icao = line.Substring(20, 6).Trim();
                    output += $"icao:{icao}|";
                    string iata = line.Substring(24, 6).Trim();
                    output += $"iata:{iata}|";
                    string synop = line.Substring(32, 7).Trim();
                    output += $"synop:{synop}|";
                    string lat = line.Substring(38, 8).Trim();
                    output += $"lat:{lat}|";                  
                    string lon = line.Substring(46, 8).Trim();
                    output += $"lon:{lon}|";
                    string elevation = line.Substring(54, 5).Trim();
                    output += $"elevation:{elevation}|";
                      
                    Console.WriteLine(output);
                    
                }
            }

            return new List<METARStation>();
        }



        public static METARStation ParseStationLine(string line)
        {
            return null;            
        }

        public static async Task<string> ParseStationLineStringAync(string line)
        {
            return await Task<string>.Run(() => ParseStationLineString(line));
        }

        public static string ParseStationLineString(string line)
        {
            return $"line: {line}";
        }



        private static bool SkipLine(string line)
        {
            bool skip = false;

            if(line.StartsWith("!"))
            {
                skip = true;
                return skip;
            }
            else if(line == "")
            {
                skip = true;
                return skip;                
            }
            else if(line.Length != 83)
            {
                skip = true;
                return skip;
            }

            return skip;
        }
    }
}