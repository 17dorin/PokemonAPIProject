using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPIProject.Helpers
{
    public class TextCleaner
    {
        public static string Clean(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            List<string> rawPieces = raw.Split('-').ToList();
            List<string> cleanedPieces = new List<string>();

            foreach(string r in rawPieces)
            {
                cleanedPieces.Add(TextCleaner.Capitalize(r));
            }

            string goodText = string.Join(" ", cleanedPieces);

            return goodText;
        }

        public static string Capitalize(string raw)
        {
            if(string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            return char.ToUpper(raw[0]) + raw.Substring(1);
        }

        public static string NormalInput(string raw)
        {
            return raw.Trim().ToLower().Replace(' ', '-');
        }
    }
}
