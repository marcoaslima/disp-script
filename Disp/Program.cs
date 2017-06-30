using Disp.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp
{
    public class Program
    {
        public Ambiente Ambiente;

        public Program()
        {
            this.Ambiente = new Ambiente();
        }

        public Program(Ambiente Ambiente)
        {
            this.Ambiente = Ambiente;
        }

        public System.String SetName(System.String Name){
            Console.Title = Name;
            return string.Empty;
        }
    }
}
