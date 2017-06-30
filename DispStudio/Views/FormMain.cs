using Disp;
using Disp.Internal;
using DispStudio.Controller;
using DispStudio.Model;
using DispStudio.Views;
using DispStudio.Views.UC;
using MegariCore.Loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispStudio
{
    public partial class FormMain : Form
    {
        public Disp.Internal.Ambiente Ambiente;

        public Boolean Salvo = false;
        public String FileName = string.Empty;

        public Boolean HasProject = false;

        public Loader Loader;
        public String ProjectDir;

        public List<ScriptModel> Models;

        public string MainFile = "main.ds";

        ImageList il = new ImageList();

        public FormMain(Loader Loader)
        {
            InitializeComponent();
            this.Ambiente = new Ambiente();
            this.Loader = Loader;
            this.Models = new List<ScriptModel>();

            il.Images.Add(new Icon(@"Icons\default.ico"));
            il.Images.Add(new Icon(@"Icons\dispfile.ico"));
            il.Images.Add(new Icon(@"Icons\project.ico"));

            treeView1.ImageList = il;
        }


        private void executarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Disp Script (*.ds)|*.disp|Disp Project (*.dsp)|*.dsp|Disp Program (*.dp)|*.dp|Disp Project (*.dsproj)|*.dsproj";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int counter = 0;
                string line;

                
                FileName = openFileDialog1.FileName;

                if (FileName.EndsWith(".dsproj"))
                {
                    IniFile inifile = IniLoader.LoadInitiator(FileName);
                    Section project = inifile.Search("Project");
                    Key name = project.Search("Name");
                    Key FileNameMain = project.Search("FileName");

                    MainFile = FileNameMain.Value;

                    ProjectName = name.Value;


                    ProjectDir = Directory.GetParent(FileName).ToString();
                    
                    rootNode = treeView1.Nodes.Add(ProjectName);
                    rootNode.ImageIndex = 2;

                    LoadFiles();

                }
                else
                {

                    System.IO.StreamReader file = new System.IO.StreamReader(FileName);

                    while ((line = file.ReadLine()) != null)
                    {
                        //rtbProgram.AppendText(line + Environment.NewLine);
                        counter++;
                    }

                    file.Close();
                }

                Salvo = true;
            }

            

        }

        private void opçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (HasProject)
            //{
                FormProjectOptions options = new FormProjectOptions();
                options.Show();
            //}
        }

        private void projetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewProject newProject = new FormNewProject(this);
            newProject.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        internal void LoadProject()
        {
            ScriptModel mode = new ScriptModel();
            mode.Path = Path.Combine(ProjectDir, mode.Name);
            mode.Save();

            rootNode = treeView1.Nodes.Add(ProjectName);
            rootNode.ImageIndex = 2;
            LoadFiles();
        }

        private void LoadFiles()
        {
            String[] arquivos = Directory.GetFiles(ProjectDir);

            foreach (var item in arquivos)
            {
                if (!item.Contains("project.dsproj"))
                {
                    TreeNode child = this.rootNode.Nodes.Add(Path.GetFileName(item));
                    child.ImageIndex = 1;

                    ScriptModel atual = new ScriptModel(Path.GetFileName(item));
                    atual.Path = item;
                }
            }
            
        }

        public string ProjectName { get; set; }

        public TreeNode rootNode;

        private void treeView1_Click(object sender, EventArgs e)
        {
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                String FilePath = Path.Combine(this.Loader.ProjectsFolder, treeView1.SelectedNode.FullPath);
                if (File.Exists(FilePath))
                {
                    ScriptModel model = FolderController.LoadFile(FilePath);

                    AddTab(model);
                    //carregaarquivo
                    this.Models.Add(model);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AddTab(ScriptModel model)
        {
            if (!tabArquivos.TabPages.ContainsKey(model.Name))
            {

                UCFile myUserControl = new UCFile(model);
                myUserControl.Dock = DockStyle.Fill;
                TabPage myTabPage = new TabPage();
                myTabPage.Text = model.Name;
                myTabPage.Controls.Add(myUserControl);
                tabArquivos.TabPages.Add(myTabPage);
            } 
        }

        private void novoArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void executarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("disp.exe '" + Path.Combine(ProjectDir, MainFile) +"'");
        }
    }
}
