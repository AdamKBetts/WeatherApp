using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly string _apiKey = "abb93bac8d0c471480e114449253101";
        private readonly string _currentWeatherUrl = "http://api.weatherapi.com/v1/current.json?key={0}&q={1}&aqi=no";
        private readonly string _forecastUrl = "http://api.weatherapi.com/v1/forecast.json?key={0}&q={1}&days=3&aqi=no&alerts=no";

        public async Task<IActionResult> Index(string city = "London")
        {
            Weather weatherData = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string currentUrl = string.Format(_currentWeatherUrl, _apiKey, city);
                    HttpResponseMessage currentResponse = await client.GetAsync(currentUrl);
                    currentResponse.EnsureSuccessStatusCode();
                    string currentJson = await currentResponse.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<Weather>(currentJson);

                    string forecastUrl = string.Format(_forecastUrl, _apiKey, city);
                    HttpResponseMessage forecastResponse = await client.GetAsync(forecastUrl);

                    string forecastJson = null;

                    if (forecastResponse.IsSuccessStatusCode)
                    {
                        forecastJson = await forecastResponse.Content.ReadAsStringAsync();
                        var forecastData = JsonConvert.DeserializeObject<Weather>(forecastJson);
                        if (weatherData != null)
                        {
                            weatherData.forecast = forecastData.forecast;
                        }
                    }
                    else
                    {
                        ViewBag.ForecastError = $"Error fetching forecast: {forecastResponse.StatusCode}";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error = $"Error fetching data: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex);
            }
            catch (JsonException ex)
            {
                ViewBag.Error = $"Error parsing JSON: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"An unexpected error ocurred: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return View(weatherData);
        }
    }
}
