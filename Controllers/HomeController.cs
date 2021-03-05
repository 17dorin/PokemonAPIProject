using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonAPIProject.Models;
using PokemonAPIProject.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPIProject.Controllers
{
    public class HomeController : Controller
    {
        private PokemonDAL pk = new PokemonDAL();
        public IActionResult Index()
        {
            TempData.Remove("type");
            TempData.Remove("faverror");
            return View();
        }
        public IActionResult SearchByName(string pokemon)
        {
            string poke = TextCleaner.NormalInput(pokemon);
            PokemonRoot p = pk.GetPokemon(poke);
            
            try
            {
                p = pk.GetPokemon(poke);
            }
            catch(Exception e)
            {
                TempData["error"] = "Please enter a valid entry";
                return RedirectToAction("Index");
            }

            TempData.Remove("moveerror");
            TempData.Remove("error");

            return View(p);
        }

        public IActionResult SearchByType(string type, [FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
        {
            string t = TextCleaner.NormalInput(type);

            TempData.Remove("error");
            TempData.Remove("moveerror");

            TempData["typeName"] = t;
            List<Pokemon> pokemon = pk.GetType(t);

            List<Pokemon> pagedPokemon = pokemon.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            TempData["pageNumber"] = pageNumber;
            TempData["pageSize"] = pageSize;

            return View(pagedPokemon);
        }

        public IActionResult SearchByMove(string move, [FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
        {
            //Normalizes search string
            string search = TextCleaner.NormalInput(move);
            TempData["moveName"] = search;

            //Deserializes move object
            MoveRoot m = new MoveRoot();
            try
            {
                m = pk.GetMove(search);
            }
            catch (Exception e)
            {
                TempData["moveerror"] = "Please enter a valid entry";
                return RedirectToAction("Index");
            }

            List<Learned_By_Pokemon> pokemonByUrl = new List<Learned_By_Pokemon>();
            pokemonByUrl = m.learned_by_pokemon.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            TempData["pageNumber"] = pageNumber;
            TempData["pageSize"] = pageSize;

            TempData.Remove("error");
            TempData.Remove("moveerror");

            //Passing the list into the view
            return View(pokemonByUrl);
        }

        public IActionResult SearchByDex(string dex, [FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
        {
            TempData.Remove("error");
            TempData.Remove("moveerror");
            PokedexRoot p = pk.GetDex(dex);
            TempData["dexName"] = dex;

            List<Pokemon_Entries> pokemonByUrl = new List<Pokemon_Entries>();
            pokemonByUrl = p.pokemon_entries.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            TempData["pageNumber"] = pageNumber;
            TempData["pageSize"] = pageSize;

            return View(pokemonByUrl);
        }

        public IActionResult SearchByHabitat(string habitat, [FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
        {
            TempData.Remove("error");
            TempData.Remove("moveerror");
            //Deserializes move object
            HabitatRoot h = pk.GetHabitat(habitat);

            //Storing user input to display in view
            TempData["habitatName"] = habitat;

            List<Pokemon_Species> pokemonByUrl = new List<Pokemon_Species>();
            pokemonByUrl = h.pokemon_species.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            TempData["pageNumber"] = pageNumber;
            TempData["pageSize"] = pageSize;

            //Passing the list into the view
            return View(pokemonByUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
