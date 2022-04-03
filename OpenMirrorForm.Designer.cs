namespace XmlMirror
{
    partial class OpenMirrorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenMirrorForm));
            this.MirrorFilesListBox = new System.Windows.Forms.ListBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.DeleteInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MirrorFilesListBox
            // 
            this.MirrorFilesListBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MirrorFilesListBox.FormattingEnabled = true;
            this.MirrorFilesListBox.ItemHeight = 18;
            this.MirrorFilesListBox.Location = new System.Drawing.Point(23, 52);
            this.MirrorFilesListBox.Name = "MirrorFilesListBox";
            this.MirrorFilesListBox.Size = new System.Drawing.Size(391, 310);
            this.MirrorFilesListBox.TabIndex = 3;
            this.MirrorFilesListBox.DoubleClick += new System.EventHandler(this.MirrorFilesListBox_DoubleClick);
            this.MirrorFilesListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MirrorFilesListBox_KeyDown);
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(20, 26);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(394, 23);
            this.InfoLabel.TabIndex = 4;
            this.InfoLabel.Text = "Double click on a mirror name to load";
            // 
            // DeleteInfoLabel
            // 
            this.DeleteInfoLabel.AutoSize = true;
            this.DeleteInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.DeleteInfoLabel.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.DeleteInfoLabel.Location = new System.Drawing.Point(42, 368);
            this.DeleteInfoLabel.Name = "DeleteInfoLabel";
            this.DeleteInfoLabel.Size = new System.Drawing.Size(345, 23);
            this.DeleteInfoLabel.TabIndex = 5;
            this.DeleteInfoLabel.Text = "(Press \'Delete\' to remove a mirror)";
            // 
            // OpenMirrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;            
            this.ClientSize = new System.Drawing.Size(439, 409);
            this.Controls.Add(this.DeleteInfoLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.MirrorFilesListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpenMirrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Mirror";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MirrorFilesListBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label DeleteInfoLabel;
    }
}