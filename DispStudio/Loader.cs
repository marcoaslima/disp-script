using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispStudio
{
    public class Loader
    {
        public String DocumentsFolder;
        public String ProjectsFolder;

        public Loader()
        {
            this.DocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.ProjectsFolder = Path.Combine(DocumentsFolder, @"DispProjects");
        }

        public void Run()
        {
            if(!Directory.Exists(Path.Combine(DocumentsFolder, @"DispProjects"))){
                Directory.CreateDirectory(Path.Combine(DocumentsFolder, @"DispProjects"));
            }

            Application.Run(new FormMain(this));
        }
    }
}
