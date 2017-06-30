using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispStudio.Views.UC
{
    public partial class UCFile : UserControl
    {
        private Model.ScriptModel model;

        public UCFile()
        {
            InitializeComponent();
        }

        public UCFile(Model.ScriptModel model)
        {
            InitializeComponent();
            this.model = model;

            this.rtbProgram.Text = model.Content;
        }
    }
}
