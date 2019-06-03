

#region using statements


#endregion

namespace NoteBoard.Client.Controls
{

    #region class NoteHoverControl
    /// <summary>
    /// this class is the NoteHoverControl
    /// </summary>
    partial class NoteHoverControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label NoteDescriptionLabel;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
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
            #endregion
            
            #region InitializeComponent()
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.NoteDescriptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NoteDescriptionLabel
            // 
            this.NoteDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteDescriptionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.NoteDescriptionLabel.Name = "NoteDescriptionLabel";
            this.NoteDescriptionLabel.Size = new System.Drawing.Size(640, 480);
            this.NoteDescriptionLabel.TabIndex = 0;
            this.NoteDescriptionLabel.Text = "[Note Description]";
            // 
            // NoteHoverControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.NoteDescriptionLabel);
            this.DoubleBuffered = true;
            this.Name = "NoteHoverControl";
            this.Size = new System.Drawing.Size(640, 480);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
