using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonAPIProject.Models
{
    public partial class FavPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        public string Image { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
