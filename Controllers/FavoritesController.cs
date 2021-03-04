using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonAPIProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PokemonAPIProject.Controllers

{ [Authorize]
    public class FavoritesController : Controller
    {
        private readonly PokemonDbContext _PokemonDB;
        private PokemonDAL pk = new PokemonDAL();

        public FavoritesController(PokemonDbContext pokemonDbContext)
        {
            _PokemonDB = pokemonDbContext;
        }

        public IActionResult Index()
        {
            return View(_PokemonDB.FavPokemons.Where(x => x.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList());
        }

        //public IActionResult Add()
        //{
        //    return View();
        //}

        public IActionResult Add(string pokemon)
        {
            string poke = pokemon.Trim().ToLower();
            PokemonRoot p = pk.GetPokemon(poke);//Allows addition of other properties to the SQL table

            FavPokemon favPokemon = new FavPokemon();

            favPokemon.Image = p.sprites.front_default;

            favPokemon.Type1 = p.types[0].type.name;
            if (p.types.Length < 2)
            {
                favPokemon.Type2 = "";
            }
            else
            {
                favPokemon.Type2 =", " + p.types[1].type.name;
            }

            string url = $@"https://pokeapi.co/api/v2/pokemon/{pokemon}/";
            favPokemon.Name = pokemon;
            favPokemon.Url = url;

            favPokemon.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _PokemonDB.FavPokemons.Add(favPokemon);
            _PokemonDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            FavPokemon pokemon = _PokemonDB.FavPokemons.Find(id);
            return View(pokemon);
        }

        [HttpPost]
        public IActionResult Delete(FavPokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                _PokemonDB.FavPokemons.Remove(pokemon);
                _PokemonDB.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
