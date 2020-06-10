using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Utils.StringUtilities
{
    public static class StringUtility
    {

        public static HashSet<string> ParseString(char delimiter,string stringToParse)

        {

          string[] arrayOfStrings =  stringToParse.Split(delimiter);
            return arrayOfStrings.ToHashSet();
        
        }

    }
}
