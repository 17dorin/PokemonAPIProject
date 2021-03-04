using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPIProject.Models
{

    public class PokedexRoot
    {
        public Description[] descriptions { get; set; }
        public int id { get; set; }
        public bool is_main_series { get; set; }
        public string name { get; set; }
        public Name[] names { get; set; }
        public Pokemon_Entries[] pokemon_entries { get; set; }
        public Region region { get; set; }
        public Version_Groups[] version_groups { get; set; }
    }

    public class Region
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Description
    {
        public string description { get; set; }
        public Language language { get; set; }
    }

    public class Language_Dex
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name_Dex
    {
        public Language1 language { get; set; }
        public string name { get; set; }
    }

    public class Language1_Dex
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Pokemon_Entries
    {
        public int entry_number { get; set; }
        public Pokemon_Species pokemon_species { get; set; }
    }

    public class Pokemon_Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Groups
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
