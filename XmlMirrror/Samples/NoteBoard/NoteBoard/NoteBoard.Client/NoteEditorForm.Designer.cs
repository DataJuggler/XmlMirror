namespace NoteBoard
{
    partial class NoteEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteEditorForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PriorityControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.DescriptionControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.TitleControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.IdControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Black_Button;
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CancelButton.Location = new System.Drawing.Point(668, 372);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 36);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.CancelButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CancelButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.BackgroundImage = global::NoteBoard.Client.Properties.Resources.Black_Button;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.SaveButton.Location = new System.Drawing.Point(542, 372);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 36);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // PriorityControl
            // 
            this.PriorityControl.BackColor = System.Drawing.Color.Transparent;
            this.PriorityControl.ComboBoxLeftMargin = 1;
            this.PriorityControl.ComboBoxText = "";
            this.PriorityControl.ComoboBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriorityControl.Editable = true;
            this.PriorityControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriorityControl.HideLabel = false;
            this.PriorityControl.LabelBottomMargin = 0;
            this.PriorityControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.PriorityControl.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriorityControl.LabelText = "Priority:";
            this.PriorityControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PriorityControl.LabelTopMargin = 0;
            this.PriorityControl.LabelWidth = 160;
            this.PriorityControl.List = null;
            this.PriorityControl.Location = new System.Drawing.Point(20, 242);
            this.PriorityControl.Name = "PriorityControl";
            this.PriorityControl.SelectedIndex = -1;
            this.PriorityControl.SelectedIndexListener = null;
            this.PriorityControl.Size = new System.Drawing.Size(709, 28);
            this.PriorityControl.Sorted = false;
            this.PriorityControl.Source = null;
            this.PriorityControl.TabIndex = 2;
            // 
            // DescriptionControl
            // 
            this.DescriptionControl.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionControl.BottomMargin = 0;
            this.DescriptionControl.Editable = true;
            this.DescriptionControl.Encrypted = false;
            this.DescriptionControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionControl.LabelBottomMargin = 0;
            this.DescriptionControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.DescriptionControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionControl.LabelText = "Description:";
            this.DescriptionControl.LabelTextAlign = System.Drawing.ContentAlignment.TopRight;
            this.DescriptionControl.LabelTopMargin = 0;
            this.DescriptionControl.LabelWidth = 160;
            this.DescriptionControl.Location = new System.Drawing.Point(20, 60);
            this.DescriptionControl.MultiLine = true;
            this.DescriptionControl.Name = "DescriptionControl";
            this.DescriptionControl.OnTextChangedListener = null;
            this.DescriptionControl.PasswordMode = false;
            this.DescriptionControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DescriptionControl.Size = new System.Drawing.Size(709, 174);
            this.DescriptionControl.TabIndex = 1;
            this.DescriptionControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DescriptionControl.TextBoxBottomMargin = 0;
            this.DescriptionControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.DescriptionControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.DescriptionControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionControl.TextBoxTopMargin = 0;
            // 
            // TitleControl
            // 
            this.TitleControl.BackColor = System.Drawing.Color.Transparent;
            this.TitleControl.BottomMargin = 0;
            this.TitleControl.Editable = true;
            this.TitleControl.Encrypted = false;
            this.TitleControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleControl.LabelBottomMargin = 0;
            this.TitleControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.TitleControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleControl.LabelText = "Title:";
            this.TitleControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TitleControl.LabelTopMargin = 0;
            this.TitleControl.LabelWidth = 160;
            this.TitleControl.Location = new System.Drawing.Point(20, 20);
            this.TitleControl.MultiLine = false;
            this.TitleControl.Name = "TitleControl";
            this.TitleControl.OnTextChangedListener = null;
            this.TitleControl.PasswordMode = false;
            this.TitleControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TitleControl.Size = new System.Drawing.Size(709, 32);
            this.TitleControl.TabIndex = 0;
            this.TitleControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TitleControl.TextBoxBottomMargin = 0;
            this.TitleControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.TitleControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.TitleControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleControl.TextBoxTopMargin = 0;
            // 
            // IdControl
            // 
            this.IdControl.BackColor = System.Drawing.Color.Transparent;
            this.IdControl.BottomMargin = 0;
            this.IdControl.Editable = true;
            this.IdControl.Encrypted = false;
            this.IdControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdControl.LabelBottomMargin = 0;
            this.IdControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.IdControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdControl.LabelText = "Id:";
            this.IdControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IdControl.LabelTopMargin = 0;
            this.IdControl.LabelWidth = 160;
            this.IdControl.Location = new System.Drawing.Point(20, 278);
            this.IdControl.MultiLine = false;
            this.IdControl.Name = "IdControl";
            this.IdControl.OnTextChangedListener = null;
            this.IdControl.PasswordMode = false;
            this.IdControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.IdControl.Size = new System.Drawing.Size(265, 32);
            this.IdControl.TabIndex = 3;
            this.IdControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IdControl.TextBoxBottomMargin = 0;
            this.IdControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.IdControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.IdControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdControl.TextBoxTopMargin = 0;
            // 
            // NoteEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.IdControl);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PriorityControl);
            this.Controls.Add(this.DescriptionControl);
            this.Controls.Add(this.TitleControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoteEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Note Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private DataJuggler.Win.Controls.LabelTextBoxControl TitleControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DescriptionControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl PriorityControl;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl IdControl;
    }
}