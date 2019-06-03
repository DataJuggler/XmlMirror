

#region using statements


#endregion

namespace NoteBoard.Client
{

    #region class MainForm
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NoteHoverControl = new NoteBoard.Client.Controls.NoteHoverControl();
            this.DisableHoveringControl = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.PromptForDeleteControl = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.DeleteNoteButton = new System.Windows.Forms.PictureBox();
            this.EditNoteButton = new System.Windows.Forms.PictureBox();
            this.AddNoteButton = new System.Windows.Forms.PictureBox();
            this.HighPriorityButton = new System.Windows.Forms.PictureBox();
            this.LowPriorityButton = new System.Windows.Forms.PictureBox();
            this.NormalPriorityButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteNoteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditNoteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNoteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighPriorityButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowPriorityButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPriorityButton)).BeginInit();
            this.SuspendLayout();
            // 
            // NoteHoverControl
            // 
            this.NoteHoverControl.BackColor = System.Drawing.Color.LemonChiffon;
            this.NoteHoverControl.Location = new System.Drawing.Point(800, 220);
            this.NoteHoverControl.Name = "NoteHoverControl";
            this.NoteHoverControl.Size = new System.Drawing.Size(320, 200);
            this.NoteHoverControl.TabIndex = 9;
            this.NoteHoverControl.Visible = false;
            // 
            // DisableHoveringControl
            // 
            this.DisableHoveringControl.BackColor = System.Drawing.Color.Transparent;
            this.DisableHoveringControl.CheckBoxHorizontalOffSet = 0;
            this.DisableHoveringControl.CheckBoxVerticalOffSet = 3;
            this.DisableHoveringControl.CheckChangedListener = null;
            this.DisableHoveringControl.Checked = false;
            this.DisableHoveringControl.Editable = true;
            this.DisableHoveringControl.Font = new System.Drawing.Font("Verdana", 12F);
            this.DisableHoveringControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.DisableHoveringControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.DisableHoveringControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisableHoveringControl.LabelText = "Disable Hovering:";
            this.DisableHoveringControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DisableHoveringControl.LabelWidth = 188;
            this.DisableHoveringControl.Location = new System.Drawing.Point(500, 18);
            this.DisableHoveringControl.Name = "DisableHoveringControl";
            this.DisableHoveringControl.Size = new System.Drawing.Size(221, 28);
            this.DisableHoveringControl.TabIndex = 17;
            // 
            // PromptForDeleteControl
            // 
            this.PromptForDeleteControl.BackColor = System.Drawing.Color.Transparent;
            this.PromptForDeleteControl.CheckBoxHorizontalOffSet = 0;
            this.PromptForDeleteControl.CheckBoxVerticalOffSet = 3;
            this.PromptForDeleteControl.CheckChangedListener = null;
            this.PromptForDeleteControl.Checked = true;
            this.PromptForDeleteControl.Editable = true;
            this.PromptForDeleteControl.Font = new System.Drawing.Font("Verdana", 12F);
            this.PromptForDeleteControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.PromptForDeleteControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.PromptForDeleteControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromptForDeleteControl.LabelText = "Prompt For Delete:";
            this.PromptForDeleteControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PromptForDeleteControl.LabelWidth = 188;
            this.PromptForDeleteControl.Location = new System.Drawing.Point(300, 18);
            this.PromptForDeleteControl.Name = "PromptForDeleteControl";
            this.PromptForDeleteControl.Size = new System.Drawing.Size(221, 28);
            this.PromptForDeleteControl.TabIndex = 16;
            // 
            // DeleteNoteButton
            // 
            this.DeleteNoteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteNoteButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Delete_Button;
            this.DeleteNoteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteNoteButton.Location = new System.Drawing.Point(228, 0);
            this.DeleteNoteButton.Name = "DeleteNoteButton";
            this.DeleteNoteButton.Size = new System.Drawing.Size(64, 64);
            this.DeleteNoteButton.TabIndex = 15;
            this.DeleteNoteButton.TabStop = false;
            this.DeleteNoteButton.Click += new System.EventHandler(this.DeleteNoteButton_Click);
            this.DeleteNoteButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.DeleteNoteButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // EditNoteButton
            // 
            this.EditNoteButton.BackColor = System.Drawing.Color.Transparent;
            this.EditNoteButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Edit_Button;
            this.EditNoteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditNoteButton.Location = new System.Drawing.Point(148, 0);
            this.EditNoteButton.Name = "EditNoteButton";
            this.EditNoteButton.Size = new System.Drawing.Size(64, 64);
            this.EditNoteButton.TabIndex = 14;
            this.EditNoteButton.TabStop = false;
            this.EditNoteButton.Click += new System.EventHandler(this.EditNoteButton_Click);
            this.EditNoteButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.EditNoteButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // AddNoteButton
            // 
            this.AddNoteButton.BackColor = System.Drawing.Color.Transparent;
            this.AddNoteButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Add_Button;
            this.AddNoteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNoteButton.Location = new System.Drawing.Point(68, 0);
            this.AddNoteButton.Name = "AddNoteButton";
            this.AddNoteButton.Size = new System.Drawing.Size(64, 64);
            this.AddNoteButton.TabIndex = 13;
            this.AddNoteButton.TabStop = false;
            this.AddNoteButton.Click += new System.EventHandler(this.AddNoteButton_Click);
            this.AddNoteButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.AddNoteButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // HighPriorityButton
            // 
            this.HighPriorityButton.BackColor = System.Drawing.Color.Transparent;
            this.HighPriorityButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.High;
            this.HighPriorityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HighPriorityButton.Location = new System.Drawing.Point(0, 100);
            this.HighPriorityButton.Name = "HighPriorityButton";
            this.HighPriorityButton.Size = new System.Drawing.Size(40, 180);
            this.HighPriorityButton.TabIndex = 18;
            this.HighPriorityButton.TabStop = false;
            this.HighPriorityButton.Click += new System.EventHandler(this.Unselect_Click);
            // 
            // LowPriorityButton
            // 
            this.LowPriorityButton.BackColor = System.Drawing.Color.Transparent;
            this.LowPriorityButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Low;
            this.LowPriorityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LowPriorityButton.Location = new System.Drawing.Point(0, 500);
            this.LowPriorityButton.Name = "LowPriorityButton";
            this.LowPriorityButton.Size = new System.Drawing.Size(40, 180);
            this.LowPriorityButton.TabIndex = 19;
            this.LowPriorityButton.TabStop = false;
            this.LowPriorityButton.Click += new System.EventHandler(this.Unselect_Click);
            // 
            // NormalPriorityButton
            // 
            this.NormalPriorityButton.BackColor = System.Drawing.Color.Transparent;
            this.NormalPriorityButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Normal;
            this.NormalPriorityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalPriorityButton.Location = new System.Drawing.Point(0, 300);
            this.NormalPriorityButton.Name = "NormalPriorityButton";
            this.NormalPriorityButton.Size = new System.Drawing.Size(40, 180);
            this.NormalPriorityButton.TabIndex = 20;
            this.NormalPriorityButton.TabStop = false;
            this.NormalPriorityButton.Click += new System.EventHandler(this.Unselect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Deep_Black;
            this.ClientSize = new System.Drawing.Size(1124, 761);
            this.Controls.Add(this.NormalPriorityButton);
            this.Controls.Add(this.LowPriorityButton);
            this.Controls.Add(this.HighPriorityButton);
            this.Controls.Add(this.DisableHoveringControl);
            this.Controls.Add(this.PromptForDeleteControl);
            this.Controls.Add(this.DeleteNoteButton);
            this.Controls.Add(this.EditNoteButton);
            this.Controls.Add(this.AddNoteButton);
            this.Controls.Add(this.NoteHoverControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Note Board";
            ((System.ComponentModel.ISupportInitialize)(this.DeleteNoteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditNoteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNoteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighPriorityButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowPriorityButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPriorityButton)).EndInit();
            this.ResumeLayout(false);

            }
        #endregion

        #endregion
        internal Controls.NoteHoverControl NoteHoverControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl DisableHoveringControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl PromptForDeleteControl;
        private System.Windows.Forms.PictureBox DeleteNoteButton;
        private System.Windows.Forms.PictureBox EditNoteButton;
        private System.Windows.Forms.PictureBox AddNoteButton;
        private System.Windows.Forms.PictureBox HighPriorityButton;
        private System.Windows.Forms.PictureBox LowPriorityButton;
        private System.Windows.Forms.PictureBox NormalPriorityButton;
    }
    #endregion

}
