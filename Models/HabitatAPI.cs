using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPIProject.Models
{

    public class HabitatRoot
    {
        public int id { get; set; }
        public string name { get; set; }
        public Name[] names { get; set; }
        public Pokemon_Species[] pokemon_species { get; set; }

    }

    public class HabitatName
    {
        public Language language { get; set; }
        public string name { get; set; }
    }

    public class HabitatLanguage
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    //public class Pokemon_Species
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

}
