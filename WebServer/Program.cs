using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using Disp.Internal;

namespace WebServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TcpListener listener = new TcpListener(80);
            listener.Start();

            while (true)
            {

                Console.WriteLine("Waiting for connection");

                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());

                try
                {
                    String request = sr.ReadLine();

                    Console.WriteLine(request);

                    String[] tokens = request.Split(' ');
                    String page = tokens[1].Remove(0,1);

                    if (Directory.Exists(page))
                    {
                        sw.WriteLine("HTTP/1.0 200 OK\n");

                        string[] fileEntries = Directory.GetFiles(page);
                        foreach (string fileName in fileEntries)
                        {
                            sw.WriteLine(String.Format("<br><a href=\"{0}\">{1}</a>", fileName.Replace(page, String.Empty), fileName.Replace(page, String.Empty)));
                        }
                        string[] subdirectoryEntries = Directory.GetDirectories(page);
                        foreach (string subdirectory in subdirectoryEntries)
                        {
                            sw.WriteLine(String.Format("<br><a href=\"{0}\">{1}</a>", subdirectory.Replace(page, String.Empty), subdirectory.Replace(page, String.Empty)));
                        }

                        sw.Flush();
                    }
                    else
                    {

                        if (String.IsNullOrEmpty(page))
                            page = "index.html";

                        if (File.Exists(page))
                        {
                            if (page.EndsWith(".ds"))
                            {
                                Ambiente Ambiente = new Ambiente();
                                DispFile DispFile = new DispFile(Ambiente);

                                sw.WriteLine("HTTP/1.0 200 OK\n");
                                String result = DispFile.Open(page);
                                sw.WriteLine(result);
                                sw.Flush();
                            }
                            else
                            {
                                StreamReader file = new StreamReader(page);
                                sw.WriteLine("HTTP/1.0 200 OK\n");

                                sw.WriteLine("<!-- This page was rendered using RhenServer Beta for Disp -->");

                                String data = file.ReadLine();

                                while (data != null)
                                {
                                    sw.WriteLine(data);
                                    sw.Flush();
                                    data = file.ReadLine();
                                }
                            }
                        }
                        else
                        {
                            sw.WriteLine("HTTP/1.0 404 OK\n");
                            sw.WriteLine("<h1>Page not found</h1>");
                            sw.WriteLine("<p>RhenServer Beta</p>");
                            sw.Flush();
                        }

                    }


                }
                catch (Exception ex)
                {
                    sw.WriteLine("HTTP/1.0 404 OK\n");
                    sw.WriteLine(String.Format("<h1>{0}</h1>", ex.StackTrace));
                    sw.Flush();
                }

                client.Close();
            }
        }
    }
}
