using Disp.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DispFileInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args != null)
                {
                    if (args.Count() > 0)
                    {
                        Ambiente Ambiente = new Ambiente();
                        DispFile DispFile = new DispFile(Ambiente);

                        DispFile.Open(args[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                DateTime agora = DateTime.Now;

                FileStream fs1 = new FileStream(string.Format(@"{0}\Log\{1}-{2}-{3}-{4}-{5}-{6}.txt", AppDomain.CurrentDomain.BaseDirectory, agora.Year, agora.Month, agora.Day, agora.Hour, agora.Minute, agora.Millisecond), FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.Write(ex.Message);
                writer.Close();
            }
        }
    }
}
