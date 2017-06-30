using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp
{
    public class DInteger
    {
        public Disp.Internal.Ambiente Ambiente;

        private System.Int32 Value { get; set; }
        private System.String Name { get; set; }

        public DInteger(Disp.Internal.Ambiente Ambiente)
        {
            this.Ambiente = Ambiente;
        }
    }
}
