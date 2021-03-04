using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PokemonAPIProject.Models
{
    public class PokemonDAL
    {
        //This process looks close to the same for all Non-Javascript Languages
        //1) Figure out your URL <- Keys also sometimes go into your URL
        //2) Create an HTTP request 
        //2.1) (if needed) special setup like keys and useragents go here
        //3) Get Response from Request 
        //4) Get Response Stream and feed it into a Stream Reader 
        //5) Use the Stream Reader to grab the contents of the JSON 
        //6) Most of the time, convert the JSON into a model 

        //Changes per the API 
        //7) How you use your model <-- Every model for every API will look different 

        public string GetData(string pokemon)
        {
            //URL can be different based upon endpoint/API 
            string url = $"https://pokeapi.co/api/v2/pokemon/{pokemon}/";

            //Web Requests sometimes need Headers/User Agent prop
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = null;

            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;

        }

        public string GetMoveData(string move)
        {
            string url = $@"https://pokeapi.co/api/v2/move/{move}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();

            return json;
        }

        public string GetDexData(string dex)
        {
            string url = $@"https://pokeapi.co/api/v2/pokedex/{dex}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();

            return json;
        }

        public PokedexRoot GetDex(string dex)
        {
            string json = GetDexData(dex);

            PokedexRoot p = JsonConvert.DeserializeObject<PokedexRoot>(json);
            return p;
        }

        public MoveRoot GetMove(string move)
        {
            string json = GetMoveData(move);

            MoveRoot r = JsonConvert.DeserializeObject<MoveRoot>(json);
            return r;
        }


        public PokemonRoot GetPokemon(string pokemon)
        {
            string json = GetData(pokemon);

            PokemonRoot r = JsonConvert.DeserializeObject<PokemonRoot>(json);
            return r;

        }


        public string TypeData(string name)
        {
            //URL can be different based upon endpoint/API 
            string url = $"https://pokeapi.co/api/v2/type/{name}/";

            //Web Requests sometimes need Headers/User Agent prop
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = null;

            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;

        }

        public List<Pokemon> GetType(string type)
        {
            string json = TypeData(type);

            TypeRoot r = JsonConvert.DeserializeObject<TypeRoot>(json);
            List<Pokemon> pokemonList = r.pokemon;
            return pokemonList;

        }

        public string GetHabitatData(string habitat)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon-habitat/{habitat}";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = null;

            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;
        }

        public HabitatRoot GetHabitat(string habitat)
        {
            string json = GetHabitatData(habitat);

            HabitatRoot h = JsonConvert.DeserializeObject<HabitatRoot>(json);
            return h;
        }


    }
}