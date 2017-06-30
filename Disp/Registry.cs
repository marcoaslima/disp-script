using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp
{
    public class Registry
    {
        public Disp.Internal.Ambiente Ambiente;

        public Registry(Disp.Internal.Ambiente Ambiente)
        {
            this.Ambiente = Ambiente;
        }

        public System.String Assoc(System.String Extension, System.String ApplicationPath)
        {
            return System.String.Empty;
        }
    }
}
