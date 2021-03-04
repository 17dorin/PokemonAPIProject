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

{
    public class FavoritesController : Controller
    {
        private readonly PokemonDbContext _PokemonDB;

        public FavoritesController(PokemonDbContext pokemonDbContext)
        {
            _PokemonDB = pokemonDbContext;
        }

        public IActionResult Index()
        {
            return View(_PokemonDB.Pokemons.Where(x => x.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FavPokemon pokemon)
        {
            pokemon.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _PokemonDB.Pokemons.Add(pokemon);
            _PokemonDB.SaveChanges();
            return View();
        }

        public IActionResult Delete(int id)
        {
            FavPokemon pokemon = _PokemonDB.Pokemons.Find(id);
            return View(pokemon);
        }

        [HttpPost]
        public IActionResult Delete(FavPokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                _PokemonDB.Pokemons.Remove(pokemon);
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
