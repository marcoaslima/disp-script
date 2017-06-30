using Disp._Model;
using DispStudio.Controller;
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

namespace DispStudio.Views
{
    public partial class FormNewProject : Form
    {
        public FormMain FormMain { get; set; }

        public FormNewProject()
        {
            InitializeComponent();
        }

        public FormNewProject(FormMain FormMain)
        {
            InitializeComponent();
            this.FormMain = FormMain;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.FormMain.ProjectDir = txtCaminhoProjeto.Text;
            this.FormMain.ProjectName = txtNomeProjeto.Text;

            Directory.CreateDirectory(txtCaminhoProjeto.Text);

            Project proj = new Project(txtNomeProjeto.Text, "main.ds", Disp._Model.Project.PROJECT_TYPE.FULL, "1.0.0.0", "");
            VersionInfo info = new VersionInfo();
            Script script = new Script();

            IniFile inifile = Project.LoadDefault(proj, info, script);
            IniLoader.RecordInitiator(inifile,Path.Combine(txtCaminhoProjeto.Text, "project.dsproj"));

            this.FormMain.LoadProject();

            this.Dispose();
        }

        private void FormNewProject_Load(object sender, EventArgs e)
        {
            cbxVersaoCompilador.SelectedIndex = 0;
            txtCaminhoProjeto.Text = this.FormMain.Loader.ProjectsFolder;
        }

        private void txtNomeProjeto_TextChanged(object sender, EventArgs e)
        {
            if (chkCriarDiretorioProjeto.Checked)
            {
                txtCaminhoProjeto.Text = Path.Combine(this.FormMain.Loader.ProjectsFolder, txtNomeProjeto.Text);
            }
        }

        private void chkCriarDiretorioProjeto_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkCriarDiretorioProjeto.Checked)
            {
                txtCaminhoProjeto.Text = Path.Combine(this.FormMain.Loader.ProjectsFolder, txtNomeProjeto.Text);
            }
            else
            {
                txtCaminhoProjeto.Text = this.FormMain.Loader.ProjectsFolder;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
