using Newtonsoft.Json;
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
    public class GameStateHttpHelper
    {
        public async Task<GameState> GetGameState(int gameId)
        {
            GameState gameState = null;
            var requestUri = string.Format("gamestate?gameId={0}", gameId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://statecraftservices.azurewebsites.net/"); //TODO: use config
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(requestUri).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    //Log.Error(string.Format("Error returned", error));
                    throw new Exception(error);
                }

                var gameStateResponse = JsonConvert.DeserializeObject<GameStateResponse>(response.Content.ReadAsStringAsync().Result);
                gameState = gameStateResponse.GameStates[0];
            }

            return gameState;
        }
    }
}
