using Disp.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Disp
{
    public class Proccess
    {
        public Ambiente Ambiente;

        public Proccess(Ambiente Ambiente)
        {
            this.Ambiente = Ambiente;
        }

        public string Start(System.String proccessName)
        {
            string proc = File.Exists(proccessName) ? proccessName : string.Format(@"{0}\{1}", this.Ambiente.CurrentFolder, proccessName);
            try
            {
                System.Diagnostics.Process.Start(proc);
                return string.Format("Proccess {0} started", proccessName);
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}", ex.Message);
            }

        }

        public string StartParams(System.String proccessName, System.String parametros)
        {
            string proc = File.Exists(proccessName) ? proccessName : string.Format(@"{0}\{1}", this.Ambiente.CurrentFolder, proccessName);
            try
            {
                System.Diagnostics.Process.Start(proc, parametros);
                return string.Format("Proccess {0} started", proccessName);
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}", ex.Message);
            }

        }
    }
}
