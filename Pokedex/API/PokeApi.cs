using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.API
{
    public class PokeApi
    {
        [HttpGet]
        public async Task<List<Models.Pokemon>> GetPokemons()
        {
            using (HttpClient client = new HttpClient())
            {
                List<Models.Pokemon> pokemons = new List<Models.Pokemon>();

                for (int i = 1; i <= 151; i++) //1ª Geração -> 151
                {
                    var result = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/" + i);
                    pokemons.Add(await result.Content.ReadAsAsync<Models.Pokemon>());
                }

                return pokemons;
            }
        }
    }
}
