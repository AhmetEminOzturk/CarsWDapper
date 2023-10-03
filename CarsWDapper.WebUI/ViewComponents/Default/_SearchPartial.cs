using CarsWDapper.WebUI.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsWDapper.WebUI.ViewComponents.Default
{
    public class _SearchPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SearchPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string keyword)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7255/api/Vehicles/Vehicles/Search?keyword="+keyword);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<DisplayVehicleResponse>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
