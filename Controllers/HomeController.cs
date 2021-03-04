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
            TempData.Remove("type");
            return View();
        }
        public IActionResult SearchByName(string pokemon)
        {
            string poke = pokemon.Trim().ToLower();
            PokemonRoot p = pk.GetPokemon(poke);
            return View(p);
        }
        public IActionResult SearchByType(string type)
        {
            TempData["type"] = type;
            string t = type.Trim().ToLower();
            List<Pokemon> list = pk.GetType(t);
            return View(list);
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
