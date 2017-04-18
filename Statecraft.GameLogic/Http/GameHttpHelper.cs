using Newtonsoft.Json;
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
        public Game[] GetGamesByPlayerId(Guid playerId)
        {
            Game[] games = null;
            var requestUri = string.Format("games", playerId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64660/"); //TODO: use config
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(requestUri).Result;

                if(!response.IsSuccessStatusCode)
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    //Log.Error(string.Format("Error returned", error));
                    throw new Exception(error);
                }

                //games = JsonConvert.DeserializeObject<GameResponse>(response.Content.ReadAsStringAsync().Result); //TODO: move json models to Common?
            }

            return games;
        }
    }
}
