using System.Threading.Tasks;
using Refit;
using Capstone.WebApi.Models;
using System.Net.Http;
using Capstone.WebApi.Models;
using System.Text.Json;
using Microsoft.Net.Http.Headers;

namespace Capstone.WebApi.Services
{
    /*  public interface IArticleServiceApi
      {
          [Get("/articles/{referenceNumber}")]
          Task<DTOOrder> GetArticle(string referenceNumber);
      }*/
    public class OrderSubstitutionService : IOrderSubstitutionService
    {
        private readonly IHttpClientFactory _httpClient;

        public OrderSubstitutionService(IHttpClientFactory client) // an arraya? how loop it ? 
        {
            _httpClient = client;          

        }

        public async Task<SmartSubsReturn[]> GetSubstitutionOfOrder(DTOOrder[] order)
        {
            SmartSubsReturn[] returnedOrdersArr = new SmartSubsReturn[order.Length];
            var httpClient = _httpClient.CreateClient();
            for (int i = 0; i < order.Length; i++)
            {
                var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://ofk8saae.uat.wx-d.net/smart-subs/stores/{order[i].branchID}/recommendation/{order[i].stockCode}?Quantity={order[i].quantity}&BranchId={order[i].fulfilmentStoreKey}")
                {
                    Headers =
                    {
                        { "x-api-key", "8463b411-1510-4037-a1e5-95c42fa26b69"},
                        { HeaderNames.UserAgent, "C# App" }
                    }
                };          

            

                HttpResponseMessage subbedOrders = await httpClient.SendAsync(httpRequestMessage);
                string returnedOrders = await subbedOrders.Content.ReadAsStringAsync();
                SmartSubsReturn subbedOrder = JsonSerializer.Deserialize<SmartSubsReturn>(returnedOrders);                

                returnedOrdersArr[i] = subbedOrder;

            }
            return returnedOrdersArr;
        }
    }

    // look to make method function asynchronously => WORRY LATER
}
