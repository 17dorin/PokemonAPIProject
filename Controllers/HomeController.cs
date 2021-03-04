using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonAPIProject.Models;
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
            return View();
        }
        public IActionResult SearchByName(string pokemon)
        {
            string poke = pokemon.Trim().ToLower();
            PokemonRoot p = pk.GetPokemon(poke);
            return View(p);
        }

        public IActionResult SearchByMove(string move)
        {
            //Normalizes search string
            string search = move.Trim().ToLower();

            //Deserializes move object
            MoveRoot m = pk.GetMove(search);

            //Storing user input to display in view
            TempData["moveName"] = move;

            List<PokemonRoot> pokemonByMove = new List<PokemonRoot>();

            //Move objects have an array of pokemon that can learn the move, represented by a name string and a url string
            foreach(Learned_By_Pokemon l in m.learned_by_pokemon)
            {
                //Uses each name in the GetPokemon method to deserialize into a PokemonRoot, adding them to a list
                PokemonRoot p = pk.GetPokemon(l.name);
                pokemonByMove.Add(p);
            }

            //Passing the list into the view
            return View(pokemonByMove);
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
