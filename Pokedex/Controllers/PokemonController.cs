using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Pokedex.Controllers
{
    [Route("")]
    public class PokemonController : Controller
    {
        [HttpGet]
        [Route("/")]
        [Route("/Index")]
        public IActionResult Index(int pagina = 1)
        {
            List<Models.Pokemon> pokemons = new();
            string jsonPokemons;

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

            return View("Index", pagedPokemons);
        }
    }
}