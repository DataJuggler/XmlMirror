

#region using statements


#endregion

namespace XmlMirror
{

    #region class MainForm
    /// <summary>
    /// This is the designer for the MainForm object.
    /// </summary>
    public partial class MainForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private DataJuggler.Win.Controls.LabelTextBoxControl SourceXmlFileTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TreeView XmlTreeView;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Button BrowseForAssemblyButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl TargetDllTextBox;
        private DataJuggler.Win.Controls.LabelComboBoxControl TargetClassComboBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl ClassNameControl;
        private System.Windows.Forms.TreeView TargetTreeView;
        private DataJuggler.Win.Controls.LabelTextBoxControl OutputFolderControl;
        private System.Windows.Forms.Button BrowseForOutputFolderButton;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Button LoadMirrorButton;
        private System.Windows.Forms.Button SaveMirrorButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl NamespaceControl;
        private System.Windows.Forms.ImageList Images;
        private System.Windows.Forms.PictureBox F1Image;
        private System.Windows.Forms.Label F1Label;
        private System.Windows.Forms.Label F1DetailLabel;
        private System.Windows.Forms.Label F2DetailLabel;
        private System.Windows.Forms.Label F2Label;
        private System.Windows.Forms.PictureBox F2Image;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ClearFieldLink;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VideoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewWordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewPDFMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WatchYouTubeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.RadioButton XmlParserRadioButton;
        private System.Windows.Forms.RadioButton XmlWriterRadioButton;
        private System.Windows.Forms.Label CollectionInfoLabel;
        private System.Windows.Forms.Button AutoFillButton;
        private System.Windows.Forms.Button HiddenButton;
        private System.Windows.Forms.ToolStripMenuItem SkipFieldMenuItem;
        private System.Windows.Forms.ImageList TargetImages;
        private DataJuggler.Win.Controls.Objects.PanelExtender RightMarginPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender RightPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender YouTubeButtonContainer;
        private System.Windows.Forms.PictureBox YouTubeButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender BottomMarginPanel;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BrowseButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.XmlTreeView = new System.Windows.Forms.TreeView();
            this.Images = new System.Windows.Forms.ImageList(this.components);
            this.TargetLabel = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.BuildButton = new System.Windows.Forms.Button();
            this.BrowseForAssemblyButton = new System.Windows.Forms.Button();
            this.TargetTreeView = new System.Windows.Forms.TreeView();
            this.TargetImages = new System.Windows.Forms.ImageList(this.components);
            this.BrowseForOutputFolderButton = new System.Windows.Forms.Button();
            this.ViewButton = new System.Windows.Forms.Button();
            this.LoadMirrorButton = new System.Windows.Forms.Button();
            this.SaveMirrorButton = new System.Windows.Forms.Button();
            this.F1Image = new System.Windows.Forms.PictureBox();
            this.F1Label = new System.Windows.Forms.Label();
            this.F1DetailLabel = new System.Windows.Forms.Label();
            this.F2DetailLabel = new System.Windows.Forms.Label();
            this.F2Label = new System.Windows.Forms.Label();
            this.F2Image = new System.Windows.Forms.PictureBox();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClearFieldLink = new System.Windows.Forms.ToolStripMenuItem();
            this.SkipFieldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewWordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewPDFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WatchYouTubeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XmlParserRadioButton = new System.Windows.Forms.RadioButton();
            this.XmlWriterRadioButton = new System.Windows.Forms.RadioButton();
            this.NamespaceControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.OutputFolderControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.ClassNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.TargetClassComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.TargetDllTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SourceXmlFileTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.CollectionInfoLabel = new System.Windows.Forms.Label();
            this.AutoFillButton = new System.Windows.Forms.Button();
            this.HiddenButton = new System.Windows.Forms.Button();
            this.RightMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.RightPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.YouTubeButtonContainer = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.YouTubeButton = new System.Windows.Forms.PictureBox();
            this.BottomMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            ((System.ComponentModel.ISupportInitialize)(this.F1Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.F2Image)).BeginInit();
            this.ContextMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.YouTubeButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YouTubeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseButton.BackgroundImage")));
            this.BrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BrowseButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.BrowseButton.Location = new System.Drawing.Point(760, 32);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(48, 28);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            this.BrowseButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BrowseButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Transparent;
            this.StartButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartButton.BackgroundImage")));
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.StartButton.Location = new System.Drawing.Point(769, 67);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(80, 32);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            this.StartButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.StartButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // XmlTreeView
            // 
            this.XmlTreeView.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.XmlTreeView.ImageIndex = 0;
            this.XmlTreeView.ImageList = this.Images;
            this.XmlTreeView.Location = new System.Drawing.Point(57, 67);
            this.XmlTreeView.Name = "XmlTreeView";
            this.XmlTreeView.SelectedImageIndex = 0;
            this.XmlTreeView.Size = new System.Drawing.Size(708, 156);
            this.XmlTreeView.TabIndex = 3;
            this.XmlTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.XmlTreeView_ItemDrag);
            this.XmlTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XmlTreeView_KeyDown);
            // 
            // Images
            // 
            this.Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
            this.Images.TransparentColor = System.Drawing.Color.Transparent;
            this.Images.Images.SetKeyName(0, "Blank.png");
            this.Images.Images.SetKeyName(1, "NewObject.ico");
            this.Images.Images.SetKeyName(2, "NewCollection.ico");
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.BackColor = System.Drawing.Color.Transparent;
            this.TargetLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.TargetLabel.Location = new System.Drawing.Point(53, 313);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(166, 21);
            this.TargetLabel.TabIndex = 6;
            this.TargetLabel.Text = "Target Object";
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.Transparent;
            this.DoneButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DoneButton.BackgroundImage")));
            this.DoneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoneButton.FlatAppearance.BorderSize = 0;
            this.DoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DoneButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.DoneButton.Location = new System.Drawing.Point(672, 672);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(92, 32);
            this.DoneButton.TabIndex = 9;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            this.DoneButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.DoneButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // BuildButton
            // 
            this.BuildButton.BackColor = System.Drawing.Color.Transparent;
            this.BuildButton.BackgroundImage = global::XmlMirror.Properties.Resources.DarkButton;
            this.BuildButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BuildButton.FlatAppearance.BorderSize = 0;
            this.BuildButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BuildButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BuildButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuildButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BuildButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.BuildButton.Location = new System.Drawing.Point(499, 672);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(160, 32);
            this.BuildButton.TabIndex = 8;
            this.BuildButton.Text = "Build Parser";
            this.BuildButton.UseVisualStyleBackColor = false;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            this.BuildButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BuildButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // BrowseForAssemblyButton
            // 
            this.BrowseForAssemblyButton.BackColor = System.Drawing.Color.Transparent;
            this.BrowseForAssemblyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseForAssemblyButton.BackgroundImage")));
            this.BrowseForAssemblyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseForAssemblyButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BrowseForAssemblyButton.FlatAppearance.BorderSize = 0;
            this.BrowseForAssemblyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BrowseForAssemblyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BrowseForAssemblyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseForAssemblyButton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BrowseForAssemblyButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.BrowseForAssemblyButton.Location = new System.Drawing.Point(764, 337);
            this.BrowseForAssemblyButton.Name = "BrowseForAssemblyButton";
            this.BrowseForAssemblyButton.Size = new System.Drawing.Size(48, 28);
            this.BrowseForAssemblyButton.TabIndex = 11;
            this.BrowseForAssemblyButton.Text = "...";
            this.BrowseForAssemblyButton.UseVisualStyleBackColor = false;
            this.BrowseForAssemblyButton.Click += new System.EventHandler(this.BrowseForAssemblyButton_Click);
            this.BrowseForAssemblyButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BrowseForAssemblyButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // TargetTreeView
            // 
            this.TargetTreeView.AllowDrop = true;
            this.TargetTreeView.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetTreeView.ImageIndex = 0;
            this.TargetTreeView.ImageList = this.TargetImages;
            this.TargetTreeView.Location = new System.Drawing.Point(57, 506);
            this.TargetTreeView.Name = "TargetTreeView";
            this.TargetTreeView.SelectedImageIndex = 0;
            this.TargetTreeView.Size = new System.Drawing.Size(708, 156);
            this.TargetTreeView.StateImageList = this.Images;
            this.TargetTreeView.TabIndex = 15;
            // 
            // TargetImages
            // 
            this.TargetImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.TargetImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TargetImages.ImageStream")));
            this.TargetImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TargetImages.Images.SetKeyName(0, "Blank.png");
            this.TargetImages.Images.SetKeyName(1, "Skip.png");
            // 
            // BrowseForOutputFolderButton
            // 
            this.BrowseForOutputFolderButton.BackColor = System.Drawing.Color.Transparent;
            this.BrowseForOutputFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseForOutputFolderButton.BackgroundImage")));
            this.BrowseForOutputFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseForOutputFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BrowseForOutputFolderButton.FlatAppearance.BorderSize = 0;
            this.BrowseForOutputFolderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BrowseForOutputFolderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BrowseForOutputFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseForOutputFolderButton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BrowseForOutputFolderButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.BrowseForOutputFolderButton.Location = new System.Drawing.Point(764, 470);
            this.BrowseForOutputFolderButton.Name = "BrowseForOutputFolderButton";
            this.BrowseForOutputFolderButton.Size = new System.Drawing.Size(48, 28);
            this.BrowseForOutputFolderButton.TabIndex = 16;
            this.BrowseForOutputFolderButton.Text = "...";
            this.BrowseForOutputFolderButton.UseVisualStyleBackColor = false;
            this.BrowseForOutputFolderButton.Click += new System.EventHandler(this.BrowseForOutputFolderButton_Click);
            this.BrowseForOutputFolderButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BrowseForOutputFolderButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ViewButton
            // 
            this.ViewButton.BackColor = System.Drawing.Color.Transparent;
            this.ViewButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewButton.BackgroundImage")));
            this.ViewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewButton.FlatAppearance.BorderSize = 0;
            this.ViewButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ViewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ViewButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.ViewButton.Location = new System.Drawing.Point(769, 506);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(80, 32);
            this.ViewButton.TabIndex = 17;
            this.ViewButton.Text = "View";
            this.ViewButton.UseVisualStyleBackColor = false;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            this.ViewButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.ViewButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // LoadMirrorButton
            // 
            this.LoadMirrorButton.BackColor = System.Drawing.Color.Transparent;
            this.LoadMirrorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadMirrorButton.BackgroundImage")));
            this.LoadMirrorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoadMirrorButton.FlatAppearance.BorderSize = 0;
            this.LoadMirrorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LoadMirrorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LoadMirrorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadMirrorButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadMirrorButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.LoadMirrorButton.Location = new System.Drawing.Point(177, 672);
            this.LoadMirrorButton.Name = "LoadMirrorButton";
            this.LoadMirrorButton.Size = new System.Drawing.Size(148, 32);
            this.LoadMirrorButton.TabIndex = 18;
            this.LoadMirrorButton.Text = "Load Mirror";
            this.LoadMirrorButton.UseVisualStyleBackColor = false;
            this.LoadMirrorButton.Click += new System.EventHandler(this.LoadMirrorButton_Click);
            this.LoadMirrorButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.LoadMirrorButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // SaveMirrorButton
            // 
            this.SaveMirrorButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveMirrorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveMirrorButton.BackgroundImage")));
            this.SaveMirrorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveMirrorButton.FlatAppearance.BorderSize = 0;
            this.SaveMirrorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveMirrorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveMirrorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveMirrorButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveMirrorButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.SaveMirrorButton.Location = new System.Drawing.Point(338, 672);
            this.SaveMirrorButton.Name = "SaveMirrorButton";
            this.SaveMirrorButton.Size = new System.Drawing.Size(148, 32);
            this.SaveMirrorButton.TabIndex = 19;
            this.SaveMirrorButton.Text = "Save Mirror";
            this.SaveMirrorButton.UseVisualStyleBackColor = false;
            this.SaveMirrorButton.Click += new System.EventHandler(this.SaveMirrorButton_Click);
            this.SaveMirrorButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.SaveMirrorButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // F1Image
            // 
            this.F1Image.BackColor = System.Drawing.Color.Transparent;
            this.F1Image.Image = ((System.Drawing.Image)(resources.GetObject("F1Image.Image")));
            this.F1Image.Location = new System.Drawing.Point(60, 250);
            this.F1Image.Name = "F1Image";
            this.F1Image.Size = new System.Drawing.Size(24, 24);
            this.F1Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F1Image.TabIndex = 21;
            this.F1Image.TabStop = false;
            // 
            // F1Label
            // 
            this.F1Label.BackColor = System.Drawing.Color.Transparent;
            this.F1Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.F1Label.ForeColor = System.Drawing.Color.LemonChiffon;
            this.F1Label.Location = new System.Drawing.Point(90, 251);
            this.F1Label.Name = "F1Label";
            this.F1Label.Size = new System.Drawing.Size(36, 23);
            this.F1Label.TabIndex = 22;
            this.F1Label.Text = "F1";
            // 
            // F1DetailLabel
            // 
            this.F1DetailLabel.BackColor = System.Drawing.Color.Transparent;
            this.F1DetailLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.F1DetailLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.F1DetailLabel.Location = new System.Drawing.Point(132, 251);
            this.F1DetailLabel.Name = "F1DetailLabel";
            this.F1DetailLabel.Size = new System.Drawing.Size(633, 23);
            this.F1DetailLabel.TabIndex = 23;
            this.F1DetailLabel.Text = "New instances of your object will be created for this node.";
            // 
            // F2DetailLabel
            // 
            this.F2DetailLabel.BackColor = System.Drawing.Color.Transparent;
            this.F2DetailLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.F2DetailLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.F2DetailLabel.Location = new System.Drawing.Point(132, 281);
            this.F2DetailLabel.Name = "F2DetailLabel";
            this.F2DetailLabel.Size = new System.Drawing.Size(732, 23);
            this.F2DetailLabel.TabIndex = 26;
            this.F2DetailLabel.Text = "A typed list <T> will be created for this node (collections only)\r\n";
            // 
            // F2Label
            // 
            this.F2Label.BackColor = System.Drawing.Color.Transparent;
            this.F2Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.F2Label.ForeColor = System.Drawing.Color.LemonChiffon;
            this.F2Label.Location = new System.Drawing.Point(90, 281);
            this.F2Label.Name = "F2Label";
            this.F2Label.Size = new System.Drawing.Size(36, 23);
            this.F2Label.TabIndex = 25;
            this.F2Label.Text = "F2";
            // 
            // F2Image
            // 
            this.F2Image.Image = ((System.Drawing.Image)(resources.GetObject("F2Image.Image")));
            this.F2Image.Location = new System.Drawing.Point(60, 280);
            this.F2Image.Name = "F2Image";
            this.F2Image.Size = new System.Drawing.Size(24, 24);
            this.F2Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F2Image.TabIndex = 24;
            this.F2Image.TabStop = false;
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearFieldLink,
            this.SkipFieldMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(155, 48);
            this.ContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
            // 
            // ClearFieldLink
            // 
            this.ClearFieldLink.Name = "ClearFieldLink";
            this.ClearFieldLink.Size = new System.Drawing.Size(154, 22);
            this.ClearFieldLink.Text = "Clear Field Link";
            this.ClearFieldLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearFieldLink.Click += new System.EventHandler(this.ClearFieldLink_Click);
            // 
            // SkipFieldMenuItem
            // 
            this.SkipFieldMenuItem.Name = "SkipFieldMenuItem";
            this.SkipFieldMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SkipFieldMenuItem.Text = "Skip Field";
            this.SkipFieldMenuItem.Click += new System.EventHandler(this.SkipFieldMenuItem_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenuItem,
            this.AboutMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1064, 26);
            this.MainMenu.TabIndex = 83;
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.AutoSize = false;
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DocumentationMenuItem,
            this.VideoMenuItem});
            this.HelpMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HelpMenuItem.ForeColor = System.Drawing.Color.LemonChiffon;
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(120, 22);
            this.HelpMenuItem.Text = "Help";
            this.HelpMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpMenuItem.DropDownClosed += new System.EventHandler(this.HelpMenuItem_DropDownClosed);
            this.HelpMenuItem.DropDownOpened += new System.EventHandler(this.HelpMenuItem_DropDownOpened);
            this.HelpMenuItem.MouseEnter += new System.EventHandler(this.HelpMenuItem_MouseEnter);
            this.HelpMenuItem.MouseLeave += new System.EventHandler(this.HelpMenuItem_MouseLeave);
            // 
            // DocumentationMenuItem
            // 
            this.DocumentationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewWordMenuItem,
            this.ViewPDFMenuItem});
            this.DocumentationMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DocumentationMenuItem.Image")));
            this.DocumentationMenuItem.Name = "DocumentationMenuItem";
            this.DocumentationMenuItem.Size = new System.Drawing.Size(210, 22);
            this.DocumentationMenuItem.Text = "Documentation";
            this.DocumentationMenuItem.MouseEnter += new System.EventHandler(this.DocumentationMenuItem_MouseEnter);
            // 
            // ViewWordMenuItem
            // 
            this.ViewWordMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ViewWordMenuItem.Image")));
            this.ViewWordMenuItem.Name = "ViewWordMenuItem";
            this.ViewWordMenuItem.Size = new System.Drawing.Size(286, 22);
            this.ViewWordMenuItem.Text = "View In Microsoft Word";
            this.ViewWordMenuItem.Click += new System.EventHandler(this.ViewWordMenuItem_Click);
            this.ViewWordMenuItem.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.ViewWordMenuItem.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ViewPDFMenuItem
            // 
            this.ViewPDFMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ViewPDFMenuItem.Image")));
            this.ViewPDFMenuItem.Name = "ViewPDFMenuItem";
            this.ViewPDFMenuItem.Size = new System.Drawing.Size(286, 22);
            this.ViewPDFMenuItem.Text = "       View In PDF Format";
            this.ViewPDFMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ViewPDFMenuItem.Click += new System.EventHandler(this.ViewPDFMenuItem_Click);
            this.ViewPDFMenuItem.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.ViewPDFMenuItem.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // VideoMenuItem
            // 
            this.VideoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WatchYouTubeMenuItem});
            this.VideoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("VideoMenuItem.Image")));
            this.VideoMenuItem.Name = "VideoMenuItem";
            this.VideoMenuItem.Size = new System.Drawing.Size(210, 22);
            this.VideoMenuItem.Text = "                 Video";
            this.VideoMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WatchYouTubeMenuItem
            // 
            this.WatchYouTubeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("WatchYouTubeMenuItem.Image")));
            this.WatchYouTubeMenuItem.Name = "WatchYouTubeMenuItem";
            this.WatchYouTubeMenuItem.Size = new System.Drawing.Size(404, 22);
            this.WatchYouTubeMenuItem.Text = "Watch the XML Mirror 2.0 Intro Video";
            this.WatchYouTubeMenuItem.Click += new System.EventHandler(this.WatchYouTubeMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AboutMenuItem.ForeColor = System.Drawing.Color.LemonChiffon;
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(72, 22);
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            this.AboutMenuItem.MouseEnter += new System.EventHandler(this.AboutMenuItem_MouseEnter);
            this.AboutMenuItem.MouseLeave += new System.EventHandler(this.AboutMenuItem_MouseLeave);
            // 
            // XmlParserRadioButton
            // 
            this.XmlParserRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.XmlParserRadioButton.Checked = true;
            this.XmlParserRadioButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.XmlParserRadioButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.XmlParserRadioButton.Location = new System.Drawing.Point(240, 310);
            this.XmlParserRadioButton.Name = "XmlParserRadioButton";
            this.XmlParserRadioButton.Size = new System.Drawing.Size(224, 27);
            this.XmlParserRadioButton.TabIndex = 85;
            this.XmlParserRadioButton.TabStop = true;
            this.XmlParserRadioButton.Text = "Create Xml Parser";
            this.XmlParserRadioButton.UseVisualStyleBackColor = false;
            this.XmlParserRadioButton.CheckedChanged += new System.EventHandler(this.XmlParserRadioButton_CheckedChanged);
            // 
            // XmlWriterRadioButton
            // 
            this.XmlWriterRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.XmlWriterRadioButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.XmlWriterRadioButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.XmlWriterRadioButton.Location = new System.Drawing.Point(480, 310);
            this.XmlWriterRadioButton.Name = "XmlWriterRadioButton";
            this.XmlWriterRadioButton.Size = new System.Drawing.Size(224, 27);
            this.XmlWriterRadioButton.TabIndex = 86;
            this.XmlWriterRadioButton.Text = "Create Xml Writer";
            this.XmlWriterRadioButton.UseVisualStyleBackColor = false;
            this.XmlWriterRadioButton.CheckedChanged += new System.EventHandler(this.XmlWriterRadioButton_CheckedChanged);
            // 
            // NamespaceControl
            // 
            this.NamespaceControl.BackColor = System.Drawing.Color.Transparent;
            this.NamespaceControl.BottomMargin = 0;
            this.NamespaceControl.Editable = true;
            this.NamespaceControl.Encrypted = false;
            this.NamespaceControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NamespaceControl.LabelBottomMargin = 0;
            this.NamespaceControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.NamespaceControl.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NamespaceControl.LabelText = "Namespace:";
            this.NamespaceControl.LabelTopMargin = 0;
            this.NamespaceControl.LabelWidth = 140;
            this.NamespaceControl.Location = new System.Drawing.Point(60, 438);
            this.NamespaceControl.MultiLine = false;
            this.NamespaceControl.Name = "NamespaceControl";
            this.NamespaceControl.OnTextChangedListener = null;
            this.NamespaceControl.PasswordMode = false;
            this.NamespaceControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NamespaceControl.Size = new System.Drawing.Size(708, 22);
            this.NamespaceControl.TabIndex = 13;
            this.NamespaceControl.TextBoxBottomMargin = 0;
            this.NamespaceControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.NamespaceControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.NamespaceControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NamespaceControl.TextBoxTopMargin = 0;
            this.NamespaceControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // OutputFolderControl
            // 
            this.OutputFolderControl.BackColor = System.Drawing.Color.Transparent;
            this.OutputFolderControl.BottomMargin = 0;
            this.OutputFolderControl.Editable = true;
            this.OutputFolderControl.Encrypted = false;
            this.OutputFolderControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputFolderControl.LabelBottomMargin = 0;
            this.OutputFolderControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.OutputFolderControl.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OutputFolderControl.LabelText = "Output Folder:";
            this.OutputFolderControl.LabelTopMargin = 0;
            this.OutputFolderControl.LabelWidth = 140;
            this.OutputFolderControl.Location = new System.Drawing.Point(60, 471);
            this.OutputFolderControl.MultiLine = false;
            this.OutputFolderControl.Name = "OutputFolderControl";
            this.OutputFolderControl.OnTextChangedListener = null;
            this.OutputFolderControl.PasswordMode = false;
            this.OutputFolderControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.OutputFolderControl.Size = new System.Drawing.Size(708, 22);
            this.OutputFolderControl.TabIndex = 14;
            this.OutputFolderControl.TextBoxBottomMargin = 0;
            this.OutputFolderControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.OutputFolderControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.OutputFolderControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputFolderControl.TextBoxTopMargin = 0;
            this.OutputFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ClassNameControl
            // 
            this.ClassNameControl.BackColor = System.Drawing.Color.Transparent;
            this.ClassNameControl.BottomMargin = 0;
            this.ClassNameControl.Editable = true;
            this.ClassNameControl.Encrypted = false;
            this.ClassNameControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClassNameControl.LabelBottomMargin = 0;
            this.ClassNameControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.ClassNameControl.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClassNameControl.LabelText = "Class Name:";
            this.ClassNameControl.LabelTopMargin = 0;
            this.ClassNameControl.LabelWidth = 140;
            this.ClassNameControl.Location = new System.Drawing.Point(60, 405);
            this.ClassNameControl.MultiLine = false;
            this.ClassNameControl.Name = "ClassNameControl";
            this.ClassNameControl.OnTextChangedListener = null;
            this.ClassNameControl.PasswordMode = false;
            this.ClassNameControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ClassNameControl.Size = new System.Drawing.Size(708, 22);
            this.ClassNameControl.TabIndex = 12;
            this.ClassNameControl.TextBoxBottomMargin = 0;
            this.ClassNameControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ClassNameControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ClassNameControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClassNameControl.TextBoxTopMargin = 0;
            this.ClassNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // TargetClassComboBox
            // 
            this.TargetClassComboBox.BackColor = System.Drawing.Color.Transparent;
            this.TargetClassComboBox.ComboBoxLeftMargin = 1;
            this.TargetClassComboBox.ComboBoxText = "";
            this.TargetClassComboBox.ComoboBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetClassComboBox.Editable = true;
            this.TargetClassComboBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetClassComboBox.HideLabel = false;
            this.TargetClassComboBox.LabelBottomMargin = 0;
            this.TargetClassComboBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.TargetClassComboBox.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TargetClassComboBox.LabelText = "Target Class:";
            this.TargetClassComboBox.LabelTopMargin = 0;
            this.TargetClassComboBox.LabelWidth = 140;
            this.TargetClassComboBox.List = null;
            this.TargetClassComboBox.Location = new System.Drawing.Point(60, 372);
            this.TargetClassComboBox.Name = "TargetClassComboBox";
            this.TargetClassComboBox.SelectedIndex = -1;
            this.TargetClassComboBox.SelectedIndexListener = null;
            this.TargetClassComboBox.Size = new System.Drawing.Size(708, 22);
            this.TargetClassComboBox.Sorted = true;
            this.TargetClassComboBox.Source = null;
            this.TargetClassComboBox.TabIndex = 11;
            // 
            // TargetDllTextBox
            // 
            this.TargetDllTextBox.BackColor = System.Drawing.Color.Transparent;
            this.TargetDllTextBox.BottomMargin = 0;
            this.TargetDllTextBox.Editable = true;
            this.TargetDllTextBox.Encrypted = false;
            this.TargetDllTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetDllTextBox.LabelBottomMargin = 0;
            this.TargetDllTextBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.TargetDllTextBox.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TargetDllTextBox.LabelText = "Target Dll:";
            this.TargetDllTextBox.LabelTopMargin = 0;
            this.TargetDllTextBox.LabelWidth = 140;
            this.TargetDllTextBox.Location = new System.Drawing.Point(60, 339);
            this.TargetDllTextBox.MultiLine = false;
            this.TargetDllTextBox.Name = "TargetDllTextBox";
            this.TargetDllTextBox.OnTextChangedListener = null;
            this.TargetDllTextBox.PasswordMode = false;
            this.TargetDllTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TargetDllTextBox.Size = new System.Drawing.Size(708, 22);
            this.TargetDllTextBox.TabIndex = 10;
            this.TargetDllTextBox.TextBoxBottomMargin = 0;
            this.TargetDllTextBox.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.TargetDllTextBox.TextBoxEditableColor = System.Drawing.Color.White;
            this.TargetDllTextBox.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetDllTextBox.TextBoxTopMargin = 0;
            this.TargetDllTextBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SourceXmlFileTextBox
            // 
            this.SourceXmlFileTextBox.BackColor = System.Drawing.Color.Transparent;
            this.SourceXmlFileTextBox.BottomMargin = 0;
            this.SourceXmlFileTextBox.Editable = true;
            this.SourceXmlFileTextBox.Encrypted = false;
            this.SourceXmlFileTextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceXmlFileTextBox.ForeColor = System.Drawing.Color.Black;
            this.SourceXmlFileTextBox.LabelBottomMargin = 0;
            this.SourceXmlFileTextBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.SourceXmlFileTextBox.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SourceXmlFileTextBox.LabelText = "Source Xml File:";
            this.SourceXmlFileTextBox.LabelTopMargin = 0;
            this.SourceXmlFileTextBox.LabelWidth = 140;
            this.SourceXmlFileTextBox.Location = new System.Drawing.Point(57, 34);
            this.SourceXmlFileTextBox.MultiLine = false;
            this.SourceXmlFileTextBox.Name = "SourceXmlFileTextBox";
            this.SourceXmlFileTextBox.OnTextChangedListener = null;
            this.SourceXmlFileTextBox.PasswordMode = false;
            this.SourceXmlFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SourceXmlFileTextBox.Size = new System.Drawing.Size(708, 22);
            this.SourceXmlFileTextBox.TabIndex = 0;
            this.SourceXmlFileTextBox.TextBoxBottomMargin = 0;
            this.SourceXmlFileTextBox.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.SourceXmlFileTextBox.TextBoxEditableColor = System.Drawing.Color.White;
            this.SourceXmlFileTextBox.TextBoxFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceXmlFileTextBox.TextBoxTopMargin = 0;
            this.SourceXmlFileTextBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // CollectionInfoLabel
            // 
            this.CollectionInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.CollectionInfoLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CollectionInfoLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CollectionInfoLabel.Location = new System.Drawing.Point(56, 226);
            this.CollectionInfoLabel.Name = "CollectionInfoLabel";
            this.CollectionInfoLabel.Size = new System.Drawing.Size(709, 23);
            this.CollectionInfoLabel.TabIndex = 87;
            this.CollectionInfoLabel.Text = "Select the \'Action\' nodes and hit F1 or F2 to assign.";
            // 
            // AutoFillButton
            // 
            this.AutoFillButton.BackColor = System.Drawing.Color.Transparent;
            this.AutoFillButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AutoFillButton.BackgroundImage")));
            this.AutoFillButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AutoFillButton.FlatAppearance.BorderSize = 0;
            this.AutoFillButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AutoFillButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AutoFillButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoFillButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AutoFillButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.AutoFillButton.Location = new System.Drawing.Point(56, 672);
            this.AutoFillButton.Name = "AutoFillButton";
            this.AutoFillButton.Size = new System.Drawing.Size(108, 32);
            this.AutoFillButton.TabIndex = 88;
            this.AutoFillButton.Text = "Auto Fill";
            this.AutoFillButton.UseVisualStyleBackColor = false;
            this.AutoFillButton.Visible = false;
            this.AutoFillButton.Click += new System.EventHandler(this.AutoFillButton_Click);
            this.AutoFillButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.AutoFillButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // HiddenButton
            // 
            this.HiddenButton.BackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HiddenButton.BackgroundImage")));
            this.HiddenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HiddenButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.HiddenButton.FlatAppearance.BorderSize = 0;
            this.HiddenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HiddenButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HiddenButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.HiddenButton.Location = new System.Drawing.Point(-300, 229);
            this.HiddenButton.Name = "HiddenButton";
            this.HiddenButton.Size = new System.Drawing.Size(80, 32);
            this.HiddenButton.TabIndex = 89;
            this.HiddenButton.Text = "Start";
            this.HiddenButton.UseVisualStyleBackColor = false;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(1048, 26);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 695);
            this.RightMarginPanel.TabIndex = 91;
            // 
            // RightPanel
            // 
            this.RightPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightPanel.Controls.Add(this.YouTubeButtonContainer);
            this.RightPanel.Controls.Add(this.BottomMarginPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(870, 26);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(178, 695);
            this.RightPanel.TabIndex = 92;
            // 
            // YouTubeButtonContainer
            // 
            this.YouTubeButtonContainer.BackColor = System.Drawing.Color.Transparent;
            this.YouTubeButtonContainer.Controls.Add(this.YouTubeButton);
            this.YouTubeButtonContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YouTubeButtonContainer.Location = new System.Drawing.Point(0, 615);
            this.YouTubeButtonContainer.Name = "YouTubeButtonContainer";
            this.YouTubeButtonContainer.Size = new System.Drawing.Size(178, 64);
            this.YouTubeButtonContainer.TabIndex = 93;
            // 
            // YouTubeButton
            // 
            this.YouTubeButton.BackgroundImage = global::XmlMirror.Properties.Resources.YouTube;
            this.YouTubeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YouTubeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.YouTubeButton.Location = new System.Drawing.Point(50, 0);
            this.YouTubeButton.Name = "YouTubeButton";
            this.YouTubeButton.Size = new System.Drawing.Size(128, 64);
            this.YouTubeButton.TabIndex = 94;
            this.YouTubeButton.TabStop = false;
            this.YouTubeButton.Click += new System.EventHandler(this.WatchYouTubeMenuItem_Click);
            this.YouTubeButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.YouTubeButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(0, 679);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(178, 16);
            this.BottomMarginPanel.TabIndex = 92;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1064, 721);
            this.ContextMenuStrip = this.ContextMenu;
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.HiddenButton);
            this.Controls.Add(this.AutoFillButton);
            this.Controls.Add(this.CollectionInfoLabel);
            this.Controls.Add(this.XmlWriterRadioButton);
            this.Controls.Add(this.XmlParserRadioButton);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.F2DetailLabel);
            this.Controls.Add(this.F2Label);
            this.Controls.Add(this.F2Image);
            this.Controls.Add(this.F1DetailLabel);
            this.Controls.Add(this.F1Label);
            this.Controls.Add(this.F1Image);
            this.Controls.Add(this.NamespaceControl);
            this.Controls.Add(this.SaveMirrorButton);
            this.Controls.Add(this.LoadMirrorButton);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.BrowseForOutputFolderButton);
            this.Controls.Add(this.OutputFolderControl);
            this.Controls.Add(this.TargetTreeView);
            this.Controls.Add(this.ClassNameControl);
            this.Controls.Add(this.TargetClassComboBox);
            this.Controls.Add(this.BrowseForAssemblyButton);
            this.Controls.Add(this.TargetDllTextBox);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.TargetLabel);
            this.Controls.Add(this.XmlTreeView);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.SourceXmlFileTextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 760);
            this.MinimumSize = new System.Drawing.Size(1080, 760);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xml Mirror 6.0.3";
            ((System.ComponentModel.ISupportInitialize)(this.F1Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.F2Image)).EndInit();
            this.ContextMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.YouTubeButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YouTubeButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
