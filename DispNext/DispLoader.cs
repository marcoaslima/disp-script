using Disp.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DispNext
{
    public class DispLoader
    {
        public static string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        
        public Disp.Internal.Loader Loader;
        public Disp.Internal.Ambiente Ambiente;

        public DispLoader(string[] args)
        {


            Ambiente = new Ambiente();
            Ambiente.DefaultCommandClassName = new Disp.DString("Disp");

            this.Loader = new Disp.Internal.Loader(this.Ambiente);

            Console.Title = "DISP NEXT " + Ambiente.CurrentFolder;

            args = args.Except(new string[] { "dispx", "dispx.exe", "disp", "disp.exe" }).ToArray();
                        
            if (args != null)
            {
                if (args.Count() > 0)
                {
                    String comando = "";

                    for (int i = 0; i < args.Count(); i++)
                    {
                        comando += args[i];
                        comando += " ";
                    }

                    var cmd = new ConsoleCommand(comando);

                    string result = Loader.Execute(cmd);

                    WriteToConsole(result);

                    Console.ReadKey();

                }
                else
                {
                    Run();
                }
            }
        }

        public void Run()
        {
            while (true)
            {
                var consoleInput = ReadFromConsole();
                //if (string.IsNullOrWhiteSpace(consoleInput)) continue;
                try
                {
                    // Create a ConsoleCommand instance:
                    consoleInput = Utils.RemoveChar(consoleInput);

                    var cmd = new ConsoleCommand(consoleInput);
                    // Execute the command:
                    string result = Loader.Execute(cmd);
                    // Write out the result:
                    WriteToConsole(result);
                }
                catch (Exception ex)
                {
                    // OOPS! Something went wrong - Write out the problem:
                    WriteToConsole(ex.Message);
                }
            }
        }

        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }

        public string ReadFromConsole(string promptMessage = "")
        {
            string user = string.Format("{0}@{1} ", Environment.UserName, Environment.MachineName);
            //string lang = string.Format("DISPX32 ");
            string folder = string.Format("~{0} ", Ambiente.CurrentFolder);

            // Show a prompt, and get input:
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(user);
            //Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //Console.Write(lang);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(folder);
            if (!promptMessage.Equals(""))
            {
                Console.WriteLine(promptMessage);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("DS > ");
            return Console.ReadLine();
        }
    }
}
