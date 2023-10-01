using CarsWDapper.WebUI.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsWDapper.WebUI.ViewComponents.Default
{
    public class _PopularShiftTypePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PopularShiftTypePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7255/api/Vehicles/Vehicles/GetMostPopularShiftType");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<DisplayShiftTypeResponse>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
