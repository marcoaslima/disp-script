using Disp.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DispCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 0)
            {
                try
                {
                    DispFile df = new DispFile(null);
                    df.Compile(args[0]);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
    }
}
