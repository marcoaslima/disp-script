using DispStudio.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispStudio.Controller
{
    public class FolderController
    {
        public static String Save(String FileName)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = FileName;
            savefile.Filter = "Disp Project (*.proj)|*.proj";
            savefile.Title = "Salvar projeto";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
               
            }

            return String.Empty;
        }


        public static ScriptModel LoadFile(String fPath)
        {
            ScriptModel model = new ScriptModel(Path.GetFileName(fPath));
            model.Path = fPath;

            int counter = 0;
            string line;

            System.IO.StreamReader file =  new System.IO.StreamReader(fPath);

            while ((line = file.ReadLine()) != null)
            {
                model.Content += (line + Environment.NewLine);
                counter++;
            }

            file.Close();

            return model;
        }
    }
}
