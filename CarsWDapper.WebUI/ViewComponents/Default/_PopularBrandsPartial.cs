using CarsWDapper.WebUI.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsWDapper.WebUI.ViewComponents.Default
{
    public class _PopularBrandsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PopularBrandsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7255/api/Vehicles/Vehicles/GetMostPopularBrands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<DisplayBrandResponse>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
