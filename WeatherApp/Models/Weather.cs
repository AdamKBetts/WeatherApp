﻿using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.Diagnostics;

namespace WeatherApp.Models
{
    public class Weather
    {
        public Location location { get; set; }
        public Current current { get; set; }
        public Forecast forecast { get; set; }

        public class Location
        {
            public string name { get; set; }
            public string region { get; set; }
            public string country { get; set; }
            public double lat { get; set; }
            public double lon { get; set; }
            public string tz_id { get; set; }
            public long localtime_epoch { get; set; }
            public string localtime { get; set; }
        }
        public class Current
        {
            public double temp_c { get; set; }
            public double temp_f {  get; set; }
            public Condition condition { get; set; }
            public double wind_mph { get; set; }
            public double wind_kph {  get; set; }
            public int wind_degree { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mb { get; set; }
            public double pressure_in {  get; set; }
            public int humidity { get; set; }
            public int cloud {  get; set; }
            public double feelslike_c {  get; set; }
            public double feelslike_f { get; set; }
            public int is_day {  get; set; }
            public double uv {  get; set; }
            public double gust_mph { get; set; }
            public double gust_kph { get; set; }

            public class Condition
            {
                public string text { get; set; }
                public string icon { get; set; }
                public int code { get; set; }
            }
        }

        public class Forecast
        {
            public Forecastday[] forecastday { get; set; }
        }

        public class Forecastday
        {
            public string date { get; set; }
            public int date_epoch { get; set; }
            public Day day { get; set; }
            public Astro astro { get; set; }
            public class Day
            {
                public double maxtemp_c { get; set; }
                public double maxtemp_f { get; set; }
                public double mintemp_c { get; set; }
                public double mintemp_f { get; set; }
                public double avgtemp_c { get; set; }
                public double avgtemp_f { get; set; }
                public double maxwind_mph { get; set; }
                public double maxwind_kph { get; set; }
                public double daily_chance_of_rain { get; set; }
                public double daily_chance_of_snow { get; set; }
                public Condition condition { get; set; }
                public class Condition
                {
                    public string text { get; set; }
                    public string icon { get; set; }
                    public int code { get; set; }
                }
            }

            public class Astro
            {
                public string sunrise { get; set; }
                public string sunset { get; set; }
                public string moonrise { get; set; }
                public string moonset { get; set; }
            }
        }
    }
}
