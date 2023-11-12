using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication4.Models;

[ViewComponent(Name = "Weather")]
public class WeatherViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string region)
    {
        var weather = await GetWeatherAsync(region);
        return View(weather);
    }

    private async Task<Weather> GetWeatherAsync(string region)
    {
        string apiKey = "bbf9e8af0bae6693fcbb704b8aee0f89";
        string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={region}&units=metric&appid={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dynamic weatherData = JsonConvert.DeserializeObject(content);

                var weather = new Weather
                {
                    Temperature = weatherData.main.temp,
                    Description = weatherData.weather[0].description,
                    Region = region
                };

                return weather;
            }
            else
            {
                throw new Exception($"Помилка при отриманні даних погоди: {response.ReasonPhrase}");
            }
        }
    }
}

