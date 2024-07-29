using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPISummer24.Models
{
    public class Country
    {
        public int Geonameid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Capital Capital { get; set; }
        public string AreaSize { get; set; }
        public long Population { get; set; }
        public string PhoneCode { get; set; }
        public bool IsInEu { get; set; }
        public Dictionary<string, string> Languages { get; set; }
        public Flag Flag { get; set; }
        public string Tld { get; set; }
        public object DependsOn { get; set; }
        public Dictionary<string, string> Territories { get; set; }
        public string WikiId { get; set; }
        public string WikiUrl { get; set; }
        public int TotalIsoDivisions { get; set; }
        public int TotalAdmDivisions { get; set; }
        public int TotalCities { get; set; }
        public Currency Currency { get; set; }
        public Timezone Timezone { get; set; }
        public Continent Continent { get; set; }
        public string Status { get; set; }
    }

    public class Capital
    {
        public string Name { get; set; }
        public int Geonameid { get; set; }
    }

    public class Flag
    {
        public string File { get; set; }
        public string Emoji { get; set; }
        public string Unicode { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Timezone
    {
        public string Name { get; set; } // Renamed property from Timezone
        public int GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public string Code { get; set; }
    }

    public class Continent
    {
        public int Geonameid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

