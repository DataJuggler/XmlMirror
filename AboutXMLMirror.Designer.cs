﻿

#region using statements


#endregion

namespace XmlMirror
{

    #region class AboutXMLMirror
    /// <summary>
    /// This method [Enter Method Description]
    /// </summary>
    partial class AboutXMLMirror
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel LeftFillerPanel;
        private System.Windows.Forms.Label CompanyNameLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MarginPanel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label DescriptionLabel;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutXMLMirror));
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LeftFillerPanel = new System.Windows.Forms.Panel();
            this.CompanyNameLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MarginPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LogoPictureBox.BackgroundImage = global::XmlMirror.Properties.Resources.Xml_Mirror_plus_Xml_Text;
            this.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoPictureBox.Location = new System.Drawing.Point(9, 120);
            this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(215, 212);
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.InfoPanel.Controls.Add(this.DescriptionLabel);
            this.InfoPanel.Controls.Add(this.OKButton);
            this.InfoPanel.Controls.Add(this.panel2);
            this.InfoPanel.Controls.Add(this.LeftFillerPanel);
            this.InfoPanel.Controls.Add(this.CompanyNameLabel);
            this.InfoPanel.Controls.Add(this.CopyrightLabel);
            this.InfoPanel.Controls.Add(this.VersionLabel);
            this.InfoPanel.Controls.Add(this.label1);
            this.InfoPanel.Controls.Add(this.MarginPanel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.InfoPanel.Location = new System.Drawing.Point(241, 0);
            this.InfoPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(324, 440);
            this.InfoPanel.TabIndex = 1;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.BackColor = System.Drawing.Color.AntiqueWhite;
            this.DescriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DescriptionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DescriptionLabel.Location = new System.Drawing.Point(4, 122);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescriptionLabel.MaximumSize = new System.Drawing.Size(303, 254);
            this.DescriptionLabel.MinimumSize = new System.Drawing.Size(303, 254);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(303, 254);
            this.DescriptionLabel.TabIndex = 19;
            this.DescriptionLabel.Text = "Xml Mirror makes creating Xml parsers and writers simple by using reflection to r" +
    "ead and write property values.\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.Transparent;
            this.OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKButton.BackgroundImage")));
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OKButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.OKButton.Location = new System.Drawing.Point(214, 389);
            this.OKButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(93, 37);
            this.OKButton.TabIndex = 18;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            this.OKButton.MouseEnter += new System.EventHandler(this.OKButton_MouseEnter);
            this.OKButton.MouseLeave += new System.EventHandler(this.OKButton_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 117);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 5);
            this.panel2.TabIndex = 9;
            // 
            // LeftFillerPanel
            // 
            this.LeftFillerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftFillerPanel.Location = new System.Drawing.Point(0, 117);
            this.LeftFillerPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LeftFillerPanel.Name = "LeftFillerPanel";
            this.LeftFillerPanel.Size = new System.Drawing.Size(4, 323);
            this.LeftFillerPanel.TabIndex = 7;
            // 
            // CompanyNameLabel
            // 
            this.CompanyNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyNameLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompanyNameLabel.Location = new System.Drawing.Point(0, 90);
            this.CompanyNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CompanyNameLabel.Name = "CompanyNameLabel";
            this.CompanyNameLabel.Size = new System.Drawing.Size(324, 27);
            this.CompanyNameLabel.TabIndex = 5;
            this.CompanyNameLabel.Text = "Data Juggler Software";
            this.CompanyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CopyrightLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CopyrightLabel.Location = new System.Drawing.Point(0, 63);
            this.CopyrightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(324, 27);
            this.CopyrightLabel.TabIndex = 4;
            this.CopyrightLabel.Text = "Copyright 2012 - 2022";
            this.CopyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VersionLabel
            // 
            this.VersionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.VersionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VersionLabel.Location = new System.Drawing.Point(0, 36);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(324, 27);
            this.VersionLabel.TabIndex = 3;
            this.VersionLabel.Text = "6.0.3";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "XML Mirror";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MarginPanel
            // 
            this.MarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MarginPanel.Location = new System.Drawing.Point(0, 0);
            this.MarginPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MarginPanel.Name = "MarginPanel";
            this.MarginPanel.Size = new System.Drawing.Size(324, 9);
            this.MarginPanel.TabIndex = 1;
            // 
            // AboutXMLMirror
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::XmlMirror.Properties.Resources.OrangeBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(565, 440);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.LogoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AboutXMLMirror";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About XML Mirror";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
            #endregion

        #endregion

        
    }
    #endregion

}
