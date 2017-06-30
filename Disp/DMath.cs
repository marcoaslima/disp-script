using NCalc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disp
{
    public class DMath
    {
        public Disp.Internal.Ambiente Ambiente;

        public DMath(Disp.Internal.Ambiente Ambiente)
        {
            this.Ambiente = Ambiente;
        }

        public String Solve(String exp)
        {
            Expression e = new Expression(exp);
            return e.Evaluate().ToString();
        }
    }
}
