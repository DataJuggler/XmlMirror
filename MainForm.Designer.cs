

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            BrowseButton = new Button();
            StartButton = new Button();
            XmlTreeView = new TreeView();
            Images = new ImageList(components);
            TargetLabel = new Label();
            DoneButton = new Button();
            BuildButton = new Button();
            BrowseForAssemblyButton = new Button();
            TargetTreeView = new TreeView();
            TargetImages = new ImageList(components);
            BrowseForOutputFolderButton = new Button();
            ViewButton = new Button();
            LoadMirrorButton = new Button();
            SaveMirrorButton = new Button();
            F1Image = new PictureBox();
            F1Label = new Label();
            F1DetailLabel = new Label();
            F2DetailLabel = new Label();
            F2Label = new Label();
            F2Image = new PictureBox();
            ContextMenu = new ContextMenuStrip(components);
            ClearFieldLink = new ToolStripMenuItem();
            SkipFieldMenuItem = new ToolStripMenuItem();
            ToolTip = new ToolTip(components);
            MainMenu = new MenuStrip();
            HelpMenuItem = new ToolStripMenuItem();
            DocumentationMenuItem = new ToolStripMenuItem();
            ViewWordMenuItem = new ToolStripMenuItem();
            ViewPDFMenuItem = new ToolStripMenuItem();
            VideoMenuItem = new ToolStripMenuItem();
            WatchYouTubeMenuItem = new ToolStripMenuItem();
            AboutMenuItem = new ToolStripMenuItem();
            XmlParserRadioButton = new RadioButton();
            XmlWriterRadioButton = new RadioButton();
            NamespaceControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            OutputFolderControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            ClassNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            TargetClassComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            TargetDllTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            SourceXmlFileTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            CollectionInfoLabel = new Label();
            AutoFillButton = new Button();
            HiddenButton = new Button();
            RightMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            RightPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            YouTubeButtonContainer = new DataJuggler.Win.Controls.Objects.PanelExtender();
            YouTubeButton = new PictureBox();
            BottomMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            WriterInfoImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)F1Image).BeginInit();
            ((System.ComponentModel.ISupportInitialize)F2Image).BeginInit();
            ContextMenu.SuspendLayout();
            MainMenu.SuspendLayout();
            RightPanel.SuspendLayout();
            YouTubeButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)YouTubeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WriterInfoImage).BeginInit();
            SuspendLayout();
            // 
            // BrowseButton
            // 
            BrowseButton.BackColor = Color.Transparent;
            BrowseButton.BackgroundImage = (Image)resources.GetObject("BrowseButton.BackgroundImage");
            BrowseButton.BackgroundImageLayout = ImageLayout.Stretch;
            BrowseButton.FlatAppearance.BorderColor = Color.Black;
            BrowseButton.FlatAppearance.BorderSize = 0;
            BrowseButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BrowseButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BrowseButton.FlatStyle = FlatStyle.Flat;
            BrowseButton.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
            BrowseButton.ForeColor = Color.GhostWhite;
            BrowseButton.Location = new Point(760, 32);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(48, 28);
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "...";
            BrowseButton.UseVisualStyleBackColor = false;
            BrowseButton.Click += BrowseButton_Click;
            BrowseButton.MouseEnter += Button_MouseEnter;
            BrowseButton.MouseLeave += Button_MouseLeave;
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.Transparent;
            StartButton.BackgroundImage = (Image)resources.GetObject("StartButton.BackgroundImage");
            StartButton.BackgroundImageLayout = ImageLayout.Stretch;
            StartButton.FlatAppearance.BorderColor = Color.Black;
            StartButton.FlatAppearance.BorderSize = 0;
            StartButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            StartButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Font = new Font("Microsoft Sans Serif", 12F);
            StartButton.ForeColor = Color.GhostWhite;
            StartButton.Location = new Point(769, 67);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(80, 32);
            StartButton.TabIndex = 2;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            StartButton.MouseEnter += Button_MouseEnter;
            StartButton.MouseLeave += Button_MouseLeave;
            // 
            // XmlTreeView
            // 
            XmlTreeView.Font = new Font("Verdana", 14.25F);
            XmlTreeView.ImageIndex = 0;
            XmlTreeView.ImageList = Images;
            XmlTreeView.Location = new Point(57, 67);
            XmlTreeView.Name = "XmlTreeView";
            XmlTreeView.SelectedImageIndex = 0;
            XmlTreeView.Size = new Size(708, 156);
            XmlTreeView.TabIndex = 3;
            XmlTreeView.ItemDrag += XmlTreeView_ItemDrag;
            XmlTreeView.KeyDown += XmlTreeView_KeyDown;
            // 
            // Images
            // 
            Images.ColorDepth = ColorDepth.Depth8Bit;
            Images.ImageStream = (ImageListStreamer)resources.GetObject("Images.ImageStream");
            Images.TransparentColor = Color.Transparent;
            Images.Images.SetKeyName(0, "Blank.png");
            Images.Images.SetKeyName(1, "NewObject.ico");
            Images.Images.SetKeyName(2, "NewCollection.ico");
            // 
            // TargetLabel
            // 
            TargetLabel.AutoSize = true;
            TargetLabel.BackColor = Color.Transparent;
            TargetLabel.Font = new Font("Microsoft Sans Serif", 14.25F);
            TargetLabel.ForeColor = Color.LemonChiffon;
            TargetLabel.Location = new Point(53, 313);
            TargetLabel.Name = "TargetLabel";
            TargetLabel.Size = new Size(124, 24);
            TargetLabel.TabIndex = 6;
            TargetLabel.Text = "Target Object";
            // 
            // DoneButton
            // 
            DoneButton.BackColor = Color.Transparent;
            DoneButton.BackgroundImage = (Image)resources.GetObject("DoneButton.BackgroundImage");
            DoneButton.BackgroundImageLayout = ImageLayout.Stretch;
            DoneButton.FlatAppearance.BorderSize = 0;
            DoneButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DoneButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DoneButton.FlatStyle = FlatStyle.Flat;
            DoneButton.Font = new Font("Microsoft Sans Serif", 12F);
            DoneButton.ForeColor = Color.GhostWhite;
            DoneButton.Location = new Point(672, 672);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new Size(92, 32);
            DoneButton.TabIndex = 9;
            DoneButton.Text = "Done";
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            DoneButton.MouseEnter += Button_MouseEnter;
            DoneButton.MouseLeave += Button_MouseLeave;
            // 
            // BuildButton
            // 
            BuildButton.BackColor = Color.Transparent;
            BuildButton.BackgroundImage = Properties.Resources.DarkButton;
            BuildButton.BackgroundImageLayout = ImageLayout.Stretch;
            BuildButton.FlatAppearance.BorderSize = 0;
            BuildButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BuildButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BuildButton.FlatStyle = FlatStyle.Flat;
            BuildButton.Font = new Font("Microsoft Sans Serif", 12F);
            BuildButton.ForeColor = Color.GhostWhite;
            BuildButton.Location = new Point(499, 672);
            BuildButton.Name = "BuildButton";
            BuildButton.Size = new Size(160, 32);
            BuildButton.TabIndex = 8;
            BuildButton.Text = "Build Parser";
            BuildButton.UseVisualStyleBackColor = false;
            BuildButton.Click += BuildButton_Click;
            BuildButton.MouseEnter += Button_MouseEnter;
            BuildButton.MouseLeave += Button_MouseLeave;
            // 
            // BrowseForAssemblyButton
            // 
            BrowseForAssemblyButton.BackColor = Color.Transparent;
            BrowseForAssemblyButton.BackgroundImage = (Image)resources.GetObject("BrowseForAssemblyButton.BackgroundImage");
            BrowseForAssemblyButton.BackgroundImageLayout = ImageLayout.Stretch;
            BrowseForAssemblyButton.FlatAppearance.BorderColor = Color.Black;
            BrowseForAssemblyButton.FlatAppearance.BorderSize = 0;
            BrowseForAssemblyButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BrowseForAssemblyButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BrowseForAssemblyButton.FlatStyle = FlatStyle.Flat;
            BrowseForAssemblyButton.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
            BrowseForAssemblyButton.ForeColor = Color.GhostWhite;
            BrowseForAssemblyButton.Location = new Point(764, 337);
            BrowseForAssemblyButton.Name = "BrowseForAssemblyButton";
            BrowseForAssemblyButton.Size = new Size(48, 28);
            BrowseForAssemblyButton.TabIndex = 11;
            BrowseForAssemblyButton.Text = "...";
            BrowseForAssemblyButton.UseVisualStyleBackColor = false;
            BrowseForAssemblyButton.Click += BrowseForAssemblyButton_Click;
            BrowseForAssemblyButton.MouseEnter += Button_MouseEnter;
            BrowseForAssemblyButton.MouseLeave += Button_MouseLeave;
            // 
            // TargetTreeView
            // 
            TargetTreeView.AllowDrop = true;
            TargetTreeView.Font = new Font("Verdana", 14.25F);
            TargetTreeView.ImageIndex = 0;
            TargetTreeView.ImageList = TargetImages;
            TargetTreeView.Location = new Point(57, 506);
            TargetTreeView.Name = "TargetTreeView";
            TargetTreeView.SelectedImageIndex = 0;
            TargetTreeView.Size = new Size(708, 156);
            TargetTreeView.StateImageList = Images;
            TargetTreeView.TabIndex = 15;
            // 
            // TargetImages
            // 
            TargetImages.ColorDepth = ColorDepth.Depth8Bit;
            TargetImages.ImageStream = (ImageListStreamer)resources.GetObject("TargetImages.ImageStream");
            TargetImages.TransparentColor = Color.Transparent;
            TargetImages.Images.SetKeyName(0, "Blank.png");
            TargetImages.Images.SetKeyName(1, "Skip.png");
            // 
            // BrowseForOutputFolderButton
            // 
            BrowseForOutputFolderButton.BackColor = Color.Transparent;
            BrowseForOutputFolderButton.BackgroundImage = (Image)resources.GetObject("BrowseForOutputFolderButton.BackgroundImage");
            BrowseForOutputFolderButton.BackgroundImageLayout = ImageLayout.Stretch;
            BrowseForOutputFolderButton.FlatAppearance.BorderColor = Color.Black;
            BrowseForOutputFolderButton.FlatAppearance.BorderSize = 0;
            BrowseForOutputFolderButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BrowseForOutputFolderButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BrowseForOutputFolderButton.FlatStyle = FlatStyle.Flat;
            BrowseForOutputFolderButton.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
            BrowseForOutputFolderButton.ForeColor = Color.GhostWhite;
            BrowseForOutputFolderButton.Location = new Point(764, 470);
            BrowseForOutputFolderButton.Name = "BrowseForOutputFolderButton";
            BrowseForOutputFolderButton.Size = new Size(48, 28);
            BrowseForOutputFolderButton.TabIndex = 16;
            BrowseForOutputFolderButton.Text = "...";
            BrowseForOutputFolderButton.UseVisualStyleBackColor = false;
            BrowseForOutputFolderButton.Click += BrowseForOutputFolderButton_Click;
            BrowseForOutputFolderButton.MouseEnter += Button_MouseEnter;
            BrowseForOutputFolderButton.MouseLeave += Button_MouseLeave;
            // 
            // ViewButton
            // 
            ViewButton.BackColor = Color.Transparent;
            ViewButton.BackgroundImage = (Image)resources.GetObject("ViewButton.BackgroundImage");
            ViewButton.BackgroundImageLayout = ImageLayout.Stretch;
            ViewButton.FlatAppearance.BorderSize = 0;
            ViewButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ViewButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ViewButton.FlatStyle = FlatStyle.Flat;
            ViewButton.Font = new Font("Microsoft Sans Serif", 12F);
            ViewButton.ForeColor = Color.GhostWhite;
            ViewButton.Location = new Point(769, 506);
            ViewButton.Name = "ViewButton";
            ViewButton.Size = new Size(80, 32);
            ViewButton.TabIndex = 17;
            ViewButton.Text = "View";
            ViewButton.UseVisualStyleBackColor = false;
            ViewButton.Click += ViewButton_Click;
            ViewButton.MouseEnter += Button_MouseEnter;
            ViewButton.MouseLeave += Button_MouseLeave;
            // 
            // LoadMirrorButton
            // 
            LoadMirrorButton.BackColor = Color.Transparent;
            LoadMirrorButton.BackgroundImage = (Image)resources.GetObject("LoadMirrorButton.BackgroundImage");
            LoadMirrorButton.BackgroundImageLayout = ImageLayout.Stretch;
            LoadMirrorButton.FlatAppearance.BorderSize = 0;
            LoadMirrorButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            LoadMirrorButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            LoadMirrorButton.FlatStyle = FlatStyle.Flat;
            LoadMirrorButton.Font = new Font("Microsoft Sans Serif", 12F);
            LoadMirrorButton.ForeColor = Color.GhostWhite;
            LoadMirrorButton.Location = new Point(177, 672);
            LoadMirrorButton.Name = "LoadMirrorButton";
            LoadMirrorButton.Size = new Size(148, 32);
            LoadMirrorButton.TabIndex = 18;
            LoadMirrorButton.Text = "Load Mirror";
            LoadMirrorButton.UseVisualStyleBackColor = false;
            LoadMirrorButton.Click += LoadMirrorButton_Click;
            LoadMirrorButton.MouseEnter += Button_MouseEnter;
            LoadMirrorButton.MouseLeave += Button_MouseLeave;
            // 
            // SaveMirrorButton
            // 
            SaveMirrorButton.BackColor = Color.Transparent;
            SaveMirrorButton.BackgroundImage = (Image)resources.GetObject("SaveMirrorButton.BackgroundImage");
            SaveMirrorButton.BackgroundImageLayout = ImageLayout.Stretch;
            SaveMirrorButton.FlatAppearance.BorderSize = 0;
            SaveMirrorButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            SaveMirrorButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SaveMirrorButton.FlatStyle = FlatStyle.Flat;
            SaveMirrorButton.Font = new Font("Microsoft Sans Serif", 12F);
            SaveMirrorButton.ForeColor = Color.GhostWhite;
            SaveMirrorButton.Location = new Point(338, 672);
            SaveMirrorButton.Name = "SaveMirrorButton";
            SaveMirrorButton.Size = new Size(148, 32);
            SaveMirrorButton.TabIndex = 19;
            SaveMirrorButton.Text = "Save Mirror";
            SaveMirrorButton.UseVisualStyleBackColor = false;
            SaveMirrorButton.Click += SaveMirrorButton_Click;
            SaveMirrorButton.MouseEnter += Button_MouseEnter;
            SaveMirrorButton.MouseLeave += Button_MouseLeave;
            // 
            // F1Image
            // 
            F1Image.BackColor = Color.Transparent;
            F1Image.Image = (Image)resources.GetObject("F1Image.Image");
            F1Image.Location = new Point(60, 250);
            F1Image.Name = "F1Image";
            F1Image.Size = new Size(24, 24);
            F1Image.SizeMode = PictureBoxSizeMode.StretchImage;
            F1Image.TabIndex = 21;
            F1Image.TabStop = false;
            // 
            // F1Label
            // 
            F1Label.BackColor = Color.Transparent;
            F1Label.Font = new Font("Verdana", 14.25F, FontStyle.Bold);
            F1Label.ForeColor = Color.LemonChiffon;
            F1Label.Location = new Point(90, 251);
            F1Label.Name = "F1Label";
            F1Label.Size = new Size(36, 23);
            F1Label.TabIndex = 22;
            F1Label.Text = "F1";
            // 
            // F1DetailLabel
            // 
            F1DetailLabel.BackColor = Color.Transparent;
            F1DetailLabel.Font = new Font("Verdana", 14.25F);
            F1DetailLabel.ForeColor = Color.LemonChiffon;
            F1DetailLabel.Location = new Point(132, 251);
            F1DetailLabel.Name = "F1DetailLabel";
            F1DetailLabel.Size = new Size(633, 23);
            F1DetailLabel.TabIndex = 23;
            F1DetailLabel.Text = "New instances of your object will be created for this node.";
            // 
            // F2DetailLabel
            // 
            F2DetailLabel.BackColor = Color.Transparent;
            F2DetailLabel.Font = new Font("Verdana", 14.25F);
            F2DetailLabel.ForeColor = Color.LemonChiffon;
            F2DetailLabel.Location = new Point(132, 281);
            F2DetailLabel.Name = "F2DetailLabel";
            F2DetailLabel.Size = new Size(732, 23);
            F2DetailLabel.TabIndex = 26;
            F2DetailLabel.Text = "A typed list <T> will be created for this node (collections only)\r\n";
            // 
            // F2Label
            // 
            F2Label.BackColor = Color.Transparent;
            F2Label.Font = new Font("Verdana", 14.25F, FontStyle.Bold);
            F2Label.ForeColor = Color.LemonChiffon;
            F2Label.Location = new Point(90, 281);
            F2Label.Name = "F2Label";
            F2Label.Size = new Size(36, 23);
            F2Label.TabIndex = 25;
            F2Label.Text = "F2";
            // 
            // F2Image
            // 
            F2Image.Image = (Image)resources.GetObject("F2Image.Image");
            F2Image.Location = new Point(60, 280);
            F2Image.Name = "F2Image";
            F2Image.Size = new Size(24, 24);
            F2Image.SizeMode = PictureBoxSizeMode.StretchImage;
            F2Image.TabIndex = 24;
            F2Image.TabStop = false;
            // 
            // ContextMenu
            // 
            ContextMenu.Items.AddRange(new ToolStripItem[] { ClearFieldLink, SkipFieldMenuItem });
            ContextMenu.Name = "ContextMenu";
            ContextMenu.Size = new Size(155, 48);
            ContextMenu.Opening += ContextMenu_Opening;
            // 
            // ClearFieldLink
            // 
            ClearFieldLink.Name = "ClearFieldLink";
            ClearFieldLink.Size = new Size(154, 22);
            ClearFieldLink.Text = "Clear Field Link";
            ClearFieldLink.TextAlign = ContentAlignment.MiddleRight;
            ClearFieldLink.Click += ClearFieldLink_Click;
            // 
            // SkipFieldMenuItem
            // 
            SkipFieldMenuItem.Name = "SkipFieldMenuItem";
            SkipFieldMenuItem.Size = new Size(154, 22);
            SkipFieldMenuItem.Text = "Skip Field";
            SkipFieldMenuItem.Click += SkipFieldMenuItem_Click;
            // 
            // MainMenu
            // 
            MainMenu.BackColor = Color.Transparent;
            MainMenu.Items.AddRange(new ToolStripItem[] { HelpMenuItem, AboutMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(1064, 26);
            MainMenu.TabIndex = 83;
            // 
            // HelpMenuItem
            // 
            HelpMenuItem.AutoSize = false;
            HelpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DocumentationMenuItem, VideoMenuItem });
            HelpMenuItem.Font = new Font("Verdana", 12F, FontStyle.Bold);
            HelpMenuItem.ForeColor = Color.LemonChiffon;
            HelpMenuItem.Name = "HelpMenuItem";
            HelpMenuItem.Size = new Size(120, 22);
            HelpMenuItem.Text = "Help";
            HelpMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            HelpMenuItem.DropDownClosed += HelpMenuItem_DropDownClosed;
            HelpMenuItem.DropDownOpened += HelpMenuItem_DropDownOpened;
            HelpMenuItem.MouseEnter += HelpMenuItem_MouseEnter;
            HelpMenuItem.MouseLeave += HelpMenuItem_MouseLeave;
            // 
            // DocumentationMenuItem
            // 
            DocumentationMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ViewWordMenuItem, ViewPDFMenuItem });
            DocumentationMenuItem.Image = (Image)resources.GetObject("DocumentationMenuItem.Image");
            DocumentationMenuItem.Name = "DocumentationMenuItem";
            DocumentationMenuItem.Size = new Size(210, 22);
            DocumentationMenuItem.Text = "Documentation";
            DocumentationMenuItem.MouseEnter += DocumentationMenuItem_MouseEnter;
            // 
            // ViewWordMenuItem
            // 
            ViewWordMenuItem.Image = (Image)resources.GetObject("ViewWordMenuItem.Image");
            ViewWordMenuItem.Name = "ViewWordMenuItem";
            ViewWordMenuItem.Size = new Size(286, 22);
            ViewWordMenuItem.Text = "View In Microsoft Word";
            ViewWordMenuItem.Click += ViewWordMenuItem_Click;
            ViewWordMenuItem.MouseEnter += Button_MouseEnter;
            ViewWordMenuItem.MouseLeave += Button_MouseLeave;
            // 
            // ViewPDFMenuItem
            // 
            ViewPDFMenuItem.Image = (Image)resources.GetObject("ViewPDFMenuItem.Image");
            ViewPDFMenuItem.Name = "ViewPDFMenuItem";
            ViewPDFMenuItem.Size = new Size(286, 22);
            ViewPDFMenuItem.Text = "       View In PDF Format";
            ViewPDFMenuItem.TextAlign = ContentAlignment.MiddleRight;
            ViewPDFMenuItem.Click += ViewPDFMenuItem_Click;
            ViewPDFMenuItem.MouseEnter += Button_MouseEnter;
            ViewPDFMenuItem.MouseLeave += Button_MouseLeave;
            // 
            // VideoMenuItem
            // 
            VideoMenuItem.DropDownItems.AddRange(new ToolStripItem[] { WatchYouTubeMenuItem });
            VideoMenuItem.Image = (Image)resources.GetObject("VideoMenuItem.Image");
            VideoMenuItem.Name = "VideoMenuItem";
            VideoMenuItem.Size = new Size(210, 22);
            VideoMenuItem.Text = "                 Video";
            VideoMenuItem.TextAlign = ContentAlignment.MiddleRight;
            // 
            // WatchYouTubeMenuItem
            // 
            WatchYouTubeMenuItem.Image = (Image)resources.GetObject("WatchYouTubeMenuItem.Image");
            WatchYouTubeMenuItem.Name = "WatchYouTubeMenuItem";
            WatchYouTubeMenuItem.Size = new Size(404, 22);
            WatchYouTubeMenuItem.Text = "Watch the XML Mirror 2.0 Intro Video";
            WatchYouTubeMenuItem.Click += WatchYouTubeMenuItem_Click;
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.Font = new Font("Verdana", 12F, FontStyle.Bold);
            AboutMenuItem.ForeColor = Color.LemonChiffon;
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new Size(72, 22);
            AboutMenuItem.Text = "About";
            AboutMenuItem.Click += AboutMenuItem_Click;
            AboutMenuItem.MouseEnter += AboutMenuItem_MouseEnter;
            AboutMenuItem.MouseLeave += AboutMenuItem_MouseLeave;
            // 
            // XmlParserRadioButton
            // 
            XmlParserRadioButton.BackColor = Color.Transparent;
            XmlParserRadioButton.Checked = true;
            XmlParserRadioButton.Font = new Font("Verdana", 14.25F, FontStyle.Bold);
            XmlParserRadioButton.ForeColor = Color.LemonChiffon;
            XmlParserRadioButton.Location = new Point(240, 310);
            XmlParserRadioButton.Name = "XmlParserRadioButton";
            XmlParserRadioButton.Size = new Size(224, 27);
            XmlParserRadioButton.TabIndex = 85;
            XmlParserRadioButton.TabStop = true;
            XmlParserRadioButton.Text = "Create Xml Parser";
            XmlParserRadioButton.UseVisualStyleBackColor = false;
            XmlParserRadioButton.CheckedChanged += XmlParserRadioButton_CheckedChanged;
            // 
            // XmlWriterRadioButton
            // 
            XmlWriterRadioButton.BackColor = Color.Transparent;
            XmlWriterRadioButton.Font = new Font("Verdana", 14.25F, FontStyle.Bold);
            XmlWriterRadioButton.ForeColor = Color.LemonChiffon;
            XmlWriterRadioButton.Location = new Point(480, 310);
            XmlWriterRadioButton.Name = "XmlWriterRadioButton";
            XmlWriterRadioButton.Size = new Size(224, 27);
            XmlWriterRadioButton.TabIndex = 86;
            XmlWriterRadioButton.Text = "Create Xml Writer";
            XmlWriterRadioButton.UseVisualStyleBackColor = false;
            XmlWriterRadioButton.CheckedChanged += XmlWriterRadioButton_CheckedChanged;
            // 
            // NamespaceControl
            // 
            NamespaceControl.BackColor = Color.Transparent;
            NamespaceControl.BottomMargin = 0;
            NamespaceControl.Editable = true;
            NamespaceControl.Encrypted = false;
            NamespaceControl.Font = new Font("Verdana", 12F);
            NamespaceControl.Inititialized = true;
            NamespaceControl.LabelBottomMargin = 0;
            NamespaceControl.LabelColor = Color.LemonChiffon;
            NamespaceControl.LabelFont = new Font("Verdana", 10F, FontStyle.Bold);
            NamespaceControl.LabelText = "Namespace:";
            NamespaceControl.LabelTopMargin = 0;
            NamespaceControl.LabelWidth = 140;
            NamespaceControl.Location = new Point(60, 438);
            NamespaceControl.MultiLine = false;
            NamespaceControl.Name = "NamespaceControl";
            NamespaceControl.OnTextChangedListener = null;
            NamespaceControl.PasswordMode = false;
            NamespaceControl.ScrollBars = ScrollBars.None;
            NamespaceControl.Size = new Size(708, 22);
            NamespaceControl.TabIndex = 13;
            NamespaceControl.TextBoxBottomMargin = 0;
            NamespaceControl.TextBoxDisabledColor = Color.LightGray;
            NamespaceControl.TextBoxEditableColor = Color.White;
            NamespaceControl.TextBoxFont = new Font("Verdana", 12F);
            NamespaceControl.TextBoxTopMargin = 0;
            NamespaceControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // OutputFolderControl
            // 
            OutputFolderControl.BackColor = Color.Transparent;
            OutputFolderControl.BottomMargin = 0;
            OutputFolderControl.Editable = true;
            OutputFolderControl.Encrypted = false;
            OutputFolderControl.Font = new Font("Verdana", 12F);
            OutputFolderControl.Inititialized = true;
            OutputFolderControl.LabelBottomMargin = 0;
            OutputFolderControl.LabelColor = Color.LemonChiffon;
            OutputFolderControl.LabelFont = new Font("Verdana", 10F, FontStyle.Bold);
            OutputFolderControl.LabelText = "Output Folder:";
            OutputFolderControl.LabelTopMargin = 0;
            OutputFolderControl.LabelWidth = 140;
            OutputFolderControl.Location = new Point(60, 471);
            OutputFolderControl.MultiLine = false;
            OutputFolderControl.Name = "OutputFolderControl";
            OutputFolderControl.OnTextChangedListener = null;
            OutputFolderControl.PasswordMode = false;
            OutputFolderControl.ScrollBars = ScrollBars.None;
            OutputFolderControl.Size = new Size(708, 22);
            OutputFolderControl.TabIndex = 14;
            OutputFolderControl.TextBoxBottomMargin = 0;
            OutputFolderControl.TextBoxDisabledColor = Color.LightGray;
            OutputFolderControl.TextBoxEditableColor = Color.White;
            OutputFolderControl.TextBoxFont = new Font("Verdana", 12F);
            OutputFolderControl.TextBoxTopMargin = 0;
            OutputFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ClassNameControl
            // 
            ClassNameControl.BackColor = Color.Transparent;
            ClassNameControl.BottomMargin = 0;
            ClassNameControl.Editable = true;
            ClassNameControl.Encrypted = false;
            ClassNameControl.Font = new Font("Verdana", 12F);
            ClassNameControl.Inititialized = true;
            ClassNameControl.LabelBottomMargin = 0;
            ClassNameControl.LabelColor = Color.LemonChiffon;
            ClassNameControl.LabelFont = new Font("Verdana", 10F, FontStyle.Bold);
            ClassNameControl.LabelText = "Class Name:";
            ClassNameControl.LabelTopMargin = 0;
            ClassNameControl.LabelWidth = 140;
            ClassNameControl.Location = new Point(60, 405);
            ClassNameControl.MultiLine = false;
            ClassNameControl.Name = "ClassNameControl";
            ClassNameControl.OnTextChangedListener = null;
            ClassNameControl.PasswordMode = false;
            ClassNameControl.ScrollBars = ScrollBars.None;
            ClassNameControl.Size = new Size(708, 22);
            ClassNameControl.TabIndex = 12;
            ClassNameControl.TextBoxBottomMargin = 0;
            ClassNameControl.TextBoxDisabledColor = Color.LightGray;
            ClassNameControl.TextBoxEditableColor = Color.White;
            ClassNameControl.TextBoxFont = new Font("Verdana", 12F);
            ClassNameControl.TextBoxTopMargin = 0;
            ClassNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // TargetClassComboBox
            // 
            TargetClassComboBox.BackColor = Color.Transparent;
            TargetClassComboBox.ComboBoxLeftMargin = 1;
            TargetClassComboBox.ComboBoxText = "";
            TargetClassComboBox.ComoboBoxFont = new Font("Verdana", 12F);
            TargetClassComboBox.Editable = true;
            TargetClassComboBox.Font = new Font("Verdana", 12F);
            TargetClassComboBox.HideLabel = false;
            TargetClassComboBox.LabelBottomMargin = 0;
            TargetClassComboBox.LabelColor = Color.LemonChiffon;
            TargetClassComboBox.LabelFont = new Font("Verdana", 10F, FontStyle.Bold);
            TargetClassComboBox.LabelText = "Target Class:";
            TargetClassComboBox.LabelTopMargin = 0;
            TargetClassComboBox.LabelWidth = 140;
            TargetClassComboBox.List = null;
            TargetClassComboBox.Location = new Point(60, 372);
            TargetClassComboBox.Name = "TargetClassComboBox";
            TargetClassComboBox.SelectedIndex = -1;
            TargetClassComboBox.SelectedIndexListener = null;
            TargetClassComboBox.Size = new Size(708, 22);
            TargetClassComboBox.Sorted = true;
            TargetClassComboBox.Source = null;
            TargetClassComboBox.TabIndex = 11;
            TargetClassComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // TargetDllTextBox
            // 
            TargetDllTextBox.BackColor = Color.Transparent;
            TargetDllTextBox.BottomMargin = 0;
            TargetDllTextBox.Editable = true;
            TargetDllTextBox.Encrypted = false;
            TargetDllTextBox.Font = new Font("Verdana", 12F);
            TargetDllTextBox.Inititialized = true;
            TargetDllTextBox.LabelBottomMargin = 0;
            TargetDllTextBox.LabelColor = Color.LemonChiffon;
            TargetDllTextBox.LabelFont = new Font("Verdana", 10F, FontStyle.Bold);
            TargetDllTextBox.LabelText = "Target Dll:";
            TargetDllTextBox.LabelTopMargin = 0;
            TargetDllTextBox.LabelWidth = 140;
            TargetDllTextBox.Location = new Point(60, 339);
            TargetDllTextBox.MultiLine = false;
            TargetDllTextBox.Name = "TargetDllTextBox";
            TargetDllTextBox.OnTextChangedListener = null;
            TargetDllTextBox.PasswordMode = false;
            TargetDllTextBox.ScrollBars = ScrollBars.None;
            TargetDllTextBox.Size = new Size(708, 22);
            TargetDllTextBox.TabIndex = 10;
            TargetDllTextBox.TextBoxBottomMargin = 0;
            TargetDllTextBox.TextBoxDisabledColor = Color.LightGray;
            TargetDllTextBox.TextBoxEditableColor = Color.White;
            TargetDllTextBox.TextBoxFont = new Font("Verdana", 12F);
            TargetDllTextBox.TextBoxTopMargin = 0;
            TargetDllTextBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SourceXmlFileTextBox
            // 
            SourceXmlFileTextBox.BackColor = Color.Transparent;
            SourceXmlFileTextBox.BottomMargin = 0;
            SourceXmlFileTextBox.Editable = true;
            SourceXmlFileTextBox.Encrypted = false;
            SourceXmlFileTextBox.Font = new Font("Verdana", 14.25F);
            SourceXmlFileTextBox.ForeColor = Color.Black;
            SourceXmlFileTextBox.Inititialized = true;
            SourceXmlFileTextBox.LabelBottomMargin = 0;
            SourceXmlFileTextBox.LabelColor = Color.LemonChiffon;
            SourceXmlFileTextBox.LabelFont = new Font("Verdana", 10F, FontStyle.Bold);
            SourceXmlFileTextBox.LabelText = "Source Xml File:";
            SourceXmlFileTextBox.LabelTopMargin = 0;
            SourceXmlFileTextBox.LabelWidth = 140;
            SourceXmlFileTextBox.Location = new Point(57, 34);
            SourceXmlFileTextBox.MultiLine = false;
            SourceXmlFileTextBox.Name = "SourceXmlFileTextBox";
            SourceXmlFileTextBox.OnTextChangedListener = null;
            SourceXmlFileTextBox.PasswordMode = false;
            SourceXmlFileTextBox.ScrollBars = ScrollBars.None;
            SourceXmlFileTextBox.Size = new Size(708, 22);
            SourceXmlFileTextBox.TabIndex = 0;
            SourceXmlFileTextBox.TextBoxBottomMargin = 0;
            SourceXmlFileTextBox.TextBoxDisabledColor = Color.LightGray;
            SourceXmlFileTextBox.TextBoxEditableColor = Color.White;
            SourceXmlFileTextBox.TextBoxFont = new Font("Verdana", 10F);
            SourceXmlFileTextBox.TextBoxTopMargin = 0;
            SourceXmlFileTextBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // CollectionInfoLabel
            // 
            CollectionInfoLabel.BackColor = Color.Transparent;
            CollectionInfoLabel.Font = new Font("Verdana", 14.25F);
            CollectionInfoLabel.ForeColor = Color.LemonChiffon;
            CollectionInfoLabel.Location = new Point(56, 226);
            CollectionInfoLabel.Name = "CollectionInfoLabel";
            CollectionInfoLabel.Size = new Size(709, 23);
            CollectionInfoLabel.TabIndex = 87;
            CollectionInfoLabel.Text = "Select the 'Action' nodes and hit F1 or F2 to assign.";
            // 
            // AutoFillButton
            // 
            AutoFillButton.BackColor = Color.Transparent;
            AutoFillButton.BackgroundImage = (Image)resources.GetObject("AutoFillButton.BackgroundImage");
            AutoFillButton.BackgroundImageLayout = ImageLayout.Stretch;
            AutoFillButton.FlatAppearance.BorderSize = 0;
            AutoFillButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AutoFillButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            AutoFillButton.FlatStyle = FlatStyle.Flat;
            AutoFillButton.Font = new Font("Microsoft Sans Serif", 12F);
            AutoFillButton.ForeColor = Color.GhostWhite;
            AutoFillButton.Location = new Point(56, 672);
            AutoFillButton.Name = "AutoFillButton";
            AutoFillButton.Size = new Size(108, 32);
            AutoFillButton.TabIndex = 88;
            AutoFillButton.Text = "Auto Fill";
            AutoFillButton.UseVisualStyleBackColor = false;
            AutoFillButton.Visible = false;
            AutoFillButton.Click += AutoFillButton_Click;
            AutoFillButton.MouseEnter += Button_MouseEnter;
            AutoFillButton.MouseLeave += Button_MouseLeave;
            // 
            // HiddenButton
            // 
            HiddenButton.BackColor = Color.Transparent;
            HiddenButton.BackgroundImage = (Image)resources.GetObject("HiddenButton.BackgroundImage");
            HiddenButton.BackgroundImageLayout = ImageLayout.Stretch;
            HiddenButton.FlatAppearance.BorderColor = Color.Black;
            HiddenButton.FlatAppearance.BorderSize = 0;
            HiddenButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HiddenButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HiddenButton.FlatStyle = FlatStyle.Flat;
            HiddenButton.Font = new Font("Microsoft Sans Serif", 12F);
            HiddenButton.ForeColor = Color.GhostWhite;
            HiddenButton.Location = new Point(-300, 229);
            HiddenButton.Name = "HiddenButton";
            HiddenButton.Size = new Size(80, 32);
            HiddenButton.TabIndex = 89;
            HiddenButton.Text = "Start";
            HiddenButton.UseVisualStyleBackColor = false;
            // 
            // RightMarginPanel
            // 
            RightMarginPanel.BackColor = Color.Transparent;
            RightMarginPanel.Dock = DockStyle.Right;
            RightMarginPanel.Location = new Point(1048, 26);
            RightMarginPanel.Name = "RightMarginPanel";
            RightMarginPanel.Size = new Size(16, 695);
            RightMarginPanel.TabIndex = 91;
            // 
            // RightPanel
            // 
            RightPanel.BackColor = Color.Transparent;
            RightPanel.Controls.Add(YouTubeButtonContainer);
            RightPanel.Controls.Add(BottomMarginPanel);
            RightPanel.Dock = DockStyle.Right;
            RightPanel.Location = new Point(870, 26);
            RightPanel.Name = "RightPanel";
            RightPanel.Size = new Size(178, 695);
            RightPanel.TabIndex = 92;
            // 
            // YouTubeButtonContainer
            // 
            YouTubeButtonContainer.BackColor = Color.Transparent;
            YouTubeButtonContainer.Controls.Add(YouTubeButton);
            YouTubeButtonContainer.Dock = DockStyle.Bottom;
            YouTubeButtonContainer.Location = new Point(0, 615);
            YouTubeButtonContainer.Name = "YouTubeButtonContainer";
            YouTubeButtonContainer.Size = new Size(178, 64);
            YouTubeButtonContainer.TabIndex = 93;
            // 
            // YouTubeButton
            // 
            YouTubeButton.BackgroundImage = Properties.Resources.YouTube;
            YouTubeButton.BackgroundImageLayout = ImageLayout.Stretch;
            YouTubeButton.Dock = DockStyle.Right;
            YouTubeButton.Location = new Point(50, 0);
            YouTubeButton.Name = "YouTubeButton";
            YouTubeButton.Size = new Size(128, 64);
            YouTubeButton.TabIndex = 94;
            YouTubeButton.TabStop = false;
            YouTubeButton.Click += WatchYouTubeMenuItem_Click;
            YouTubeButton.MouseEnter += Button_MouseEnter;
            YouTubeButton.MouseLeave += Button_MouseLeave;
            // 
            // BottomMarginPanel
            // 
            BottomMarginPanel.BackColor = Color.Transparent;
            BottomMarginPanel.Dock = DockStyle.Bottom;
            BottomMarginPanel.Location = new Point(0, 679);
            BottomMarginPanel.Name = "BottomMarginPanel";
            BottomMarginPanel.Size = new Size(178, 16);
            BottomMarginPanel.TabIndex = 92;
            // 
            // WriterInfoImage
            // 
            WriterInfoImage.BackgroundImage = Properties.Resources.Writer_Mode;
            WriterInfoImage.BackgroundImageLayout = ImageLayout.Stretch;
            WriterInfoImage.Location = new Point(43, 32);
            WriterInfoImage.Name = "WriterInfoImage";
            WriterInfoImage.Size = new Size(806, 272);
            WriterInfoImage.TabIndex = 93;
            WriterInfoImage.TabStop = false;
            WriterInfoImage.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1064, 721);
            ContextMenuStrip = ContextMenu;
            Controls.Add(WriterInfoImage);
            Controls.Add(RightPanel);
            Controls.Add(RightMarginPanel);
            Controls.Add(HiddenButton);
            Controls.Add(AutoFillButton);
            Controls.Add(CollectionInfoLabel);
            Controls.Add(XmlWriterRadioButton);
            Controls.Add(XmlParserRadioButton);
            Controls.Add(MainMenu);
            Controls.Add(F2DetailLabel);
            Controls.Add(F2Label);
            Controls.Add(F2Image);
            Controls.Add(F1DetailLabel);
            Controls.Add(F1Label);
            Controls.Add(F1Image);
            Controls.Add(NamespaceControl);
            Controls.Add(SaveMirrorButton);
            Controls.Add(LoadMirrorButton);
            Controls.Add(ViewButton);
            Controls.Add(BrowseForOutputFolderButton);
            Controls.Add(OutputFolderControl);
            Controls.Add(TargetTreeView);
            Controls.Add(ClassNameControl);
            Controls.Add(TargetClassComboBox);
            Controls.Add(BrowseForAssemblyButton);
            Controls.Add(TargetDllTextBox);
            Controls.Add(DoneButton);
            Controls.Add(BuildButton);
            Controls.Add(TargetLabel);
            Controls.Add(XmlTreeView);
            Controls.Add(StartButton);
            Controls.Add(BrowseButton);
            Controls.Add(SourceXmlFileTextBox);
            DoubleBuffered = true;
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMenu;
            MaximizeBox = false;
            MaximumSize = new Size(1080, 760);
            MinimumSize = new Size(1080, 760);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xml Mirror 9.0.0";
            ((System.ComponentModel.ISupportInitialize)F1Image).EndInit();
            ((System.ComponentModel.ISupportInitialize)F2Image).EndInit();
            ContextMenu.ResumeLayout(false);
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            RightPanel.ResumeLayout(false);
            YouTubeButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)YouTubeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)WriterInfoImage).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        #endregion

        private PictureBox WriterInfoImage;
    }
    #endregion

}
