using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp.Internal
{
    public class Variable
    {
        public string name { get; set; }

        public System.Object value { get; set; }


        public Variable(string name)
        {
            this.name = name;
            this.value = "";
        }

        public Variable(string name, System.Object value)
        {
            this.name = name;
            this.value = value;
        }

        public static Variable Search(string name, Ambiente ambiente)
        {
            Variable variable = null;

            foreach (var v in ambiente.userVariables)
            {
                if (v.name.Equals(name))
                {
                    variable = v;
                    break;
                }
            }

            return variable;
        }

        public static string SetValue(string Variable, string Value, Ambiente Ambiente)
        {
            Boolean seted = false;

            foreach (var v in Ambiente.userVariables)
            {
                if (v.name.Equals(Variable))
                {
                    v.value = Value;
                    seted = true;
                    break;
                }
            }

            if (!seted)
            {
                Ambiente.userVariables.Add(new Variable(Variable));
                SetValue(Variable, Value, Ambiente);
            }

            return (seted) ? "success" : "error";
        }
    }
}
