using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using X.PagedList;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index(int pagina = 1)
        {
            List<Models.Pokemon> pokemons = null;

            string jsonPokemons = null;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_pokemons")))
            {
                pokemons = new API.PokeApi().GetPokemons().Result;
                jsonPokemons = JsonConvert.SerializeObject(pokemons);
                HttpContext.Session.SetString("_pokemons", jsonPokemons);
            }
            else
            {
                jsonPokemons = HttpContext.Session.GetString("_pokemons");
                pokemons = JsonConvert.DeserializeObject<List<Models.Pokemon>>(jsonPokemons);
            }

            IPagedList<Models.Pokemon> pagedPokemons = pokemons.ToPagedList(pagina, 12);
            return View(pagedPokemons);
        }
    }
}