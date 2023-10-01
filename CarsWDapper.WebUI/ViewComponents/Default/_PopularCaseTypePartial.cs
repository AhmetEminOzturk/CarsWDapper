using CarsWDapper.WebUI.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsWDapper.WebUI.ViewComponents.Default
{
    public class _PopularCaseTypePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PopularCaseTypePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7255/api/Vehicles/Vehicles/GetMostPopularCaseType");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<DisplayCaseTypeResponse>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
