using Newtonsoft.Json;
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
    public class GameHttpHelper
    {
        public async Task<Game[]> GetGamesByPlayerId(Guid playerId)
        {
            Game[] games = null;
            var requestUri = string.Format("games?playerId={0}", playerId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64660/"); //TODO: use config
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(requestUri);

                if(!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    //Log.Error(string.Format("Error returned", error));
                    throw new Exception(error);
                }

                var gameResponse = JsonConvert.DeserializeObject<GameResponse>(response.Content.ReadAsStringAsync().Result);
                games = gameResponse.Games.ToArray();
            }

            return games;
        }
    }
}
