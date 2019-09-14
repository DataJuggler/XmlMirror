namespace ResponseParserTest
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ParseXml = new System.Windows.Forms.Button();
            this.EntityUIDControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.EntityLineNumberControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.StatusCodeControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.EntityMarkControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SourceXmlControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            this.SuspendLayout();
            // 
            // ParseXml
            // 
            this.ParseXml.Location = new System.Drawing.Point(23, 28);
            this.ParseXml.Name = "ParseXml";
            this.ParseXml.Size = new System.Drawing.Size(100, 37);
            this.ParseXml.TabIndex = 0;
            this.ParseXml.Text = "Parse";
            this.ParseXml.UseVisualStyleBackColor = true;
            this.ParseXml.Click += new System.EventHandler(this.ParseXml_Click);
            // 
            // EntityUIDControl
            // 
            this.EntityUIDControl.BackColor = System.Drawing.Color.Transparent;
            this.EntityUIDControl.BottomMargin = 0;
            this.EntityUIDControl.Editable = true;
            this.EntityUIDControl.Encrypted = false;
            this.EntityUIDControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntityUIDControl.LabelBottomMargin = 0;
            this.EntityUIDControl.LabelColor = System.Drawing.Color.Black;
            this.EntityUIDControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.EntityUIDControl.LabelText = "Entity UID:";
            this.EntityUIDControl.LabelTopMargin = 0;
            this.EntityUIDControl.LabelWidth = 160;
            this.EntityUIDControl.Location = new System.Drawing.Point(23, 141);
            this.EntityUIDControl.MultiLine = false;
            this.EntityUIDControl.Name = "EntityUIDControl";
            this.EntityUIDControl.OnTextChangedListener = null;
            this.EntityUIDControl.PasswordMode = false;
            this.EntityUIDControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EntityUIDControl.Size = new System.Drawing.Size(360, 32);
            this.EntityUIDControl.TabIndex = 1;
            this.EntityUIDControl.TextBoxBottomMargin = 0;
            this.EntityUIDControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.EntityUIDControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.EntityUIDControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.EntityUIDControl.TextBoxTopMargin = 0;
            // 
            // EntityLineNumberControl
            // 
            this.EntityLineNumberControl.BackColor = System.Drawing.Color.Transparent;
            this.EntityLineNumberControl.BottomMargin = 0;
            this.EntityLineNumberControl.Editable = true;
            this.EntityLineNumberControl.Encrypted = false;
            this.EntityLineNumberControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntityLineNumberControl.LabelBottomMargin = 0;
            this.EntityLineNumberControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.EntityLineNumberControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.EntityLineNumberControl.LabelText = "Line Number:";
            this.EntityLineNumberControl.LabelTopMargin = 0;
            this.EntityLineNumberControl.LabelWidth = 160;
            this.EntityLineNumberControl.Location = new System.Drawing.Point(23, 179);
            this.EntityLineNumberControl.MultiLine = false;
            this.EntityLineNumberControl.Name = "EntityLineNumberControl";
            this.EntityLineNumberControl.OnTextChangedListener = null;
            this.EntityLineNumberControl.PasswordMode = false;
            this.EntityLineNumberControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EntityLineNumberControl.Size = new System.Drawing.Size(360, 32);
            this.EntityLineNumberControl.TabIndex = 2;
            this.EntityLineNumberControl.TextBoxBottomMargin = 0;
            this.EntityLineNumberControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.EntityLineNumberControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.EntityLineNumberControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.EntityLineNumberControl.TextBoxTopMargin = 0;
            // 
            // StatusCodeControl
            // 
            this.StatusCodeControl.BackColor = System.Drawing.Color.Transparent;
            this.StatusCodeControl.BottomMargin = 0;
            this.StatusCodeControl.Editable = true;
            this.StatusCodeControl.Encrypted = false;
            this.StatusCodeControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCodeControl.LabelBottomMargin = 0;
            this.StatusCodeControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.StatusCodeControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.StatusCodeControl.LabelText = "Status Code:";
            this.StatusCodeControl.LabelTopMargin = 0;
            this.StatusCodeControl.LabelWidth = 160;
            this.StatusCodeControl.Location = new System.Drawing.Point(23, 217);
            this.StatusCodeControl.MultiLine = false;
            this.StatusCodeControl.Name = "StatusCodeControl";
            this.StatusCodeControl.OnTextChangedListener = null;
            this.StatusCodeControl.PasswordMode = false;
            this.StatusCodeControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.StatusCodeControl.Size = new System.Drawing.Size(360, 32);
            this.StatusCodeControl.TabIndex = 3;
            this.StatusCodeControl.TextBoxBottomMargin = 0;
            this.StatusCodeControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.StatusCodeControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.StatusCodeControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.StatusCodeControl.TextBoxTopMargin = 0;
            // 
            // EntityMarkControl
            // 
            this.EntityMarkControl.BackColor = System.Drawing.Color.Transparent;
            this.EntityMarkControl.BottomMargin = 0;
            this.EntityMarkControl.Editable = true;
            this.EntityMarkControl.Encrypted = false;
            this.EntityMarkControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntityMarkControl.LabelBottomMargin = 0;
            this.EntityMarkControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.EntityMarkControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.EntityMarkControl.LabelText = "Entity Mark:";
            this.EntityMarkControl.LabelTopMargin = 0;
            this.EntityMarkControl.LabelWidth = 160;
            this.EntityMarkControl.Location = new System.Drawing.Point(23, 255);
            this.EntityMarkControl.MultiLine = false;
            this.EntityMarkControl.Name = "EntityMarkControl";
            this.EntityMarkControl.OnTextChangedListener = null;
            this.EntityMarkControl.PasswordMode = false;
            this.EntityMarkControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EntityMarkControl.Size = new System.Drawing.Size(360, 32);
            this.EntityMarkControl.TabIndex = 4;
            this.EntityMarkControl.TextBoxBottomMargin = 0;
            this.EntityMarkControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.EntityMarkControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.EntityMarkControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.EntityMarkControl.TextBoxTopMargin = 0;
            // 
            // SourceXmlControl
            // 
            this.SourceXmlControl.BackColor = System.Drawing.Color.Transparent;
            this.SourceXmlControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            this.SourceXmlControl.ButtonImage = ((System.Drawing.Image)(resources.GetObject("SourceXmlControl.ButtonImage")));
            this.SourceXmlControl.ButtonWidth = 48;
            this.SourceXmlControl.DisabledLabelColor = System.Drawing.Color.LightGray;
            this.SourceXmlControl.Editable = false;
            this.SourceXmlControl.EnabledLabelColor = System.Drawing.Color.LemonChiffon;
            this.SourceXmlControl.Filter = null;
            this.SourceXmlControl.Font = new System.Drawing.Font("Verdana", 12F);
            this.SourceXmlControl.HideBrowseButton = false;
            this.SourceXmlControl.LabelBottomMargin = 0;
            this.SourceXmlControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.SourceXmlControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.SourceXmlControl.LabelText = "Xml File:";
            this.SourceXmlControl.LabelTopMargin = 0;
            this.SourceXmlControl.LabelWidth = 160;
            this.SourceXmlControl.Location = new System.Drawing.Point(23, 103);
            this.SourceXmlControl.Name = "SourceXmlControl";
            this.SourceXmlControl.OnTextChangedListener = null;
            this.SourceXmlControl.OpenCallback = null;
            this.SourceXmlControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SourceXmlControl.SelectedPath = null;
            this.SourceXmlControl.Size = new System.Drawing.Size(400, 32);
            this.SourceXmlControl.StartPath = null;
            this.SourceXmlControl.TabIndex = 5;
            this.SourceXmlControl.TextBoxBottomMargin = 0;
            this.SourceXmlControl.TextBoxDisabledColor = System.Drawing.Color.Empty;
            this.SourceXmlControl.TextBoxEditableColor = System.Drawing.Color.Empty;
            this.SourceXmlControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.SourceXmlControl.TextBoxTopMargin = 0;
            this.SourceXmlControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 337);
            this.Controls.Add(this.SourceXmlControl);
            this.Controls.Add(this.EntityMarkControl);
            this.Controls.Add(this.StatusCodeControl);
            this.Controls.Add(this.EntityLineNumberControl);
            this.Controls.Add(this.EntityUIDControl);
            this.Controls.Add(this.ParseXml);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ParseXml;
        private DataJuggler.Win.Controls.LabelTextBoxControl EntityUIDControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl EntityLineNumberControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl StatusCodeControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl EntityMarkControl;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl SourceXmlControl;
    }
}

