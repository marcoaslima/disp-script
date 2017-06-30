using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp
{
    public class DString : DObject
    {
        private System.String Nome { get; set; }
        private System.String Valor { get; set; }

        public DString(System.String Valor)
        {
            this.Valor = Valor;
        }

        public DString(System.String Valor, System.String Nome)
        {
            this.Valor = Valor;
            this.Nome = Nome;
        }

        public System.String Define(System.String Name, System.String Value)
        {
            this.Valor = Value;
            this.Nome = Name;

            return string.Empty;
        }

    }
}
