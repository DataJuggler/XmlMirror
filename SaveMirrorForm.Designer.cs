namespace XmlMirror
{
    partial class SaveMirrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveMirrorForm));
            this.MirrorFileNameTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.CancelSaveButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MirrorFileNameTextBox
            // 
            this.MirrorFileNameTextBox.BackColor = System.Drawing.Color.Transparent;
            this.MirrorFileNameTextBox.BottomMargin = 0;
            this.MirrorFileNameTextBox.Editable = true;
            this.MirrorFileNameTextBox.Encrypted = false;
            this.MirrorFileNameTextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MirrorFileNameTextBox.LabelBottomMargin = 0;
            this.MirrorFileNameTextBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.MirrorFileNameTextBox.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.MirrorFileNameTextBox.LabelText = "Mirror Filename:";
            this.MirrorFileNameTextBox.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MirrorFileNameTextBox.LabelTopMargin = 0;
            this.MirrorFileNameTextBox.LabelWidth = 140;
            this.MirrorFileNameTextBox.Location = new System.Drawing.Point(12, 25);
            this.MirrorFileNameTextBox.MultiLine = false;
            this.MirrorFileNameTextBox.Name = "MirrorFileNameTextBox";
            this.MirrorFileNameTextBox.OnTextChangedListener = null;
            this.MirrorFileNameTextBox.PasswordMode = false;
            this.MirrorFileNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MirrorFileNameTextBox.Size = new System.Drawing.Size(440, 22);
            this.MirrorFileNameTextBox.TabIndex = 1;
            this.MirrorFileNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MirrorFileNameTextBox.TextBoxBottomMargin = 0;
            this.MirrorFileNameTextBox.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.MirrorFileNameTextBox.TextBoxEditableColor = System.Drawing.Color.White;
            this.MirrorFileNameTextBox.TextBoxFont = new System.Drawing.Font("Verdana", 10F);
            this.MirrorFileNameTextBox.TextBoxTopMargin = 0;
            // 
            // CancelSaveButton
            // 
            this.CancelSaveButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelSaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelSaveButton.BackgroundImage")));
            this.CancelSaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelSaveButton.FlatAppearance.BorderSize = 0;
            this.CancelSaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelSaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSaveButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F);
            this.CancelSaveButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.CancelSaveButton.Location = new System.Drawing.Point(352, 101);
            this.CancelSaveButton.Name = "CancelSaveButton";
            this.CancelSaveButton.Size = new System.Drawing.Size(100, 32);
            this.CancelSaveButton.TabIndex = 18;
            this.CancelSaveButton.Text = "Cancel";
            this.CancelSaveButton.UseVisualStyleBackColor = false;
            this.CancelSaveButton.Click += new System.EventHandler(this.CancelSaveButton_Click);
            this.CancelSaveButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CancelSaveButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F);
            this.SaveButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.SaveButton.Location = new System.Drawing.Point(240, 101);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 32);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // SaveMirrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;            
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(472, 145);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelSaveButton);
            this.Controls.Add(this.MirrorFileNameTextBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveMirrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Mirror ";
            this.ResumeLayout(false);

        }

        #endregion

        private DataJuggler.Win.Controls.LabelTextBoxControl MirrorFileNameTextBox;
        private System.Windows.Forms.Button CancelSaveButton;
        private System.Windows.Forms.Button SaveButton;
    }
}