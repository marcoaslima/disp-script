using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp.ParsingModel
{
    public class DClass
    {
        public String ClassName;
        public List<DFunction> Functions;

        public DClass(String ClassName)
        {
            this.ClassName = ClassName;
            this.Functions = new List<DFunction>();
        }
    }
}
