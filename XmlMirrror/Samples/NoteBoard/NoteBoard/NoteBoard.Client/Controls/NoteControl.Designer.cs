

#region using statements


#endregion

namespace NoteBoard.Client.Controls
{

    #region class NoteControl
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class NoteControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;        
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.EditNoteButton = new System.Windows.Forms.PictureBox();
            this.DeleteNoteButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EditNoteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteNoteButton)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(47, 32);
            this.TitleLabel.MaximumSize = new System.Drawing.Size(176, 144);
            this.TitleLabel.MinimumSize = new System.Drawing.Size(176, 144);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(176, 144);
            this.TitleLabel.TabIndex = 15;
            this.TitleLabel.Text = "[Note Title]";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLabel.Click += new System.EventHandler(this.NoteControl_Selected);
            this.TitleLabel.DoubleClick += new System.EventHandler(this.NoteControl_DoubleClick);
            this.TitleLabel.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.TitleLabel.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // EditNoteButton
            // 
            this.EditNoteButton.BackColor = System.Drawing.Color.Transparent;
            this.EditNoteButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Edit_Button;
            this.EditNoteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditNoteButton.Location = new System.Drawing.Point(0, 0);
            this.EditNoteButton.MaximumSize = new System.Drawing.Size(32, 32);
            this.EditNoteButton.Name = "EditNoteButton";
            this.EditNoteButton.Size = new System.Drawing.Size(32, 32);
            this.EditNoteButton.TabIndex = 16;
            this.EditNoteButton.TabStop = false;
            this.EditNoteButton.Click += new System.EventHandler(this.EditNoteButton_Click);
            this.EditNoteButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.EditNoteButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DeleteNoteButton
            // 
            this.DeleteNoteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteNoteButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Delete_Button;
            this.DeleteNoteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteNoteButton.Location = new System.Drawing.Point(238, 0);
            this.DeleteNoteButton.Name = "DeleteNoteButton";
            this.DeleteNoteButton.Size = new System.Drawing.Size(32, 32);
            this.DeleteNoteButton.TabIndex = 17;
            this.DeleteNoteButton.TabStop = false;
            this.DeleteNoteButton.Click += new System.EventHandler(this.DeleteNoteButton_Click);
            this.DeleteNoteButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.DeleteNoteButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // NoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Post_It_Note_A_3M_Trademark_Small;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.DeleteNoteButton);
            this.Controls.Add(this.EditNoteButton);
            this.Controls.Add(this.TitleLabel);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(270, 200);
            this.Name = "NoteControl";
            this.Size = new System.Drawing.Size(270, 200);
            this.Click += new System.EventHandler(this.NoteControl_Selected);
            this.DoubleClick += new System.EventHandler(this.NoteControl_DoubleClick);
            this.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.MouseLeave += new System.EventHandler(this.Button_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.EditNoteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteNoteButton)).EndInit();
            this.ResumeLayout(false);

            }
        #endregion

        #endregion
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox EditNoteButton;
        private System.Windows.Forms.PictureBox DeleteNoteButton;
    }
    #endregion

}
