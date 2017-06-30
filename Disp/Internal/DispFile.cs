using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Disp.Internal
{
    public class DispFile
    {
        private System.String _path;
        private System.Boolean _hasError = false;

        public System.String Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public Disp.Internal.Ambiente Ambiente;

        public DispFile(Disp.Internal.Ambiente Ambiente)
        {
            this.Ambiente = Ambiente==null?new Ambiente(): Ambiente;
        }

        public string Open(System.String path)
        {
            string LineResult = "";
            this._path = path;

            if (!File.Exists(path))
            {
                return string.Format("Program {0} not exists", path);
            }

            System.Int32 counter = 0;
            System.String line;

            System.IO.StreamReader file = new System.IO.StreamReader(path);

            Int32 LineNumber = 0;
            MetaData Meta = new MetaData(this);

            while ((line = file.ReadLine()) != null)
            {
                if (line.EndsWith(";"))
                {
                    line.Replace(";", "");
                }

                if (!line.Equals(""))
                {
                    String Formtado = Utils.RemoveChar(line);
                    LineResult = RunLine(Formtado, Meta, LineNumber);
                }

                counter++;

                if (_hasError)
                {
                    return string.Format("Error on line {0}, error description: Command line '{1}' was wrong ", counter, line);
                }

                LineNumber++;

            }

            file.Close();

            return "";
        }

        public System.String RunLine(System.String Line,  MetaData Meta , Int32 LineNumber = 0)
        {
            string returned = "";

            if (!Meta.VerifyExtraCommand(Line))
            {
                Loader loader = new Loader(this.Ambiente);

                returned = loader.Execute(new ConsoleCommand(Line), LineNumber);

                if (returned.Equals(Definitions.badCommandMessage))
                {
                    _hasError = true;
                }
            }

            return returned;
        }

        public string Compile(string path)
        {
            Compiler compiler = new Compiler();

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            System.IO.StreamWriter filew = new StreamWriter(path.Replace(".ds", ".dsc"));

            String line = string.Empty;

            while ((line = file.ReadLine()) != null)
            {
                Int64 a = compiler.StringToBit(line);
                filew.WriteLine(a);
            }

            filew.Close();
            file.Close();

            return string.Empty;
        }

    }
}
