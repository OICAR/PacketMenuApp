using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Utils.StringUtilities
{
    public static class StringUtility
    {

        public static HashSet<string> ParseString(string stringToParse)

        {

            string[] arrayOfStrings = stringToParse.Split(new Char[] { ',', '\\', '\n',';'});
            //string[] arrayOfStrings = stringToParse.Split(new Char[] { ',', '\\', '\n', ';', ' ', '\t' });

            return arrayOfStrings.ToHashSet();
        
        }

    }
}
