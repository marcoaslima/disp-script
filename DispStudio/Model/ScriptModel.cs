using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DispStudio.Model
{
    public class ScriptModel
    {
        public String Name { get; set; }
        public String Content;
        public String Path;

        private String br = Environment.NewLine;

        public ScriptModel()
        {
            this.Name = "main.ds";
            this.Content =String.Concat("#! / disp" , br, "import Disp", br);
        }

        public ScriptModel(String Name)
        {
            this.Name = Name;
        }

        internal void Save()
        {
            using (StreamWriter outputFile = new StreamWriter(this.Path))
            {
               outputFile.WriteLine(this.Content);
               outputFile.Close();
            }
        }
    }
}
