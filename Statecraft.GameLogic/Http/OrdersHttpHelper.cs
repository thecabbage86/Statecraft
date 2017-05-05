using Newtonsoft.Json;
using Statecraft.Common.JsonModels.Requests;
using Statecraft.Common.JsonModels.Responses;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.Http
{
    public class OrdersHttpHelper
    {
        public async Task SaveOrders(int gameId, MoveAttempt moveAttempt)
        {
            var requestUri = "orders";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://statecraftservices.azurewebsites.net/"); //TODO: use config
                var request = new SaveOrdersRequest(gameId, moveAttempt);
                var httpContent = new StringContent(JsonConvert.SerializeObject(request));
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
