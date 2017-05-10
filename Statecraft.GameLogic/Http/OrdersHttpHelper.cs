using Newtonsoft.Json;
using Statecraft.Common.JsonModels.Requests;
using Statecraft.Common.JsonModels.Responses;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.Http
{
    public class OrdersHttpHelper
    {
        public async Task SaveOrders(Guid gameId, MoveAttempt moveAttempt, string baseApiUrl)
        {
            var requestUri = "orders";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiUrl); 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new SaveOrdersRequest(gameId, moveAttempt);
                string serializedObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUri, httpContent).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    //Log.Error(string.Format("Error returned", error));
                    throw new Exception(error);
                }
            }
        }
    }
}
