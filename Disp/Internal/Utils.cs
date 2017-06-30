using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp.Internal
{
    public class Utils
    {
        public static System.String RemoveChar(System.String consoleInput)
        {
            consoleInput = consoleInput.Replace('(', ' ');
            consoleInput = consoleInput.Replace(')', ' ');
            consoleInput = consoleInput.Replace(',', ' ');

            consoleInput = consoleInput.Trim();

            return consoleInput;
        }
    }
}
