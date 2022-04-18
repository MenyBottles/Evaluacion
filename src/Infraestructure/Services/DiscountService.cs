using Application.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class DiscountService : IDiscountService
    {
        public async Task<int> GetDiscountAsync()
        {
            var discount = 0;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://625d08d995cd5855d6199a8c.mockapi.io/discount"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var test = JsonConvert.DeserializeObject<dynamic>(apiResponse);
                    discount = Convert.ToInt32(test.discount);
                }
            }

            return discount;
        }
    }
}
