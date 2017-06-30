using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Disp
{
    public class DForm
    {
        public Disp.Internal.Ambiente Ambiente;
        public Form CurrentForm;

        public DForm(Disp.Internal.Ambiente Ambiente)
        {
            this.Ambiente = Ambiente;
        }

        public Form ReadForm(String File){

            return CurrentForm;
        }
    }
}
