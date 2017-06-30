using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp
{
    public class DOut
    {
        public static System.String Capitalize(System.String input)
        {
            string result = string.Empty;
            string[] component = input.Split('.');

            foreach (var item in component)
            {
                string temp = FirstToCapital(item);
                
                if (!result.Equals(string.Empty))
                    result += ".";

                result += temp;
            }

            return result;
        }

        public static System.String FirstToCapital(System.String input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static System.String[] FirstToCapital(System.String[] input)
        {
            System.String[] retorno = new System.String[input.Length];
            
            for (int i =0; i < input.Length; i++)
            {
                retorno[i] = FirstToCapital(input[i]);
            }

            return retorno;
        }
        
        }
}
