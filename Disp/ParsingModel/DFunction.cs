using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp.ParsingModel
{
    public class DFunction
    {
        public String FunctionName;
        public List<String> FunctionLines;

        public DFunction(String FunctionName, params String[] Parameters)
        {
            this.FunctionName = FunctionName;
            this.FunctionLines = new List<string>();
        }
    }
}
