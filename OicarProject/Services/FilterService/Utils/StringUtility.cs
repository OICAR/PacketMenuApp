using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Models
{
    public class StringUtility
    {
        public static HashSet<string> ParseString(string stringToParse)

        {

            string[] arrayOfStrings = stringToParse.Split(new Char[] { ',', '\\', '\n',';'});
            //string[] arrayOfStrings = stringToParse.Split(new Char[] { ',', '\\', '\n', ';', ' ', '\t' });

            return arrayOfStrings.ToHashSet();
        
        }
    }
}