namespace DispStudio.Views.UC
{
    partial class UCFile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbProgram = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbProgram
            // 
            this.rtbProgram.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbProgram.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbProgram.Location = new System.Drawing.Point(0, 0);
            this.rtbProgram.Name = "rtbProgram";
            this.rtbProgram.Size = new System.Drawing.Size(588, 340);
            this.rtbProgram.TabIndex = 3;
            this.rtbProgram.Text = "";
            // 
            // UCFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbProgram);
            this.Name = "UCFile";
            this.Size = new System.Drawing.Size(588, 340);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbProgram;
    }
}
