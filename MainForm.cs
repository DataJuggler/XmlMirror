

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.Net7;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Win.Controls.Objects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using XmlMirror.Runtime6;
using XmlMirror.Runtime6.Objects;
using XmlMirror.Runtime6.Enumerations;
using XmlMirror.Enumerations;
using XmlMirror.Runtime6.Util;
using XmlMirror.Objects;
using XmlMirror.Xml.Writers;
using XmlMirror.Xml.Parsers;
using XmlMirror.Util;

#endregion

namespace XmlMirror
{

    #region class MainForm
    /// <summary>
    /// This class is the Main Form for this application.
    /// </summary>
    public partial class MainForm : Form, ISelectedIndexListener
    {
        
        #region Private Variables
        private string sourceFileName;
        private string targetObjectFilePath;
        private List<FieldLink> fieldLinks;
        private XmlDocument xmlDoc;
        private Mirror selectedMirror;
        private string newObjectNodeName;
        private string newFieldName;
        private string collectionNodeName;
        private List<FieldValuePair> fields;
        private bool menuDropDownOpen;
        private OutputTypeEnum outputType;

        // Constant used for YouTube video channel path
        public const string YouTubePath = "https://www.youtube.com/channel/UCaw0joqvisKr3lYJ9Pd2vHA";
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a MainForm object
        /// </summary>
        public MainForm()
        {
            try
            {
                // Create Controls
                InitializeComponent();

                // Perform initializations for this object
                Init();
            }
            catch (Exception error)
            {
                // show a message
                MessageBoxHelper.ShowMessage(error.ToString(), "XML Mirror Startup Error");
            }
        }
        #endregion
        
        #region Events
            
            #region AboutMenuItem_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'AboutMenuItem' is clicked.
            /// </summary>
            private void AboutMenuItem_Click(object sender, EventArgs e)
            {
                // Create an aboutBox
                AboutXMLMirror aboutBox = new AboutXMLMirror();

                // show the dialog
                aboutBox.ShowDialog();
            }
            #endregion
            
            #region AboutMenuItem_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when About Menu Item _ Mouse Enter
            /// </summary>
            private void AboutMenuItem_MouseEnter(object sender, EventArgs e)
            {
                // Set to Black
                this.AboutMenuItem.ForeColor = System.Drawing.Color.Black;

                // Set to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region AboutMenuItem_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when About Menu Item _ Mouse Leave
            /// </summary>
            private void AboutMenuItem_MouseLeave(object sender, EventArgs e)
            {
                // Set to LemonChiffon
                this.AboutMenuItem.ForeColor = System.Drawing.Color.LemonChiffon;

                // Reset the cursor
                this.Cursor = Cursors.Default;
            }
            #endregion
            
            #region AutoFillButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AutoFillButton' is clicked.
            /// </summary>
            private void AutoFillButton_Click(object sender, EventArgs e)
            {
                // This method is used to auto fill any properties that have
                // the same name in the xml file and the selected object.
                AutoFill();
            }
            #endregion
            
            #region BrowseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'BrowseButton' is clicked.
            /// </summary>
            private void BrowseButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // create an openFileDialog
                OpenFileDialog fileDialog = new OpenFileDialog();

                // set the default extension
                fileDialog.DefaultExt = ".xml";

                // show the dialog
                DialogResult result = fileDialog.ShowDialog();

                // if the file exists
                this.SourceXmlFileTextBox.Text = fileDialog.FileName;

                // Set the SourceFileName
                this.SourceFileName = fileDialog.FileName;
            }
            #endregion
            
            #region BrowseForAssemblyButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'BrowseForAssemblyButton' is clicked.
            /// </summary>
            private void BrowseForAssemblyButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // create an openFileDialog
                OpenFileDialog fileDialog = new OpenFileDialog();

                // set the default extension
                fileDialog.DefaultExt = ".dll";
                fileDialog.FileName = "*.dll";

                // show the dialog
                DialogResult result = fileDialog.ShowDialog();

                // if the file exists
                this.TargetDllTextBox.Text = fileDialog.FileName;

               // Reflect on the dll
               ReflectDll(this.TargetDllTextBox.Text);
            }
            #endregion
            
            #region BrowseForOutputFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when 'BrowseForOutputFolderButton' is clicked.
            /// </summary>
            private void BrowseForOutputFolderButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // create a dialog
                FolderBrowserDialog dialog = new FolderBrowserDialog();

                // local
                string path = "";
                
                // if there is a SelectedMirror
                if (this.HasSelectedMirror)
                {
                    // set the OutputFolderPath
                    if (this.SelectedMirror.HasOutputFolderPath)
                    {
                        // set the path
                        path = this.SelectedMirror.OutputFolderPath;
                    }
                    
                }

                // if the path was not set
                if (!TextHelper.Exists(path))
                {  
                    // set the path
                    string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                    // get the path to the Data Juggler folder
                    string dataJugglerPath = Path.Combine(localFolder, "Data Juggler");

                    // set the path to 'XML Mirror' folder
                    path = Path.Combine(dataJugglerPath, "XML Mirror");
                }

                // if the path exists
                if (System.IO.Directory.Exists(path))
                {
                    // set the start up path
                    dialog.SelectedPath = path;
                }
                
                // show the dialog
                dialog.ShowDialog();

                // get the selected path
                string folderName = dialog.SelectedPath;

                // set the folderName
                this.OutputFolderControl.Text = folderName;
            }
            #endregion

            #region BuildButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BuildButton' is clicked.
            /// </summary>
            private void BuildButton_Click(object sender, EventArgs e)
            {
                // we are creating a parser
                if (this.OutputType == OutputTypeEnum.Parser)
                {
                    // build the parser
                    BuildParser();
                }
                else if (this.OutputType == OutputTypeEnum.Writer)
                {
                    // Build the writer
                    BuildWriter();
                }
            }
            #endregion
            
            #region Button_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Enter
            /// </summary>
            private void Button_MouseEnter(object sender, EventArgs e)
            {
                // Change to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Leave
            /// </summary>
            private void Button_MouseLeave(object sender, EventArgs e)
            {
                // restore the default cursor
                this.Cursor = Cursors.Default;
            }
            #endregion
            
            #region ClearAllButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ClearAllButton' is clicked.
            /// </summary>
            private void ClearAllButton_Click(object sender, EventArgs e)
            {
                
            }
            #endregion
            
            #region ClearFieldLink_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ClearFieldLink' menu option is clicked.
            /// </summary>
            private void ClearFieldLink_Click(object sender, EventArgs e)
            {
                // local
                XmlNode xmlNode = null;
                FieldValuePair fieldValuePair = null;
                FieldLink fieldLink = null;
                bool cleared = false;
                string targetFieldName = "";

                // if the selected node exists
                if (this.TargetTreeView.SelectedNode != null)
                {
                    // attempt to cast the tag as an XmlNode
                    xmlNode = this.TargetTreeView.SelectedNode.Tag as XmlNode;
                    fieldLink = this.TargetTreeView.SelectedNode.Tag as FieldLink;

                    // if the cast was successful and the xmlNode has a FieldValuePair object set.
                    if ((xmlNode != null) && (xmlNode.HasTargetFieldValuePair))
                    {
                        // set the fieldValuePair
                        fieldValuePair = xmlNode.TargetFieldValuePair;

                        // Restore the Tag as a FieldValuePair
                        this.TargetTreeView.SelectedNode.Tag = fieldValuePair;

                        // restore the node text
                        this.TargetTreeView.SelectedNode.Text = xmlNode.TargetFieldName;

                        // set the targetFieldName
                        targetFieldName = xmlNode.TargetFieldName;

                        // set cleared to true
                        cleared = true;
                    }
                    // if the FieldLink exists
                    else if ((fieldLink != null) && (fieldLink.HasFieldValuePair))
                    {
                        // set the fieldValuePair
                        fieldValuePair = fieldLink.FieldValuePair;

                        // Restore the Tag as a FieldValuePair
                        this.TargetTreeView.SelectedNode.Tag = fieldValuePair;

                        // restore the node text
                        this.TargetTreeView.SelectedNode.Text = fieldLink.TargetFieldName;

                        // set the targetFieldName
                        targetFieldName = fieldLink.TargetFieldName;

                        // set cleared to true
                        cleared = true;
                    }

                    // if the node was cleared (we must also remove it from the selected mirror to keep the counts in sync for Trial versions
                    if ((cleared) && (this.HasSelectedMirror) && (this.SelectedMirror.HasFieldLinks) && (TextHelper.Exists(targetFieldName)))
                    {
                        // find the index
                        int index = FindFieldLinkIndex(targetFieldName);

                        // if the index was found
                        if (index >= 0)
                        {
                            // if the index was found
                            this.SelectedMirror.FieldLinks.RemoveAt(index);
                        }
                    }
                }
            }
            #endregion
            
            #region ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            /// <summary>
            /// This event is fired when the Context Menu is Opening
            /// </summary>
            private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            {
                // if there is not a SelectedNode
                if (this.TargetTreeView.SelectedNode == null)
                {
                    // cancel the opening
                    e.Cancel = true;
                }
                else
                {
                    // if we are building a parser
                    if (OutputType == OutputTypeEnum.Parser)
                    {
                        // Show the Clear Field Link menu item
                        this.ClearFieldLink.Visible = true;
                        this.SkipFieldMenuItem.Visible = false;
                    }
                    else
                    {  
                        // Show the Clear Field Link menu item
                        this.SkipFieldMenuItem.Visible = true;
                        this.ClearFieldLink.Visible = false;

                        // Attempt to cast the Node.Tag as a FieldValuePair
                        FieldValuePair field = this.TargetTreeView.SelectedNode.Tag as FieldValuePair;

                        // If the field object exists
                        if (NullHelper.Exists(field))
                        {
                            // if the field is currently skipped
                            if (field.Skip)
                            {
                                // Toggle the text
                                this.SkipFieldMenuItem.Text = "Include Field";
                            }
                            else
                            {
                                // Toggle the text
                                this.SkipFieldMenuItem.Text = "Skip Field";
                            }
                        }
                        else
                        {
                            // If we can't get the field than cancel
                            e.Cancel = true;
                        }
                    }
                }
            }
            #endregion
            
            #region DataJugglerButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'DataJugglerButton' is clicked.
            /// </summary>
            private void DataJugglerButton_Click(object sender, EventArgs e)
            {
                
            }
            #endregion
            
            #region DocumentationMenuItem_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Documentation Menu Item _ Mouse Enter
            /// </summary>
            private void DocumentationMenuItem_MouseEnter(object sender, EventArgs e)
            {
                // Set the Cursor to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region DoneButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'CopyButton' is clicked.
            /// </summary>
            private void DoneButton_Click(object sender, EventArgs e)
            {
                // close this form
                this.Close();
            }
            #endregion
            
            #region HelpMenuItem_DropDownClosed(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Help Menu Item _ Drop Down Closed
            /// </summary>
            private void HelpMenuItem_DropDownClosed(object sender, EventArgs e)
            {
                // Set to false
                this.MenuDropDownOpen = false;

                // Reset the cursor
                this.Cursor = Cursors.Default;

                // Restore the color
                this.HelpMenuItem.ForeColor = Color.LemonChiffon;
            }
            #endregion
            
            #region HelpMenuItem_DropDownOpened(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Help Menu Item _ Drop Down Opened
            /// </summary>
            private void HelpMenuItem_DropDownOpened(object sender, EventArgs e)
            {
                // Set to false
                this.MenuDropDownOpen = true;

                // Set the cursor to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region HelpMenuItem_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Help Menu Item _ Mouse Enter
            /// </summary>
            private void HelpMenuItem_MouseEnter(object sender, EventArgs e)
            {
                // Set to Black
                this.HelpMenuItem.ForeColor = System.Drawing.Color.Black;

                // Set the cursor to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region HelpMenuItem_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Help Menu Item _ Mouse Leave
            /// </summary>
            private void HelpMenuItem_MouseLeave(object sender, EventArgs e)
            {
                // if not open
                if (!this.MenuDropDownOpen)
                {
                    // Reset the color back
                    this.HelpMenuItem.ForeColor = System.Drawing.Color.LemonChiffon;

                    // Reset the cursor
                    this.Cursor = Cursors.Default;
                }
            }
            #endregion
            
            #region LoadMirrorButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when 'LoadMirrorButton' is clicked.
            /// </summary>
            private void LoadMirrorButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // create an instance of the openMirror form
                OpenMirrorForm openMirror = new OpenMirrorForm();

                // show the open mirror
                openMirror.ShowDialog();

                // set the selected mirror
                this.SelectedMirror = openMirror.SelectedMirror;

                // if there is a selected mirror
                if (openMirror.HasSelectedMirror)
                {
                    // display the mirror
                    this.DisplayMirror(openMirror.SelectedMirror);
                }
            }
            #endregion
            
            #region OnSelectedIndexChanged(DataJuggler.Win.Controls.LabelComboBoxControl control, int selectedIndex, object selectedItem)
            /// <summary>
            /// This event is fired when a selection is made in the TargetClassComboBox.
            /// </summary>
            public void OnSelectedIndexChanged(DataJuggler.Win.Controls.LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // get the selected class name
                string selectedClassName = this.TargetClassComboBox.SelectedObject.ToString();

                // if the selected class name exists
                if (TextHelper.Exists(selectedClassName))
                {
                    // set the last index
                    int index = selectedClassName.LastIndexOf(".");

                    // if the index exists
                    if (index >= 0)
                    {
                        // set the roorClassName
                        string roorClassName = selectedClassName.Substring(0, index);

                        // set the className
                        string className = selectedClassName.Substring(index).Replace(".", "");
                        
                        // Get the plural name of this class
                        string pluralClassName = PluralWordHelper.GetPlural(className, TextCaseOptionsEnum.Upper_Case_First_Char);

                        // if we are creating a parser
                        if (this.OutputType == OutputTypeEnum.Parser)
                        {
                            // Set the name of the parser
                            this.ClassNameControl.Text = TextHelper.CombineStrings(pluralClassName, "Parser.cs");
                        }
                        else
                        {
                            // Set the name of the writer
                            this.ClassNameControl.Text = TextHelper.CombineStrings(pluralClassName, "Writer.cs");
                        }
                    }
                }
            }
            #endregion
            
            #region SaveMirrorButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when 'SaveMirrorButton' is clicked.
            /// </summary>
            private void SaveMirrorButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // Capture the selected mirror
                Mirror mirror = CaptureMirror();

                // Now we need to save this object in the Mirror folder
                bool saved = SaveMirror(mirror);
            }
            #endregion
            
            #region SelectAllButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'SelectAllButton' is clicked.
            /// </summary>
            private void SelectAllButton_Click(object sender, EventArgs e)
            {
                
            }
            #endregion
            
            #region SkipFieldMenuItem_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'SkipFieldMenuItem' is clicked.
            /// </summary>
            private void SkipFieldMenuItem_Click(object sender, EventArgs e)
            {
                // if the selected node exists
                if ((this.TargetTreeView.SelectedNode != null) && (this.TargetTreeView.SelectedNode.Tag != null))
                {
                    // Get the field value pair
                    FieldValuePair field = this.TargetTreeView.SelectedNode.Tag as FieldValuePair;
                    
                    // If the field object exists
                    if (NullHelper.Exists(field))
                    {
                        // Set to true
                        field.Skip = !field.Skip;

                        // if Skip is true
                        if (field.Skip)
                        {
                            // Show the Skip image
                            this.TargetTreeView.SelectedNode.ImageIndex = 1;
                            this.TargetTreeView.SelectedNode.SelectedImageIndex = 1;
                        }
                        else
                        {
                            // Show the Skip image
                            this.TargetTreeView.SelectedNode.ImageIndex = 0;
                            this.TargetTreeView.SelectedNode.SelectedImageIndex = 0;
                        }
                    }
                }
            }
            #endregion
            
            #region StartButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'StartButton' is clicked.
            /// </summary>
            private void StartButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // set the SourceFileName in case a user typed in the path
                this.SourceFileName = this.SourceXmlFileTextBox.Text;

                // if the SourceFileName exists
                if (this.HasSourceFileName)
                {  
                    // create an instance of the parser
                    XmlParser parser = new XmlParser(this.SourceFileName);

                    // parse the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument();

                    // if there is an error
                    if (parser.HasError)
                    {
                        // set the error
                        string error = parser.Error.ToString();

                        // Show the error
                        MessageBoxHelper.ShowMessage(error, "Parser Error");
                    }

                    // if the XmlDoc exists
                    if (this.HasXmlDoc)
                    {
                        // Display the XmlDoc in the TreeView
                        DisplayXmlDoc(this.XmlDoc);
                    }
                }
            }
            #endregion

            #region TargetTreeView_DragDrop(object sender, DragEventArgs e)
            /// <summary>
            /// This event handles the drag and drop
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void TargetTreeView_DragDrop(object sender, DragEventArgs e)
            {
                // local
                bool abort = false;
               
                // if we didn't abort
                if (!abort)
                {
                    // Retrieve the client coordinates of the drop location.
                    Point targetPoint = TargetTreeView.PointToClient(new Point(e.X, e.Y));

                    // Retrieve the node at the drop location.
                    TreeNode targetNodeSource = TargetTreeView.GetNodeAt(targetPoint);

                    // set the targetNode
                    TreeNode targetNode = targetNodeSource as TreeNode;

                    // if the targetNode exists
                    if (targetNode != null)
                    {
                        // Retrieve the node that was dragged.
                        TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                        // Confirm that the node at the drop location is not 
                        // the dragged node or a descendant of the dragged node
                        // This prevents accidently dropping a node in the same treeview
                        if ((draggedNode != null) && (!draggedNode.Equals(targetNode)) && (!ContainsNode(draggedNode, targetNode)))
                        {
                            // Handle the Node assignment
                            HandleNodeAssignment(draggedNode, targetNode);

                            // Recapture the SelectedMirror to reset the FieldLinks.Count();
                            this.SelectedMirror = this.CaptureMirror();
                        }
                    }
                }

                // Enable the BuildParser button if there are one or more FieldLinks
                UIControl();
            }
            #endregion
            
            #region TargetTreeView_DragEnter(object sender, DragEventArgs e)
            /// <summary>
            /// This event is fired when the Target Tree View is dragged over
            /// </summary>
            private void TargetTreeView_DragEnter(object sender, DragEventArgs e)
            {
                // allow the effect
                e.Effect = e.AllowedEffect;
            }
            #endregion
            
            #region TargetTreeView_DragOver(object sender, DragEventArgs e)
            /// <summary>
            /// This event is fired when Target Tree View _ Drag Over
            /// </summary>
            private void TargetTreeView_DragOver(object sender, DragEventArgs e)
            {
                // Retrieve the client coordinates of the mouse position.
                Point targetPoint = TargetTreeView.PointToClient(new Point(e.X, e.Y));

                // Select the node at the mouse position.
                TargetTreeView.SelectedNode = TargetTreeView.GetNodeAt(targetPoint);
            }
            #endregion
            
            #region ViewButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when 'ViewButton' is clicked.
            /// </summary>
            private void ViewButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // Use reflection to view all the properties in this object; Parsers only view Read Write Properties.
                // Writers view all properties.
                bool skipReadOnlyProperties = (this.OutputType == OutputTypeEnum.Parser);

                try
                {
                    
                    // Get the fields
                    this.Fields = GetFields(skipReadOnlyProperties);

                    // if there are one or more fields
                    if (ListHelper.HasOneOrMoreItems(this.Fields))
                    {
                        // Sort the fields because some fields are loaded from partial classes
                        // that return two sorted lists
                        SortFields();

                        // display the properties of the object
                        DisplayObjectFields(this.Fields);
                    }

                    // Control the UI
                    UIControl();
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // locals
                    string message = "An error occured using reflection to view the selected object.";
                    string title = "Error";

                    // show a message to the user
                    MessageBoxHelper.ShowMessage(message, title);
                }
                finally
                {
                    // Determine if the AutoFillButton should be shown or not
                    UIControl();
                }
            }
            #endregion
            
            #region ViewPDFMenuItem_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ViewPDFMenuItem' is clicked.
            /// </summary>
            private void ViewPDFMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    // Set the path to the PDF Users Guide
                    string pdfUsersGuidePath = GetHelpDocumentPath(DocumentType.Pdf);

                    // if the path exists
                    if (File.Exists(pdfUsersGuidePath))
                    {
                        // Open the file
                        System.Diagnostics.Process.Start(pdfUsersGuidePath);
                    }
                    else
                    {
                        // Show a message to the user
                        MessageBoxHelper.ShowMessage("Sorry we could not find the desired documentation.", "File Not Found");
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // Show a message to the user
                    MessageBoxHelper.ShowMessage("Sorry we could not find the desired documentation.", "File Open Error");
                }
            }
            #endregion
            
            #region ViewWordMenuItem_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ViewWordMenuItem' is clicked.
            /// </summary>
            private void ViewWordMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    // Set the path to the PDF Users Guide
                    string wordUsersGuidePath = GetHelpDocumentPath(DocumentType.Word);

                    // if the path exists
                    if (File.Exists(wordUsersGuidePath))
                    {
                        // Open the file
                        System.Diagnostics.Process.Start(wordUsersGuidePath);
                    }
                    else
                    {
                        // Show a message to the user
                        MessageBoxHelper.ShowMessage("Sorry we could not find the desired documentation.", "File Not Found");
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // Show a message to the user
                    MessageBoxHelper.ShowMessage("Sorry we could not find the desired documentation.", "File Open Error");
                }
            }
            #endregion
            
            #region WatchYouTubeMenuItem_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'WatchYouTubeMenuItem' is clicked.
            /// </summary>
            private void WatchYouTubeMenuItem_Click(object sender, EventArgs e)
            {
                // Launch the default browser to the XML Mirror Intro Video
                System.Diagnostics.Process.Start(YouTubePath);
            }
            #endregion
            
            #region XmlParserRadioButton_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Xml Parser Radio Button _ Checked Changed
            /// </summary>
            private void XmlParserRadioButton_CheckedChanged(object sender, EventArgs e)
            {
                // Capture the current mirror
                this.SelectedMirror = this.CaptureMirror();

                // if checked
                if (this.XmlParserRadioButton.Checked)
                {
                    // Set to Parser
                    this.OutputType = OutputTypeEnum.Parser;

                    // if the value for HasSelectedMirror is true
                    if (HasSelectedMirror)
                    {
                        SelectedMirror.OutputType = OutputType;
                        SelectedMirror.ClassName = SelectedMirror.ClassName.Replace("Writer", "Parser");
                        SelectedMirror.Namespace = SelectedMirror.Namespace.Replace("Writer", "Parser");
                        SelectedMirror.OutputFolderPath = SelectedMirror.OutputFolderPath.Replace("Writer", "Parser");

                        // Display the selected mirror
                        DisplayMirror(SelectedMirror);
                    }
                }
                
                // Control the UI
                UIControl();
            }
            #endregion
            
            #region XmlTreeView_ItemDrag(object sender, ItemDragEventArgs e)
            /// <summary>
            /// This event is fired when Xml Tree View _ Item Drag
            /// </summary>
            private void XmlTreeView_ItemDrag(object sender, ItemDragEventArgs e)
            {
                DoDragDrop(e.Item, DragDropEffects.All);
            }
            #endregion
            
            #region XmlTreeView_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// This event is fired when Xml Tree View _ Key Down
            /// </summary>
            private void XmlTreeView_KeyDown(object sender, KeyEventArgs e)
            {
                // update: 8.31.2012: Changed from node text to full name
                string fullName = "";
                XmlNode node = null;

                // if there is a selected node
                if (this.XmlTreeView.SelectedNode != null)
                {
                    // get the selected node
                    node = this.XmlTreeView.SelectedNode.Tag as XmlNode;

                    // if the node exists
                    if (node != null)
                    {
                        // set the fullName
                        fullName = node.GetFullName();

                        // local
                        string nodeText = this.XmlTreeView.SelectedNode.Text;

                        // F1 indicates the start of a new object
                        if (e.KeyCode == Keys.F1)
                        {
                            // if there is an existing NewObjectNodeName
                            if (this.HasNewObjectNodeName)
                            {
                                // Erase all copies of this object
                                this.SelectNodeImage(this.NewObjectNodeName, 0);
                            }

                            // use the single new object image index
                            this.NewObjectNodeName = fullName;
                            this.XmlTreeView.SelectedNode.ImageIndex = 1;
                            this.XmlTreeView.SelectedNode.SelectedImageIndex = 1;

                            // Set the NewFieldName
                            this.NewFieldName = nodeText;

                            // apply to all objects with this name
                            SelectNodeImage(fullName, 1);
                        }
                        // F2 indicates the start of a new collection
                        else if (e.KeyCode == Keys.F2)
                        {
                            // if there is an existing NewObjectNodeName
                            if (this.HasCollectionNodeName)
                            {
                                // Erase all copies of this object
                                this.SelectNodeImage(this.CollectionNodeName, 0);
                            }

                            // use the new collection image index
                            this.CollectionNodeName = fullName;
                            this.XmlTreeView.SelectedNode.ImageIndex = 2;
                            this.XmlTreeView.SelectedNode.SelectedImageIndex = 2;
                        }
                    }
                }

                // Determine if the AutoFillButton should be shown
                UIControl();
            }
            #endregion
            
            #region XmlWriterRadioButton_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Xml Writer Radio Button _ Checked Changed
            /// </summary>
            private void XmlWriterRadioButton_CheckedChanged(object sender, EventArgs e)
            {
                // Capture the current mirror
                this.SelectedMirror = this.CaptureMirror();

                // if checked
                if (this.XmlWriterRadioButton.Checked)
                {   
                    // Set the output type to Writer
                    this.OutputType = OutputTypeEnum.Writer;

                    // if the value for HasSelectedMirror is true
                    if (HasSelectedMirror)
                    {
                        SelectedMirror.OutputType = OutputTypeEnum.Writer;
                        SelectedMirror.ClassName = SelectedMirror.ClassName.Replace("Parser", "Writer");
                        SelectedMirror.Namespace = SelectedMirror.Namespace.Replace("Parser", "Writer");
                        SelectedMirror.OutputFolderPath = SelectedMirror.OutputFolderPath.Replace("Parser", "Writer");

                        // Display the current mirror
                        DisplayMirror(this.SelectedMirror);
                    }
                }
                

                // Control the UI
                UIControl();
            }
            #endregion
            
            #region YouTubeButton_Click(object sender, EventArgs e)

            #endregion
            
        #endregion

        #region Methods

            #region AssignNode(XmlNode xmlNode, TreeNode targetNode)
            /// <summary>
            /// This method Assigns a Node
            /// </summary>
            public void AssignNode(XmlNode xmlNode, TreeNode targetNode)
            {
                // The XmlNode.Tag is cast as a FieldValuePair.
                // When the Clear FieldLink option is added to the SelectedNode
                // The FieldValuePair is "put back" to the Node.Tag so we need to 
                // Store the FieldValuePair to be able to do that
                FieldValuePair existingFieldValuePair = targetNode.Tag as FieldValuePair;

                // if the existingFieldValuePair exists
                if (existingFieldValuePair != null)
                {
                    // set the TargetFieldValuePair
                    xmlNode.TargetFieldValuePair = existingFieldValuePair;
                }

                // set the SourceFieldName and TargetFieldName
                xmlNode.SourceFieldName = xmlNode.GetFullName();
                xmlNode.TargetFieldName = targetNode.Text;
                        
                // set the XmlNode
                targetNode.Tag = xmlNode;

                // update the text
                targetNode.Text += " :: " + xmlNode.GetFullName();

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
            #endregion
            
            #region AutoFill()
            /// <summary>
            /// This method Auto Fill
            /// </summary>
            public void AutoFill()
            {
                try
                {
                    // Reset the color
                    this.XmlTreeView.BackColor = Color.White;

                    // Set Focus to the Hidden Button
                    this.HiddenButton.Focus(); 

                    // if the SelectedNode Text matches the NewFieldName
                    if (TextHelper.IsEqual(XmlTreeView.SelectedNode.Text, NewFieldName))
                    {
                        // if there are child nodes
                        if (XmlTreeView.SelectedNode.Nodes.Count > 0)
                        {
                            // iterate the child nodes
                            foreach (TreeNode node in XmlTreeView.SelectedNode.Nodes)
                            {
                                // Attempt to assign this node
                                HandleNodeAssignment(node);                                
                            }

                            // Capture the current mirror
                            this.SelectedMirror = CaptureMirror();
                        }
                        else
                        {
                            // Show the user a message that the selected node needs to be the same node as the NewFieldName
                            MessageBoxHelper.ShowMessage("The selected node does not have any child nodes", "Invalid Selection");
                        }
                    }
                    else
                    {
                        // Change the BackColor of the XmlTreeView to make it obvious to the user what the problem is
                        this.XmlTreeView.BackColor = Color.Coral;      

                        // Show the user a message that the selected node needs to be the same node as the NewFieldName
                        MessageBoxHelper.ShowMessage("Please select the 'SelectedNode' for new objects in the XmlTreeView", "Invalid Selection");
                    }
                }
                catch (Exception error)
                {
                    // Show the error
                    string message = "An error occurred attempting to 'Auto Fill'" + Environment.NewLine + error.ToString();

                    // Show the user a message
                    MessageBoxHelper.ShowMessage(message, "Auto Fill Error");
                }

                // Enable the BuildParser button 
                UIControl();
            }
            #endregion

            #region BuildParser()
            /// <summary>
            /// This method Build Parser
            /// The code in this method was recovered via decompiling my .exe after my hard drive crashed.
            /// I was an idiot for not having the code in source control!
            /// </summary>
            public void BuildParser()
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  
                
                try
                {
                    string filePath = "";
                    string path = "";
                    string targetNamespace = "";
                    List<Reference> usingStatements = new List<Reference>();
                    string className = "";
                    string classDescription = "This class is used to parse '[CLASSNAME]' objects.";
                    string pluralClassName = "";
                    string regionText = "";
                    string newValue = "";

                    // Update 12.30.2016: I moved the CaptureMirror to inside the TryCatch
                        
                    // Capture the current mirror
                    this.SelectedMirror = this.CaptureMirror();
                    
                    // If the SelectedMirror exists
                    if (this.HasSelectedMirror && TextHelper.Exists(this.SelectedMirror.TargetClassName))
                    {
                        int length = this.SelectedMirror.TargetClassName.LastIndexOf(".");
                        targetNamespace = this.SelectedMirror.TargetClassName.Substring(0, length);
                        className = this.SelectedMirror.TargetClassName.Substring(length + 1);
                        pluralClassName = PluralWordHelper.GetPlural(className, TextCaseOptionsEnum.Lower_Case_First_Char);
                        classDescription = classDescription.Replace("[CLASSNAME]", className);
                        string pluralName = PluralWordHelper.GetPlural(className, TextCaseOptionsEnum.Lower_Case_First_Char);
                        regionText = "class " + this.selectedMirror.ClassName.Replace(".cs", "") + " : ParserBaseClass";
                        string lineText = TextHelper.CombineStrings("namespace ", this.SelectedMirror.Namespace);
                        usingStatements = CreateUsingStatements(targetNamespace, true);
                        if (this.SelectedMirror.HasOutputFolderPath && this.SelectedMirror.HasFieldLinks)
                        {
                            ProjectFileManager fileManager = new ProjectFileManager();
                            ObjectLoaderWriter writer = new ObjectLoaderWriter(fileManager, true);
                            ObjectLoaderWriter writer2 = null;
                            filePath = Path.Combine(this.SelectedMirror.OutputFolderPath, this.ClassName) + ".base.cs";
                            path = Path.Combine(this.SelectedMirror.OutputFolderPath, this.ClassName) + ".custom.cs";
                            writer.CreateFile(filePath, DataManager.ProjectTypeEnum.NotSet);
                            WriteUsingStatements(writer, usingStatements);
                            writer.WriteLine(lineText);
                            writer.WriteOpenBracket(true);
                            writer.WriteLine();
                            writer.BeginRegion(regionText);
                            writer.WriteLine("/// <summary>");
                            writer.WriteLine("/// " + classDescription);
                            writer.WriteLine("/// </summary>");
                            writer.WriteLine("public partial " + regionText);
                            writer.WriteOpenBracket(true);
                            writer.WriteLine();
                            writer.BeginRegion("Methods");
                            writer.WriteLine();
                            writer.Indent++;

                            // If we are parsing a collection
                            if (this.SelectedMirror.MirrorType == MirrorTypeEnum.Collection)
                            {
                                // Write the LoadListMethod
                                this.WriteLoadListMethod(writer, className, pluralClassName);
                            }
                            else
                            {
                                // Write the ParseSingletonMethod
                                this.WriteParseSingletonMethod(writer, className);
                            }

                            // Write a line
                            writer.WriteLine();

                            // Write the ParseObjectMethod
                            this.WriteParseObjectMethod(writer, className);

                            // If this is a Collection being parsed
                            if (this.SelectedMirror.MirrorType == MirrorTypeEnum.Collection)
                            {
                                // Write a blank line
                                writer.WriteLine();

                                // Write hte ParseListMethod
                                this.WriteParseListMethod(writer, className, pluralClassName);
                            }

                            // decrease the value for indent
                            writer.Indent--;
                            writer.WriteLine();
                            writer.EndRegion();
                            writer.WriteLine();
                            writer.WriteCloseBracket(true);
                            writer.EndRegion();
                            writer.WriteLine();
                            writer.WriteCloseBracket(true);
                            writer.CloseFile();
                            writer = null;
                            if (!File.Exists(path))
                            {
                                fileManager = new ProjectFileManager();
                                writer2 = new ObjectLoaderWriter(fileManager, true);
                                newValue = writer2.LowerCaseFirstChar(className);
                                writer2.CreateFile(path, DataManager.ProjectTypeEnum.NotSet);
                                this.WriteUsingStatements(writer2, usingStatements);
                                writer2.WriteLine(lineText);
                                writer2.WriteOpenBracket(true);
                                writer2.WriteLine();
                                writer2.BeginRegion(regionText);
                                writer2.WriteLine("/// <summary>");
                                writer2.WriteLine("/// " + classDescription);
                                writer2.WriteLine("/// </summary>");
                                writer2.WriteLine("public partial " + regionText);
                                writer2.WriteOpenBracket(true);
                                writer2.WriteLine();
                                writer2.BeginRegion("Events");
                                writer2.WriteLine();
                                writer2.Indent++;
                                string parsingRegionDeclaration = "Parsing(XmlNode xmlNode)";
                                parsingRegionDeclaration = parsingRegionDeclaration.Replace("[CLASSNAME]", className);
                                writer2.BeginRegion(parsingRegionDeclaration);
                                string parsingDescription = "/// This event is fired BEFORE the collection is initialized.";
                                string parsingMethodDeclaration = "public bool Parsing(XmlNode xmlNode)";
                                parsingMethodDeclaration = parsingMethodDeclaration.Replace("[CLASSNAME]", className);
                                writer2.WriteLine("/// <summary>");
                                writer2.WriteLine(parsingDescription);
                                writer2.WriteLine("/// </summary>");
                                writer2.WriteLine("/// <param name=\"xmlNode\"></param>");
                                writer2.WriteLine("/// <returns>True if cancelled else false if not.</returns>");
                                writer2.WriteLine(parsingMethodDeclaration);
                                writer2.WriteOpenBracket(true);
                                writer2.WriteComment("initial value");
                                writer2.WriteLine("bool cancel = false;");
                                writer2.WriteLine();
                                writer2.WriteComment("Add any pre processing code here. Set cancel to true to abort parsing this collection.");
                                writer2.WriteLine();
                                writer2.WriteComment("return value");
                                writer2.WriteLine("return cancel;");
                                writer2.WriteCloseBracket(true);
                                writer2.EndRegion();
                                writer2.WriteLine();
                                parsingRegionDeclaration = "Parsing(XmlNode xmlNode, ref [CLASSNAME] [SINGLEOBJECTNAME])";
                                parsingRegionDeclaration = parsingRegionDeclaration.Replace("[CLASSNAME]", className).Replace("[SINGLEOBJECTNAME]", newValue);
                                writer2.BeginRegion(parsingRegionDeclaration);
                                parsingDescription = "/// This event is fired when a single object is initialized.";
                                parsingMethodDeclaration = "public bool Parsing(XmlNode xmlNode, ref [CLASSNAME] [SINGLEOBJECTNAME])";
                                parsingMethodDeclaration = parsingMethodDeclaration.Replace("[CLASSNAME]", className).Replace("[SINGLEOBJECTNAME]", newValue);
                                writer2.WriteLine("/// <summary>");
                                writer2.WriteLine(parsingDescription);
                                writer2.WriteLine("/// </summary>");
                                writer2.WriteLine("/// <param name=\"xmlNode\"></param>");
                                writer2.WriteLine("/// <param name=\"" + newValue + "\"></param>");
                                writer2.WriteLine("/// <returns>True if cancelled else false if not.</returns>");
                                writer2.WriteLine(parsingMethodDeclaration);
                                writer2.WriteOpenBracket(true);
                                writer2.WriteComment("initial value");
                                writer2.WriteLine("bool cancel = false;");
                                writer2.WriteLine();
                                writer2.WriteComment("Add any pre processing code here. Set cancel to true to abort adding this object.");
                                writer2.WriteLine();
                                writer2.WriteComment("return value");
                                writer2.WriteLine("return cancel;");
                                writer2.WriteCloseBracket(true);
                                writer2.EndRegion();
                                writer2.WriteLine();
                                parsingRegionDeclaration = "Parsed(XmlNode xmlNode, ref [CLASSNAME] [SINGLEOBJECTNAME])";
                                parsingRegionDeclaration = parsingRegionDeclaration.Replace("[CLASSNAME]", className).Replace("[SINGLEOBJECTNAME]", newValue);
                                writer2.BeginRegion(parsingRegionDeclaration);
                                parsingMethodDeclaration = "public bool Parsed(XmlNode xmlNode, ref [CLASSNAME] [SINGLEOBJECTNAME])";
                                parsingMethodDeclaration = parsingMethodDeclaration.Replace("[CLASSNAME]", className).Replace("[SINGLEOBJECTNAME]", newValue);
                                writer2.WriteLine("/// <summary>");
                                writer2.WriteLine("/// This event is fired AFTER the " + newValue + " is parsed.");
                                writer2.WriteLine("/// </summary>");
                                writer2.WriteLine("/// <param name=\"xmlNode\"></param>");
                                writer2.WriteLine("/// <param name=\"" + newValue + "\"></param>");
                                writer2.WriteLine("/// <returns>True if cancelled else false if not.</returns>");
                                writer2.WriteLine(parsingMethodDeclaration);
                                writer2.WriteOpenBracket(true);
                                writer2.WriteComment("initial value");
                                writer2.WriteLine("bool cancel = false;");
                                writer2.WriteLine();
                                writer2.WriteComment("Add any post processing code here. Set cancel to true to abort adding this object.");
                                writer2.WriteLine();
                                writer2.WriteComment("return value");
                                writer2.WriteLine("return cancel;");
                                writer2.WriteCloseBracket(true);
                                writer2.EndRegion();
                                writer2.WriteLine();
                                writer2.Indent--;
                                writer2.EndRegion();
                                writer2.WriteLine();
                                writer2.WriteCloseBracket(true);
                                writer2.EndRegion();
                                writer2.WriteLine();
                                writer2.WriteCloseBracket(true);
                                writer2.CloseFile();
                                writer2 = null;
                            }
                            MessageBoxHelper.ShowMessage("The parser has been created.", "Parser Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exception)
                {
                    exception.ToString();
                    MessageBoxHelper.ShowMessage("An error occurred creating the parser.", "Error");
                }
            }
            #endregion
            
            #region BuildWriter()
            /// <summary>
            /// This method Builds a Writer that is much faster to export to Xml compared to 
            /// using the XmlMirror.Runtime.WriteObject method is much slower due to using
            /// reflection.
            /// </summary>
            public void BuildWriter()
            {
                // Set Focus to the Hidden Button
                this.HiddenButton.Focus();  

                // Capture the current mirror
                this.SelectedMirror = this.CaptureMirror();

                try
                {
                    // Update 1.1.2017: The Fields should already be loaded
                    // This had to be commented out or any Fields that were skipped get erased
                    // Attempt to get the fields
                    // this.Fields = GetFields();

                    // if we have one or more fields
                    if (ListHelper.HasOneOrMoreItems(this.Fields))
                    {
                        string filePath = "";
                        // string path = "";
                        string targetNamespace = "";
                        List<Reference> usingStatements = new List<Reference>();
                        string className = "";
                        string classDescription = "This class is used to export an instance or a list of '[CLASSNAME]' objects to xml.";
                        string regionText = "";
                        string writerName = "";
                        
                        // If the SelectedMirror exists
                        if (this.HasSelectedMirror && TextHelper.Exists(this.SelectedMirror.TargetClassName))
                        {
                            int length = this.SelectedMirror.TargetClassName.LastIndexOf(".");
                            targetNamespace = this.SelectedMirror.TargetClassName.Substring(0, length);
                            className = this.SelectedMirror.TargetClassName.Substring(length + 1);
                            writerName = this.ClassNameControl.Text.Replace(".cs", "");
                            classDescription = classDescription.Replace("[CLASSNAME]", className);
                            regionText = "class " + writerName;
                            string lineText = TextHelper.CombineStrings("namespace ", this.SelectedMirror.Namespace);
                            usingStatements = this.CreateUsingStatements(targetNamespace, false);
                            if (this.SelectedMirror.HasOutputFolderPath && this.SelectedMirror.HasFieldLinks)
                            {
                                // Create the fileManager and the two writers
                                ProjectFileManager fileManager = new ProjectFileManager();
                                ObjectLoaderWriter writer = new ObjectLoaderWriter(fileManager, true);
                                // ObjectLoaderWriter writer2 = new ObjectLoaderWriter(fileManager, true);
                                
                                // ObjectLoaderWriter writer2 = null;
                                filePath = Path.Combine(this.SelectedMirror.OutputFolderPath, writerName) + ".cs";
                                // path = Path.Combine(this.SelectedMirror.OutputFolderPath, writerName) + "custom.cs";
                                writer.CreateFile(filePath, DataManager.ProjectTypeEnum.NotSet);
                                this.WriteUsingStatements(writer, usingStatements);
                                writer.WriteLine(lineText);
                                writer.WriteOpenBracket(true);
                                writer.WriteLine();
                                writer.BeginRegion(regionText);
                                writer.WriteLine("/// <summary>");
                                writer.WriteLine("/// " + classDescription);
                                writer.WriteLine("/// </summary>");
                                writer.WriteLine("public " + regionText);
                                writer.WriteOpenBracket(true);
                                writer.WriteLine();
                                writer.BeginRegion("Methods");
                                writer.WriteLine();
                                writer.Indent++;
                                
                                // Write out the code to export a collection
                                WriteExportListMethod(writer, className, writerName);
                               
                                // Write the ExportObjectMethod
                                WriteExportObjectMethod(writer, className);
                                
                                // Decrease Indent
                                writer.Indent--;
                                writer.WriteLine();
                                writer.EndRegion();
                                writer.WriteLine();
                                writer.WriteCloseBracket(true);
                                writer.EndRegion();
                                writer.WriteLine();
                                writer.WriteCloseBracket(true);
                                writer.CloseFile();
                                writer = null;

                            //      I do not think a .custom class has to be created for writers;
                            //      If I change my mind, the code here creates a writer
                            //    // Only write the .custom.cs class if it does not already exist;
                            //    // This allows for customizations to be written that will not
                            //    // be lost if you rebuild the writer
                            //    if (!File.Exists(path))
                            //    {
                            //        fileManager = new ProjectFileManager();
                            //        writer2 = new ObjectLoaderWriter(fileManager, true);
                            //        string newValue = writer2.LowerCaseFirstChar(className);
                            //        writer2.CreateFile(path, DataManager.ProjectTypeEnum.NotSet);
                            //        this.WriteUsingStatements(writer2, usingStatements);
                            //        writer2.WriteLine(lineText);
                            //        writer2.WriteOpenBracket(true);
                            //        writer2.WriteLine();
                            //        writer2.BeginRegion(regionText);
                            //        writer2.WriteLine("/// <summary>");
                            //        writer2.WriteLine("/// " + classDescription);
                            //        writer2.WriteLine("/// </summary>");
                            //        writer2.WriteLine("public partial " + regionText);
                            //        writer2.WriteOpenBracket(true);
                            //        writer2.WriteLine();
                            //        writer2.BeginRegion("Methods");
                            //        writer2.WriteLine();
                            //        writer2.Indent++;
                            //        string skipWritingFieldRegion = "SkipWritingField(string fieldName)";
                            //        writer2.BeginRegion(skipWritingFieldRegion);
                            //        string skipWritingFieldMethodDeclaration = "public bool " + skipWritingFieldRegion;
                            //        writer2.WriteLine("/// <summary>");
                            //        writer2.WriteLine("/// This method is used to allow customizations to what fields should be skipped.");
                            //        writer2.WriteLine("/// </summary>");
                            //        writer2.WriteLine("/// <param name=\"fieldName\"></param>");
                            //        writer2.WriteLine("/// <returns>True if skipped else false if not.</returns>");
                            //        writer2.WriteLine(skipWritingFieldMethodDeclaration);
                            //        writer2.WriteOpenBracket(true);
                            //        writer2.WriteComment("initial value");
                            //        writer2.WriteLine("bool skip = false;");
                            //        writer2.WriteLine();
                            //        writer2.WriteComment("Add any field names here that should not be exported using a writer.");
                            //        writer2.WriteLine();
                            //        writer2.WriteComment("return value");
                            //        writer2.WriteLine("return skip;");
                            //        writer2.WriteCloseBracket(true);
                            //        writer2.EndRegion();
                            //        writer2.WriteLine();
                            //        writer2.Indent--;
                            //        writer2.EndRegion();
                            //        writer2.WriteLine();
                            //        writer2.WriteCloseBracket(true);
                            //        writer2.EndRegion();
                            //        writer2.WriteLine();
                            //        writer2.WriteCloseBracket(true);
                            //        writer2.CloseFile();
                            //        writer2 = null;
                            //    }

                                // Show the user a message
                                MessageBoxHelper.ShowMessage("The writer has been created.", "Writerer Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    // for debugging only
                    exception.ToString();

                    // Show the user a message
                    MessageBoxHelper.ShowMessage("An error occurred creating the writer.", "Error");
                }
            }
            #endregion
            
            #region CaptureMirror()
            /// <summary>
            /// This method captures the Mirror
            /// </summary>
            private Mirror CaptureMirror()
            {
                // create a new mirror object
                Mirror mirror = new Mirror();

                // Set the MirrorName
                mirror.Name = GetMirrorName(this.SelectedClassName, this.ClassName);
               
                // save the properties from the loaded file(s)
                mirror.SourceXmlFilePath = this.SourceXmlFileTextBox.Text;

                // save the TargetObjectFilePath
                mirror.TargetObjectFilePath = this.TargetObjectFilePath + this.SelectedAssemblyName;

                // Set the TargetClassName
                mirror.TargetClassName = this.SelectedClassName;

                // set the ParserName
                mirror.ClassName = this.ClassName;

                // set the Parser Namespace
                mirror.Namespace = this.NamespaceControl.Text;

                // set the outputFolderPath
                mirror.OutputFolderPath = this.OutputFolder;

                // Update for version 2: Set the value for OutputType
                mirror.OutputType = OutputType;

                // Capture the Fields for both OutputTypes
                mirror.Fields = Fields;

                // if a parser is being saved
                if (this.OutputType == OutputTypeEnum.Parser)
                {
                    // load the FieldLinks from the TargetTreeView
                    mirror.FieldLinks = LoadFieldLinks();
                
                    // if there are one or more FieldLinks
                    if (mirror.HasOneOrMoreFieldLinks)
                    {
                        // Update 12.30.2016: The FieldLinks need to be updated to contain the FieldValuePair
                        foreach (FieldLink fieldLink in mirror.FieldLinks)
                        {
                            // Attempt to find the FieldValuePair for this FieldLink
                            fieldLink.FieldValuePair = this.Fields.FirstOrDefault(x => x.FieldName == fieldLink.Name);
                        }
                    }

                    // if the CollectionNodeName
                    if (this.HasCollectionNodeName)
                    {
                        // find the CollectionNodeName 
                        mirror.CollectionNodeName = this.CollectionNodeName;
                    }
                    else
                    {
                        // find the CollectionNodeName 
                        mirror.CollectionNodeName = "";
                    }

                    // Set the ObjectNodeName
                    mirror.NewObjectNodeName = NewObjectNodeName;

                    // if the CollectionNodeName is set
                    if (mirror.HasCollectionNodeName)
                    {
                        // if there is a CollectionNodeName
                        mirror.MirrorType = MirrorTypeEnum.Collection;
                    }
                    else if (HasNewObjectNodeName)
                    {
                        // if there is a CollectionNodeName
                        mirror.MirrorType = MirrorTypeEnum.Singleton;
                    }
                }
                else
                {
                    // Capturing a Writer
                    mirror.MirrorType = MirrorTypeEnum.Writer;
                }

                // return value
                return mirror;
            }
            #endregion

            #region ContainsNode(FieldLinkTreeNode node1, FieldLinkTreeNode node2)
            /// <summary>
            ///  Determine whether one node is a parent or ancestor of a second node.
            /// </summary>
            /// <param name="node1"></param>
            /// <param name="node2"></param>
            /// <returns></returns>
            private bool ContainsNode(FieldLinkTreeNode node1, FieldLinkTreeNode node2)
            {
                // initial value
                bool contains = false;

                // if the node2 exists
                if ((node1 != null) && (node2 != null))
                {
                    // Check the parent node of the second node.
                    if (node2.Parent == null)
                    {
                        return false;
                    }

                    // if same node
                    if (node2.Parent.Equals(node1))
                    {
                        return true;
                    }

                    // If the parent node is not null or equal to the first node, 
                    // call the ContainsNode method recursively using the parent of 
                    // the second node.
                    return ContainsNode(node1, node2.Parent);
                }

                // return value
                return contains;
            }
            #endregion
            
            #region ContainsNode(TreeNode node1, TreeNode node2)
            /// <summary>
            ///  Determine whether one node is a parent or ancestor of a second node.
            /// </summary>
            /// <param name="node1"></param>
            /// <param name="node2"></param>
            /// <returns></returns>
            private bool ContainsNode(TreeNode node1, TreeNode node2)
            {
                // initial value
                bool contains = false;

                // if the node2 exists
                if ((node1 != null) && (node2 != null))
                {
                    // Check the parent node of the second node.
                    if (node2.Parent == null) 
                    {
                        return false;
                    }
                    
                    // if same node
                    if (node2.Parent.Equals(node1))
                    {
                        return true;
                    }

                    // If the parent node is not null or equal to the first node, 
                    // call the ContainsNode method recursively using the parent of 
                    // the second node.
                    return ContainsNode(node1, node2.Parent);
                }

                // return value
                return contains;
            }
            #endregion
            
            #region ConvertFields()
            /// <summary>
            /// This method returns a list of Fields
            /// </summary>
            private List<FieldValuePair> ConvertFields()
            {
                // initial value
                List<FieldValuePair> listOfFields = null;

                // if the Fields exist
                if (this.HasFields)
                {
                    // create the return value
                    listOfFields = new List<FieldValuePair>();
                    
                    // iterate each field
                    foreach (FieldValuePair field in this.Fields)
                    {
                        // add this field
                        listOfFields.Add(field);
                    }
                }

                // return value
                return listOfFields;
            }
            #endregion
            
            #region ConvertTypesToItems(Type[] types)
            /// <summary>
            /// This method converts a list of Classes To Items
            /// </summary>
            private List<Item> ConvertTypesToItems(Type[] types)
            {
                // initial value
                List<Item> items = null;

                // locals
                Item item = null;
                
                // if there are one or more classes
                if ((types != null) && (types.Count() > 0))
                {
                    // create the return value
                    items = new List<Item>();

                    // iterate the Type objects
                    foreach (Type type in types)
                    {
                        // set the className
                        string className = type.ToString();
                        
                        // create the item
                        item = new Item(className, className);

                        // add this item
                        items.Add(item);
                    }
                }

                // return value
                return items;
            }
            #endregion

            #region CreatePropertySetter(FieldLink fieldLink, string variableName)
            /// <summary>
            /// This method returns the Property Setter
            /// </summary>
            private string CreatePropertySetter(FieldLink fieldLink, string variableName)
            {
                // initial value
                string propertySetter = "";

                // locals
                string integerSetter = "NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);";
                string doubleSetter = "NumericHelper.ParseDouble(xmlNode.FormattedNodeValue, 0, -1);";
                string dateSetter = "DateHelper.ParseDate(xmlNode.FormattedNodeValue, defaultDate, errorDate);";
                string booleanSetter = "BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);";
                string guidSetter = "Guid.Parse(xmlNode.FormattedNodeValue);";

                // if the fieldLink exists
                if (NullHelper.Exists(fieldLink))
                {
                    // if the FieldValuePair exists and teh FieldValuePair is an enumeration
                    if ((fieldLink.HasFieldValuePair) && (fieldLink.FieldValuePair.IsEnumeration) && (fieldLink.FieldValuePair.HasEnumDataTypeName))
                    {
                        // write out a comment that parses the enumeration, the only thing a user
                        // has to do to implement this is select the default value in the enum
                        string enumName = fieldLink.FieldValuePair.EnumDataTypeName;
                        propertySetter = "// Select the default value of this enum " + TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", "EnumHelper.GetEnumValue<" + fieldLink.FieldValuePair.EnumDataTypeName + ">(xmlNode.FormattedNodeValue, " + enumName + ");");
                    }
                    else
                    {
                        // if the data type exists
                        switch (fieldLink.TargetDataType)
                        {
                            case DataTypeEnum.Boolean:

                                // set the value for propertySetter
                                propertySetter = TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", booleanSetter);

                                // required
                                break;

                            case DataTypeEnum.Integer:

                                // set the value for propertySetter
                                propertySetter = TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", integerSetter);

                                // required
                                break;

                            case DataTypeEnum.Double:

                                // set the value for propertySetter
                                propertySetter = TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", doubleSetter);

                                // required
                                break;

                            case DataTypeEnum.String:

                                // set the value for propertySetter
                                propertySetter = TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", "xmlNode.FormattedNodeValue;");

                                // required
                                break;

                            case DataTypeEnum.DateTime:

                                // set the value for propertySetter
                                propertySetter = TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", dateSetter);

                                // required
                                break;

                            case DataTypeEnum.Guid:

                                // set the value for propertySetter
                                propertySetter = TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", guidSetter);

                                // required
                                break;

                            case DataTypeEnum.Enumeration:

                                // write out a comment that this data type must be parsed manually
                                propertySetter = "// " + TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", "// this field must be parsed manually.");

                                // required
                                break;

                            default:

                                // write out a comment that this data type must be parsed manually
                                propertySetter = "// " + TextHelper.CombineStrings(variableName, fieldLink.TargetFieldName, " = ", "// this field must be parsed manually.");

                                // required
                                break;
                        }
                    }
                }

                // return value
                return propertySetter;
            }
            #endregion
            
            #region CreateUsingStatements(string targetNamespace, bool isParser)
            /// <summary>
            /// This method returns the Using Statements
            /// </summary>
            private List<Reference> CreateUsingStatements(string targetNamespace, bool isParser)
            {
                // locals
                List<Reference> usingStatements = new List<Reference>();
                int referenceNumber = 0;
                
                // create each references
                Reference targetReference = new Reference(targetNamespace, referenceNumber++);
                Reference ultimateHelperReference = new Reference("DataJuggler.UltimateHelper", referenceNumber++);
                Reference systemReference = new Reference("System", referenceNumber++);
                Reference genericCollectionsReference = new Reference("System.Collections.Generic", referenceNumber++);
                Reference xmlMirrorRuntimeObjectsReference = new Reference("XmlMirror.Runtime.Objects", referenceNumber++);
                Reference xmlMirrorRuntimeUtilreference = new Reference("XmlMirror.Runtime.Util", referenceNumber++);
                Reference systemTextReference = new Reference("System.Text", referenceNumber++);

                // add each reference
                usingStatements.Add(targetReference);
                usingStatements.Add(ultimateHelperReference);
                usingStatements.Add(systemReference);
                usingStatements.Add(genericCollectionsReference);

                // if this is a parser
                if (isParser)
                {
                    // only add the reference to XmlMirror.Runtime.Objects if 
                    // the targetNamespace is not XmlMirror.Runtime.Objects
                    // (this is needed so XmlMirror can work on itself without removing the refernence manually)
                    if (!TextHelper.IsEqual(targetNamespace, xmlMirrorRuntimeObjectsReference.ReferenceName))
                    {
                        // Add the xmlMirrorRuntimeObjectsReference
                        usingStatements.Add(xmlMirrorRuntimeObjectsReference);
                    }
                
                    // Add the last reference
                    usingStatements.Add(xmlMirrorRuntimeUtilreference);
                }
                

                // if we are building a writer
                if (this.OutputType == OutputTypeEnum.Writer)
                {
                    // Add the last reference
                    usingStatements.Add(systemTextReference);
                }

                // return value
                return usingStatements;
            }
            #endregion
            
            #region DisplayFieldLink(TreeNode rootNode, FieldLink fieldLink)
            /// <summary>
            /// This method attempts to display the FieldLink given.
            /// </summary>
            private void DisplayFieldLink(TreeNode rootNode, FieldLink fieldLink)
            {
                // locals
                FieldValuePair fieldValuePair = null;
                FieldLink tempFieldLink = null;

                // if the rootNode exists
                if ((rootNode != null) && (fieldLink != null))
                {
                    // iterate the treeNode objects
                    foreach (TreeNode treeNode in rootNode.Nodes)
                    {
                        // cast the tag as a FieldLink
                        fieldValuePair = treeNode.Tag as FieldValuePair;
                        tempFieldLink = treeNode.Tag as FieldLink;

                        // if the fieldLink exists
                        if (fieldValuePair != null)
                        {
                            // if the field names match
                            if (fieldValuePair.FieldName == fieldLink.TargetFieldName)
                            {
                                // update the text
                                treeNode.Text += " :: " + fieldLink.SourceFieldName;

                                // set the FieldValuePair
                                fieldLink.FieldValuePair = fieldValuePair;

                                // change the tag to an XmlNode
                                treeNode.Tag = fieldLink;

                                // break out of the loop
                                break;
                            }
                        }
                        else if (tempFieldLink != null)
                        {
                            // if the field names match
                            if (tempFieldLink.TargetFieldName == fieldLink.TargetFieldName)
                            {
                                // update the text
                                treeNode.Text += " :: " + fieldLink.SourceFieldName;

                                // set the FieldValuePair
                                fieldLink.FieldValuePair = fieldValuePair;

                                // change the tag to an XmlNode
                                treeNode.Tag = fieldLink;

                                // break out of the loop
                                break;
                            }
                        }
                    }
                }
            }
            #endregion
            
            #region DisplayMirror(Mirror mirror)
            /// <summary>
            /// This method displays the Mirror given.
            /// </summary>
            private void DisplayMirror(Mirror mirror)
            {
                // locals
                string sourceXmlFileName = "";
                bool reflected = false;
                
                // if the mirror exists
                if (mirror != null)
                {
                    // Set the outputType
                    OutputType = mirror.OutputType;

                    // set the values
                    sourceXmlFileName = mirror.SourceXmlFilePath;

                    // set the SourceXmlFileName
                    this.SourceXmlFileTextBox.Text = sourceXmlFileName;

                    // if we are creating a parser
                    if (OutputType == OutputTypeEnum.Parser)
                    {
                        // Select the Parser Radio Button
                        this.XmlParserRadioButton.Checked = true;

                        // Click the Start button
                        this.StartButton_Click(this, null);
                    }
                    else if (OutputType == OutputTypeEnum.Writer)
                    {
                        // Select the Writer Radio Button
                        XmlWriterRadioButton.Checked = true;
                    }

                    // set the TargetDll
                    this.TargetDllTextBox.Text = mirror.TargetObjectFilePath;

                    // set the namespace
                    this.NamespaceControl.Text = mirror.Namespace;

                    // set the output folder control
                    this.OutputFolderControl.Text = mirror.OutputFolderPath;

                    // update the node names
                    this.NewObjectNodeName = mirror.NewObjectNodeName;
                    this.CollectionNodeName = mirror.CollectionNodeName;

                    // use reflection to load this object
                    reflected = ReflectDll(this.TargetDllTextBox.Text);

                    // if reflected
                    if (reflected)
                    { 
                        // now set the index for the TargetObject
                        int targetObjectIndex = FindTargetObjectIndex(mirror.TargetClassName);

                        // set the selected index
                        this.TargetClassComboBox.SelectedIndex = targetObjectIndex;

                        // now select the icons in the tree
                        string nodeText = this.CollectionNodeName;;
                        int imageIndex = 2;
                        this.SelectNodeImage(nodeText, imageIndex);
                        nodeText =  this.NewObjectNodeName;
                        imageIndex = 1;
                        this.SelectNodeImage(nodeText, imageIndex);

                        // click the view button
                        this.ViewButton_Click(this, null);

                        // if this is a Writer and we have one or more fields
                        if ((OutputType == OutputTypeEnum.Writer) && (ListHelper.HasOneOrMoreItems(mirror.Fields)))
                        {
                            // iterate the fieldValuePairs
                            foreach (FieldValuePair field in mirror.Fields)
                            {
                                // if this field should be skipped
                                if (field.Skip)
                                {
                                    // we just update the icon to the imageIndex of 3 so the Skip icon appears
                                    if (TargetTreeView.TopNode != null)
                                    {
                                        // iterate the child nodes of the top node
                                        foreach (TreeNode node in TargetTreeView.TopNode.Nodes)
                                        {  
                                            // if this is the field in question 
                                            if (node.Text == field.FieldName)
                                            {
                                                // Set the ImageIndex to 1 (skip icon)
                                                node.ImageIndex = 1;
                                                node.SelectedImageIndex = 1;
                                                node.Tag = field;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // if the mirror field links
                        if (mirror.HasOneOrMoreFieldLinks)
                        {
                            // set the rootNode
                            TreeNode rootNode = this.TargetTreeView.Nodes[0];
                        
                            // if the rootNode exists
                            if (rootNode != null)
                            {
                                // if the fieldLinks exist
                                foreach(FieldLink fieldLink in mirror.FieldLinks)
                                {
                                    // test only
                                    string sourceFieldName = fieldLink.SourceFieldName;
                                    string targetFieldName = fieldLink.TargetFieldName;

                                    // break point only
                                    DisplayFieldLink(rootNode, fieldLink);
                                }
                            }
                        }
                    }

                    // set the parserName
                    this.ClassNameControl.Text = mirror.ClassName;

                    // if in parser mode
                    if (this.OutputType == OutputTypeEnum.Parser)
                    {
                        // Replace Parser for Writer
                        this.ClassNameControl.Text = ClassNameControl.Text.Replace("Writer", "Parser");
                        this.OutputFolderControl.Text = this.OutputFolderControl.Text.Replace("Writer", "Parser");
                        this.NamespaceControl.Text = NamespaceControl.Text.Replace("Writers", "Parsers");
                    }
                    else if (this.OutputType == OutputTypeEnum.Writer)
                    {
                        // Replace Writer for Parser
                        this.ClassNameControl.Text = ClassNameControl.Text.Replace("Parser", "Writer");
                        this.OutputFolderControl.Text = OutputFolderControl.Text.Replace("Parser", "Writer");
                        this.NamespaceControl.Text = NamespaceControl.Text.Replace("Parsers", "Writers");
                    }

                    // Enable the BuildButton if all the required information is here
                    UIControl();
                }                
            }
            #endregion
            
            #region DisplayNodeAttribute(TreeNode attributesTreeNode, XmlAttribute attribute)
            /// <summary>
            /// This method displays the attributes for a node
            /// </summary>
            private void DisplayNodeAttribute(TreeNode attributesTreeNode, XmlAttribute attribute)
            {
                // locals
                string attributeText = "";
                string seperator = " = ";

                // if the attributesTreeNode exists
                if (attributesTreeNode != null)
                {
                    // if the value exists
                    if (attribute.HasAttributeValue)
                    {
                        // create the attributeText
                        attributeText = TextHelper.CombineStringsEx(attribute.AttributeName, attribute.AttributeValue, seperator);
                    }
                    else
                    {
                        // set to the AttributeName
                        attributeText = attribute.AttributeName;
                    }

                    // add the attribute text
                    attributesTreeNode.Nodes.Add(attributeText);
                }
            }
            #endregion
            
            #region DisplayObjectFields(List<FieldValuePair> fields)
            /// <summary>
            /// This method displays a list of Object Fields
            /// </summary>
            private void DisplayObjectFields(List<FieldValuePair> fields)
            {
                // locals
                string rootNodeName = "";
                TreeNode treeNode = null;

                // if there are one or more fields
                if ((ListHelper.HasOneOrMoreItems(fields)) && (this.HasSelectedClassName))
                {
                    // Clear the nodes
                    this.TargetTreeView.Nodes.Clear();

                    // set the rootNodeName
                    rootNodeName = "Class " + this.SelectedClassName;

                    // create the node
                    TreeNode rootNode = new TreeNode(rootNodeName);

                    // Add the rootNode
                    this.TargetTreeView.Nodes.Add(rootNode);

                    // iterate the fields
                    foreach (FieldValuePair field in fields)
                    {
                        // add this field
                        treeNode = rootNode.Nodes.Add(field.FieldName);

                        // if this field should be skipped
                        if (field.Skip)                          
                        {
                            // Use the skip icon
                            treeNode.ImageIndex = 1;
                            treeNode.SelectedImageIndex = 1;
                        }
                        else
                        {
                            // use blank image    
                            treeNode.ImageIndex = 0;
                            treeNode.SelectedImageIndex = 0;
                        }

                        // set the tag to be a treeNode
                        treeNode.Tag = field;
                    }

                    // Expand the RootNode
                    rootNode.Expand();
                }
            }
            #endregion
            
            #region DisplayOutputType()
            /// <summary>
            /// This method returns the Output Type
            /// </summary>
            public void DisplayOutputType()
            {
                // if we are creating a parser
                if (this.OutputType == OutputTypeEnum.Parser)
                {
                    // Change the LabelText
                    this.ClassNameControl.LabelText = "Parser Name:";

                    // Change the buton text
                    this.BuildButton.Text = "Build Parser";
                }
                else
                {
                    // Change the LabelText
                    this.ClassNameControl.LabelText = "Writer Name:";

                    // Change the buton text
                    this.BuildButton.Text = "Build Writer";
                }

                // Setup the UI
                UIControl();
            }
            #endregion
            
            #region DisplayXmlDoc(XmlDocument xmlDocument)
            /// <summary>
            /// This method displays the current Xml Doc
            /// </summary>
            private void DisplayXmlDoc(XmlDocument xmlDocument)
            {
                // clear the nodes
                this.XmlTreeView.Nodes.Clear();

                // if the xmlDocument exists
                if (xmlDocument != null)
                {
                    // set the xmlDoc
                    this.XmlDoc = xmlDocument;

                    // if the rootNode exists
                    if (xmlDocument.HasRootNode)
                    {
                        // create the node
                        TreeNode rootNode = new TreeNode(xmlDocument.RootNode.NodeText, -1, -1);

                        // set the rootXmlNode
                        XmlNode rootXmlNode = new XmlNode(xmlDocument.RootNode.NodeText, DataTypeEnum.String);

                        // set the rootNode
                        rootNode.Tag = rootXmlNode;

                        // add this parentNode
                        this.XmlTreeView.Nodes.Add(rootNode);

                        // if the RootNode has children
                        if (xmlDocument.RootNode.HasChildNodes)
                        {
                            // iterate the child nodes
                            foreach (XmlNode node in xmlDocument.RootNode.ChildNodes)
                            {
                                // Display this node
                                DisplayXmlNode(rootNode, node);
                            }
                        }

                        // Expand the rootNode
                        rootNode.Expand();
                    }
                }
            }
            #endregion
            
            #region DisplayXmlNode(TreeNode parentNode, XmlNode node)
            /// <summary>
            /// This method displays an Xml Node and all of its children (if applicable)
            /// </summary>
            private void DisplayXmlNode(TreeNode parentNode, XmlNode node)
            {
                // local
                TreeNode treeNode = null;
                string nodeText = "";
                
                // verify both objects exist
                if ((parentNode != null) && (node != null))
                {
                    // format the nodeText
                    nodeText = node.NodeText;

                    // create the rootNode
                    treeNode = new TreeNode(nodeText, -1, -1);

                    // set the node as the tag
                    treeNode.Tag = node;

                    // add this item
                    parentNode.Nodes.Add(treeNode);

                    // if this node has child nodes
                    if (node.HasOneOrMoreAttributes)
                    {
                        // add this node
                        TreeNode attributesNode = treeNode.Nodes.Add("Attributes");
                        
                        // iterate the childNodes
                        foreach (XmlAttribute attribute in node.Attributes)
                        {
                            // Add this attribute
                            DisplayNodeAttribute(attributesNode, attribute);
                        }
                    }

                    // if the node has childNodes
                    if (node.HasChildNodes)
                    {
                        // iterate the childNodes
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            // Display the XmlNode
                            DisplayXmlNode(treeNode, childNode);
                        }
                    }
                }
            }
            #endregion
            
            #region FindAssemblyType(Type[] assemblyTypes, string className)
            /// <summary>
            /// This method returns the Assembly Type for the className given.
            /// </summary>
            private Type FindAssemblyType(Type[] assemblyTypes, string className)
            {
                // initial value
                Type assemblyType = null;

                // locals
                string typeName = "";

                // if there are one or more items in the assemblyTypes collection
                if ((assemblyTypes != null) && (assemblyTypes.Count() > 0))
                {
                    // iterate the types
                    foreach (Type type in assemblyTypes)
                    {
                        // set the typeName
                        typeName = type.ToString();

                        // if this is the item we are looking for
                        if (TextHelper.IsEqual(typeName, className))
                        {
                            // set the return value
                            assemblyType = type;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return assemblyType;
            }
            #endregion

            #region FindFieldLinkIndex(string targetFieldName)
            /// <summary>
            /// This method returns the Field Link Index
            /// </summary>
            private int FindFieldLinkIndex(string targetFieldName)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                 // if the Mirror.FieldLinks exists
                 if ((this.HasSelectedMirror) && (this.SelectedMirror.HasFieldLinks))
                 {
                    // Iterate the items in the collection
                    foreach (FieldLink fieldLink in this.SelectedMirror.FieldLinks)
                    {
                        // increment tempIndex
                        tempIndex++;
                        
                        // if this is the item being sought
                        if (fieldLink.TargetFieldName == targetFieldName)
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of loop
                            break;
                        }
                    }
                }

                // return value
                return index;
            }
            #endregion
            
            #region FindTargetDataType(string targetFieldName)
            /// <summary>
            /// This method returns the Target Data Type for the TargetFieldName
            /// </summary>
            private DataTypeEnum FindTargetDataType(string targetFieldName)
            {
                // initial value
                DataTypeEnum targetDataType = DataTypeEnum.NotSupported;

                // if the targetFieldName exists
                if (TextHelper.Exists(targetFieldName))
                {
                    // if the fields collection exists
                    if (this.HasFields)
                    {
                        // Iterate the items in the collection
                        foreach (FieldValuePair fieldValuePair in this.Fields)
                        {
                            // if this is the field being sought
                            if (fieldValuePair.FieldName == targetFieldName)
                            {
                                // set the return value
                                targetDataType = fieldValuePair.FieldDataType;

                                // break out of this loop
                                break;
                            }
                        }
                    }
                }

                // return value
                return targetDataType;
             }
            #endregion

            #region FindTargetNode(string nodeText)
            /// <summary>
            /// This method returns the Target Node
            /// </summary>
            public TreeNode FindTargetNode(string nodeText)
            {
                // initial value
                TreeNode targetNode = null;

                // If the nodeText string exists
                if ((TextHelper.Exists(nodeText)) && (this.TargetTreeView.TopNode != null))
                {
                    // iterate the child nodes of the top node
                    foreach (TreeNode childNode in this.TargetTreeView.TopNode.Nodes)
                    {
                        // if the nodeText
                        if (TextHelper.IsEqual(childNode.Text, nodeText))
                        {
                            // set the return value
                            targetNode = childNode;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return targetNode;
            }
            #endregion
            
            #region GetFields(bool skipReadOnlyProperties = false)
            /// <summary>
            /// This method returns a list of Fields
            /// </summary>
            public List<FieldValuePair> GetFields(bool skipReadOnlyProperties = false)
            {
                // initial value
                List<FieldValuePair> fields = null;

                try
                {
                    // is this object valid
                    bool isValid = ValidateTargetInfo();
                    
                    // if this is valid
                    if (isValid)
                    {
                        // get the fileName
                        string fileName = this.TargetDllTextBox.Text;

                        // if the fileName exists
                        if (TextHelper.Exists(fileName))
                        {
                            // load the assembly
                            Assembly assembly = Assembly.LoadFrom(this.SelectedAssemblyName);

                            // if the assembly exists
                            if (assembly != null)
                            {
                                // set the objectName
                                string className = this.SelectedClassName;

                                // load the assembly types
                                Type[] assemblyTypes = assembly.GetTypes();

                                // set the objectType
                                Type objectType = FindAssemblyType(assemblyTypes, className);
                            
                                // if the objectType exists
                                if (objectType != null)
                                {
                                    // load the field value pairs for this object
                                    fields = ReflectionHelper.GetPropertyAttributes(objectType, skipReadOnlyProperties);
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    ReflectionTypeLoadException reflectionError = error as ReflectionTypeLoadException;

                    // for debugging only
                    string err = error.ToString();

                    // locals
                    string message = "An error occured using reflection to view the selected object.";
                    string title = "Error";

                    // show a message to the user
                    MessageBoxHelper.ShowMessage(message, title);
                }
                
                // return value
                return fields;
            }
            #endregion
            
            #region GetMirrorName(string className, string parserName)
            /// <summary>
            /// This method returns the Mirror Name
            /// </summary>
            private string GetMirrorName(string className, string parserName)
            {
                // initial value
                string mirrorName = "";

                // if the className and parserName exists
                if (TextHelper.Exists(className, parserName))
                {
                    // set the index
                    int index = className.LastIndexOf(".");

                    // if the index exists
                    if (index >= 0)
                    {
                        // set the rootClass
                        string rootClass = className.Substring(0, index);

                        // set the mirrorNameToDelete
                        mirrorName = rootClass + "." + parserName;
                    }
                }

                // return value
                return mirrorName;
            }
            #endregion

            #region GetWordDocumentPath(DocumentType documentType)
            /// <summary>
            /// This method returns the path to the Word document.
            /// </summary>
            /// <returns></returns>
            public string GetHelpDocumentPath(DocumentType documentType)
            {
                // initial value
                string helpDocumentPath = "";

                try
                {
                    // Create the directory
                    DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory);

                    // Get the parent directory
                    DirectoryInfo parentDebugFolder = directory.Parent;

                    // Get the xmlMirrorFolder
                    DirectoryInfo xmlMirrorFolder = parentDebugFolder.Parent;

                    // Get the documentsFolder
                    string documentsFolder = Path.Combine(xmlMirrorFolder.FullName, "Documents");

                    // if Word
                    if (documentType == DocumentType.Word)
                    {
                        // set the return value
                        helpDocumentPath = Path.Combine(documentsFolder, "XML Mirror User's Guide.docx");
                    }
                    else
                    {
                        // set the return value
                        helpDocumentPath = Path.Combine(documentsFolder, "XML Mirror User's Guide.pdf");
                    }
                }
                catch (Exception error)
                {
                    // Write to the output window
                    DebugHelper.WriteDebugError("GetWordDocumentPath", "MainForm", error);
                }
                
                // return value
                return helpDocumentPath;
            }
            #endregion
            
            #region HandleNodeAssignment(TreeNode sourceNode)
            /// <summary>
            /// This method Handle Node Assignment
            /// </summary>
            public void HandleNodeAssignment(TreeNode sourceNode)
            {
                // if the sourceNode object exists
                if (NullHelper.Exists(sourceNode))
                {   
                    // Attempt to find the TargetNode
                    TreeNode targetNode = FindTargetNode(sourceNode.Text);

                    // If the targetNode object exists
                    if (NullHelper.Exists(targetNode))
                    {
                        // set the xmlNode
                        XmlNode xmlNode = sourceNode.Tag as XmlNode;

                        // if the xmlNode exists
                        if (xmlNode != null)
                        {
                            // Assign the xmlNode to the targetNode
                            AssignNode(xmlNode, targetNode);
                        }
                        else
                        {
                            // update the text
                            targetNode.Text += " :: " + sourceNode.Text;

                            // Expand the node at the location 
                            // to show the dropped node.
                            targetNode.Expand();
                        }
                    }
                }
            }
            #endregion
            
            #region HandleNodeAssignment(TreeNode sourceNode, TreeNode targetNode)
            /// <summary>
            /// This method Handle Node Assignment
            /// </summary>
            public void HandleNodeAssignment(TreeNode sourceNode, TreeNode targetNode)
            {
                // if the sourceNode and targetNode objects both exist
                if (NullHelper.Exists(sourceNode, targetNode))
                {
                    // set the xmlNode
                    XmlNode xmlNode = sourceNode.Tag as XmlNode;

                    // if the xmlNode exists
                    if (xmlNode != null)
                    {
                        // Assign the xmlNode to the targetNode
                        AssignNode(xmlNode, targetNode);
                    }
                    else
                    {
                        // update the text
                        targetNode.Text += " :: " + sourceNode.Text;

                        // Expand the node at the location 
                        // to show the dropped node.
                        targetNode.Expand();
                    }
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Open to ParserMode unless the user changes it or a mirror is opened for WriterMode
                OutputType = OutputTypeEnum.Parser;

                // Setup the ComboBox listener
                this.TargetClassComboBox.SelectedIndexListener = this;

                // Create the FieldLinks
                this.FieldLinks = new List<FieldLink>();

                // Setup the events
                this.TargetTreeView.DragEnter += new DragEventHandler(TargetTreeView_DragEnter);
                this.TargetTreeView.DragOver += new DragEventHandler(TargetTreeView_DragOver);
                this.TargetTreeView.DragDrop += new DragEventHandler(TargetTreeView_DragDrop);

                // Ensure the widths for the menu, the designer sometimes resets this value
                this.HelpMenuItem.Width = 100;

                // Control the UI
                UIControl();
            }
            #endregion
            
            #region LoadFieldLinks()
            /// <summary>
            /// This method returns a list of Field Links
            /// </summary>
            private List<FieldLink> LoadFieldLinks()
            {
                // initial value
                List<FieldLink> fieldLinks = new List<FieldLink>();

                // for debugging only
                string nodeText = "";
                string derivedFieldName = "";
                int seperatorIndex = 0;

                // if there is at least one node in the Tree
                if (this.TargetTreeView.Nodes.Count > 0)
                {
                    // get the roodeNode
                    TreeNode rootNode = this.TargetTreeView.Nodes[0];

                    // the tag will be a fieldLink if the field was load and displayed
                    FieldLink fieldLink = null;
                    
                    // a newly dragged field link will be an xmlNode
                    XmlNode xmlNode = null;

                    // if the nodes c
                    if ((rootNode != null) && (rootNode.Nodes != null))
                    {
                        // iterate the nodes
                        foreach (TreeNode treeNode in rootNode.Nodes)
                        {
                            // reset
                            derivedFieldName = "";

                            // for debugging only
                            nodeText = treeNode.Text;

                            // get the seperatorIndex
                            seperatorIndex = nodeText.IndexOf("::");

                            // if the seperatorIndex is set
                            if (seperatorIndex > 0)
                            {
                                // set the derivedFieldName
                                derivedFieldName = nodeText.Substring(0, seperatorIndex - 1).Trim();
                            }

                            // cast the treeNode.Tag as an xmlNode and a FieldLink (could be either)
                            fieldLink = treeNode.Tag as FieldLink;
                            xmlNode = treeNode.Tag as XmlNode;

                            // if all of the required information is present
                            if ((fieldLink != null) && (fieldLink.HasSourceFieldName) && (fieldLink.HasTargetFieldName))
                            {
                                // add this fieldLink
                                fieldLinks.Add(fieldLink);
                            }
                            else if ((xmlNode != null) && (xmlNode.HasSourceFieldName) && (xmlNode.HasTargetFieldName))
                            {
                                // this is a fix to a bug that causes the TargetFieldName to be reset for all FieldLinks
                                // when the SourceFieldName is shared by two or more fields.
                                // Would prefer to fix the problem in the first place, but in the mean time this is a hack.
                                if (TextHelper.Exists(derivedFieldName))
                                {
                                    // if the TargetFieldName exists
                                    if (xmlNode.TargetFieldName != derivedFieldName)
                                    {
                                        // reset the TargetFieldName
                                        xmlNode.TargetFieldName = derivedFieldName;
                                    }
                                }
                                
                                // update: We must find the data type for the TargetFieldName
                                DataTypeEnum fieldDataType = FindTargetDataType(xmlNode.TargetFieldName);

                                // create the FieldLink
                                fieldLink = new FieldLink(xmlNode.SourceFieldName, xmlNode.TargetFieldName, fieldDataType);

                                // add this fieldLink
                                fieldLinks.Add(fieldLink);
                            }
                        }
                    }
                }

                // return value
                return fieldLinks;
            }
            #endregion
            
            #region MapFields(List<FieldLink> fieldLinks)
            /// <summary>
            /// This method returns a list of FieldMap objects to address the problem of
            /// duplicate fields being mapped to the same source field name.
            /// </summary>
            private List<FieldMap> MapFields(List<FieldLink> fieldLinks)
            {
                // initial value
                List<FieldMap> mappFields = null;

                // locals
                string lastFieldName = "";
                FieldMap fieldMap = null;

                // sort the fieldLinks by SourceFieldName
                List<FieldLink> sortedFieldLinks = SortBySourceFieldName(fieldLinks);

                // if there are one or more items in the sortedFieldLinks collection
                if (ListHelper.HasOneOrMoreItems(sortedFieldLinks))
                {
                    // create the return value
                    mappFields = new List<FieldMap>();
                    
                    // iterate the sorted FieldLink objects
                    foreach (FieldLink fieldLink in sortedFieldLinks)
                    {
                        // if this is a new field (if the the lastFieldName is different the sourceFieldName
                        if (!TextHelper.IsEqual(lastFieldName, fieldLink.SourceFieldName))
                        {
                            // this is a new source field, create a FieldMap object
                            fieldMap = new FieldMap(fieldLink.SourceFieldName);
                            
                            // add this field to the return collection
                            mappFields.Add(fieldMap);
                        }

                        // if the FieldMap exists
                        if ((fieldMap != null) && (fieldMap.HasFieldLinks))
                        {
                            // add this item
                            fieldMap.FieldLinks.Add(fieldLink);
                        }

                        // set the lastFieldName
                        lastFieldName = fieldLink.SourceFieldName;
                    }
                }

                // return value
                return mappFields;
            }
            #endregion
            
            #region ReflectDll(string dllFilePath)
            /// <summary>
            /// This method returns the Dll
            /// </summary>
            private bool ReflectDll(string dllFilePath)
            {
                // initial value
                bool reflected = false;

                try
                {
                    // if the FileName exists
                    if ((TextHelper.Exists(dllFilePath)) && (dllFilePath.Length >= 5))
                    {
                        // if the dllFilePath exists
                        if (File.Exists(dllFilePath))
                        { 
                            // set the TargetObjectFilePath
                            this.TargetObjectFilePath = dllFilePath;

                            // load the assembly
                            Assembly assembly = Assembly.LoadFrom(dllFilePath);
                            
                            // get the classes
                            Type[] types = assembly.GetTypes();

                            // convert the modules to items
                            List<Item> items = ConvertTypesToItems(types);

                            // load the items
                            this.TargetClassComboBox.LoadItems(items);

                            // set to true
                            reflected = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    if (error is System.Reflection.ReflectionTypeLoadException)
                    {
                        var typeLoadException = error as ReflectionTypeLoadException;
                        var loaderExceptions  = typeLoadException.LoaderExceptions;
                    }


                    // not reflected (already set, just explicit)
                    reflected = false;

                    // for debugging only
                    string err = error.ToString();

                    // Show the message
                    MessageBoxHelper.ShowMessage("An error occurred reflecting the selected object." + Environment.NewLine + "Details: " + Environment.NewLine + err, "Reflection Error");
                }

                // return value
                return reflected;
            }
            #endregion
            
            #region SaveMirror(Mirror mirror)
            /// <summary>
            /// This method saves the Mirror object given to xml in the \Mirror folder.
            /// </summary>
            private bool SaveMirror(Mirror mirror)
            {
                // initial value
                bool saved = false;

                try
                {
                    // if the mirror exists
                    if (mirror != null)
                    {
                        // for debugging only
                        string mirrorName = mirror.Name;

                        // create a new SaveMirrorForm
                        SaveMirrorForm saveMirrorForm = new SaveMirrorForm();

                        // set the Mirror
                        saveMirrorForm.Mirror = mirror;

                        // show the form
                        saveMirrorForm.ShowDialog();

                        // Set to true
                        saved = true;
                    }
                }
                catch (Exception error)
                {
                    // save the message
                    MessageBox.Show("An error occurred saving the message.", "Save Failed");

                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return saved;
            }
            #endregion

            #region SelectNodeImage(TreeNodeCollection treeNodes, string nodeText, int imageIndex)
            /// <summary>
            /// This method sets the image index for the TreeNodeCollection given.
            /// </summary>
            private void SelectNodeImage(TreeNodeCollection treeNodes, string nodeText, int imageIndex)
            {
                // locals
                XmlNode node = null;
                string fullName = "";

                // if the treeNodes exists
                if (treeNodes != null)
                {
                    // iterate the treeNodes
                    foreach (TreeNode treeNode in treeNodes)
                    { 
                        // cast the tag for this node 
                        node = treeNode.Tag as XmlNode;

                        // if the node exists
                        if (node != null)
                        {
                            // set the fullName
                            fullName = node.GetFullName();
                        }

                        // if this is the item being sought
                        if (TextHelper.IsEqual(fullName, nodeText))
                        {
                            // set the image index
                            treeNode.ImageIndex = imageIndex;
                            treeNode.SelectedImageIndex = imageIndex;
                        }

                        // if there are one or more child nodes
                        if ((treeNode.Nodes != null) && (treeNode.Nodes.Count > 0))
                        {
                            // call the children
                            SelectNodeImage(treeNode.Nodes, nodeText, imageIndex);
                        }
                    }
                }
            }
            #endregion
            
            #region SelectNodeImage(string nodeText, int imageIndex)
            /// <summary>
            /// This method sets the Image index for the nodeText and the imageIndex given.
            /// </summary>
            private void SelectNodeImage(string nodeText, int imageIndex)
            {
                // locals
                bool abort = false;
                string fullName = "";
                XmlNode node = null;
                
                // verify there is at least one node
                if ((this.XmlTreeView.Nodes != null) && (this.XmlTreeView.Nodes.Count > 0))
                {
                    // get a reference to the rootNode
                    TreeNode rootNode = this.XmlTreeView.Nodes[0];

                    // get the node
                    node = rootNode.Tag as XmlNode;

                    // if the node exists
                    if (node != null)
                    {
                        // get the fullName for this node
                        fullName = node.GetFullName();
                    }

                    // if this is the item that must match
                    if (TextHelper.IsEqual(fullName, nodeText))
                    {
                        // set the image and selected image index
                        rootNode.ImageIndex = imageIndex;
                        rootNode.SelectedImageIndex = imageIndex;                      
                    }

                    // if we should not abort
                    if (!abort)
                    {
                        // if there are childNodes
                        if (rootNode.Nodes != null)
                        {   
                            // select the node image
                            SelectNodeImage(rootNode.Nodes, nodeText, imageIndex);
                        }
                    }
                }
            }
            #endregion
            
            #region SortBySourceFieldName(List<FieldLink> fieldLinks)
            /// <summary>
            /// This method returns a list of FieldLink objects sourted by SourceFieldName
            /// </summary>
            private List<FieldLink> SortBySourceFieldName(List<FieldLink> fieldLinks)
            {
                // initial value
                List<FieldLink> sortedFieldInks = null;

                // locals
                FieldLink fieldLink = null;
                
                // first step is convert to a List<T>
                List<FieldLink> unSortedList = (List<FieldLink>)ListHelper.ConvertToListOf<FieldLink>(fieldLinks);

                // if there are one or more items in the collection
                if (ListHelper.HasOneOrMoreItems(unSortedList))
                {
                    // sort the list by SourceFieldName
                    var tempSorted = (from m in unSortedList orderby m.SourceFieldName select m);

                    // if the tempSorted exists
                    if ((tempSorted != null) && (tempSorted.Count() > 0))
                    {
                        // Create the return collection
                        sortedFieldInks = new List<FieldLink>();
                        
                        // itereate the var items
                        foreach (var item in tempSorted)
                        {
                            // cast the item as a fieldLink
                            fieldLink = item as FieldLink;

                            // if the fieldLink exists
                            if (fieldLink != null)
                            {
                                // add this item to the return value
                                sortedFieldInks.Add(fieldLink);
                            }
                        }           
                    }
                }

                // return value
                return sortedFieldInks;
            }
            #endregion
            
            #region SortFields()
            /// <summary>
            /// This method Sort Fields
            /// </summary>
            private void SortFields()
            {
                // if the Fields collection exists
                if (this.HasFields)
                {
                    // convert the 
                    List<FieldValuePair> listOfFields = ConvertFields();

                    // sort the fields alphabetically
                    var fields = (from f in listOfFields orderby f.FieldName select f);

                    // if the fields exist
                    if (fields != null)
                    {
                        // Create the fields collection
                        this.Fields = new List<FieldValuePair>();

                        // iterate the fields
                        foreach (FieldValuePair field in fields)
                        {
                            // add this field
                            this.Fields.Add(field);
                        }
                    }
                }
            }
        #endregion

            #region UIControl()
            /// <summary>
            /// This method UI Control
            /// </summary>
            public void UIControl()
            {
                // Determine if the controls should be shown or hidden
                bool show = (this.OutputType == OutputTypeEnum.Parser);

                // Show or hide any controls
                SourceXmlFileTextBox.Visible = show;
                StartButton.Visible = show;
                XmlTreeView.Visible = show;
                F2Image.Visible = show;
                F2Label.Visible = show;
                F2DetailLabel.Visible = show;
                F1Image.Visible = show;
                F1Label.Visible = show;
                F1DetailLabel.Visible = show;
                CollectionInfoLabel.Visible = show;
                BrowseButton.Visible = show;
                WriterInfoImage.Visible = !show;

                // if the OutputType is Parser and there are one or moe Fields and the NewObjectNodeName is set and the NewFieldName is set and the TargetTreeView has nodes and the XmlTreeView has nodes
                if ((show) && (ListHelper.HasOneOrMoreItems(Fields)) && (HasNewObjectNodeName) && (HasNewFieldName) && (TargetTreeView.Nodes.Count > 0) && (XmlTreeView.Nodes.Count > 0))
                {
                    // Show the AutoFillButton
                    AutoFillButton.Visible = true;
                }
                else
                {
                    // Show the AutoFillButton
                    AutoFillButton.Visible = false;
                }

                // the BuildButton is only enabled if there are FieldLinks for Parsers or Fields for Writers
                bool enable = false;

                // if we are in Parser Mode
                if ((this.OutputType == OutputTypeEnum.Parser) && (this.HasNewObjectNodeName) && (this.HasNewFieldName))
                {
                    // if there are one or more field links
                    if ((this.HasSelectedMirror) && (this.SelectedMirror.HasOneOrMoreFieldLinks))
                    {
                        // Set enable to true
                        enable = true;
                    }
                }
                else
                {
                    // Writer Moder
                    if (ListHelper.HasOneOrMoreItems(Fields))
                    {
                        // enable the BuildButton
                        enable = true;    
                    }
                }

                // if the BuildButton should be enabled
                if (enable)
                {
                    // Show the enabled image
                    BuildButton.Enabled = true;
                    BuildButton.BackgroundImage = Properties.Resources.DarkBlueButton;
                    BuildButton.ForeColor = Color.White;
                }
                else
                {
                    // Show the disabled image
                    BuildButton.Enabled = false;
                    BuildButton.BackgroundImage = Properties.Resources.DarkButton;
                    BuildButton.ForeColor = Color.DarkGray;
                }
            }
            #endregion
            
            #region ValidateTargetInfo(bool requireOutput = false)
            /// <summary>
            /// This method validates the Target Info before the TreeNode can be loaded.
            /// </summary>
            private bool ValidateTargetInfo(bool requireOutput = false)
            {
                // initial value
                bool valid = false;

                // locals
                string message = "";
                string title = "Validation Failed";

                // valid if we have an assembly and class
                valid = ((this.HasSelectedAssemblyName) && (this.HasSelectedClassName));

                // if requireOutput the names 
                if ((requireOutput) && (valid))
                {
                    // here we valid the ParserName and OutputFolder
                    valid = ((this.HasClassName) && (this.HasOutputFolder));
                }

                // if not valid
                if (!valid)
                {
                    // if there is not a selected assembly name
                    if (!this.HasSelectedAssemblyName)
                    {
                        // set the message
                        message = "You must select an assembly (.dll) to continue.";
                    }
                    else if (!this.HasSelectedClassName)
                    {
                        // You must select a class name
                        message = "You must select a 'Target Class'.";
                    }
                    else if (requireOutput)
                    {
                        // if we do not have a ParserName
                        if (!this.HasClassName)
                        {
                            // if we are creating a parser
                            if (this.OutputType == OutputTypeEnum.Parser)
                            {
                                // You must select a class name
                                message = "You must enter the 'Parser Name'.";
                            }
                            else
                            {
                                // You must select a class name
                                message = "You must enter the 'Writer Name'.";
                            }
                        }
                        else if (!this.HasOutputFolder)
                        {
                            // You must select a class name
                            message = "You must select an output folder.";
                        }
                    }

                    // Show a message to the user
                    MessageBoxHelper.ShowMessage(message, title);
                }

                // return value
                return valid;
            }
            #endregion

            #region WriteExportListMethod(ObjectLoaderWriter writer, string className, string writerName)
            /// <summary>
            /// This method Write Export List Method
            /// </summary>
            public void WriteExportListMethod(ObjectLoaderWriter writer, string className, string writerName)
            {
                // locals
                string variableName = CSharpClassWriter.CapitalizeFirstCharEx(writerName, true).Replace("Writer", "");
                string xmlVariableName = variableName + "Xml";
                string instanceName = CSharpClassWriter.CapitalizeFirstCharEx(className, true);
                string regionDeclarationLine = "ExportList(List<" + className + "> " + variableName + ", int indent = 0)";
                string methodSummary = "This method is used to export a list of '" + className + "' objects to xml";
                string methodDeclarationLine = "public static string ExportList" + "(List<" + className + "> " + variableName + ", int indent = 0)";
                string ifHasOneOrMoreItems = "if ((" + variableName + " != null) && (" + variableName + ".Count > 0))";
                string stringBuilderComment = "Create a new instance of a StringBuilder object";
                string createStringBuilder = "StringBuilder sb = new StringBuilder();";
                string pluralClassName = writerName.Replace("Writer", "");
                string topLevelNode = "sb.Append(\"<" + pluralClassName + ">\");" + Environment.NewLine;
                string closeTopLevelNode = "sb.Append(\"</" + pluralClassName + ">\");" + Environment.NewLine;
                string foreachObject = "foreach (" + className + " " + instanceName + " " + " in " + variableName + ")";
                string newLine = "sb.Append(Environment.NewLine);";
                
                // if the writer exists and the class name and plural class name exist
                if ((NullHelper.Exists(writer)) && (TextHelper.Exists(className, writerName)))
                {
                    // if the fields exist
                    if (ListHelper.HasOneOrMoreItems(this.Fields))
                    {
                        // Right out the method
                        writer.BeginRegion(regionDeclarationLine);
                        writer.WriteComment("<Summary>");
                        writer.WriteComment(methodSummary);
                        writer.WriteComment("</Summary>");
                        writer.WriteLine(methodDeclarationLine);
                        writer.WriteOpenBracket(true);
                        writer.WriteComment("initial value");
                        writer.WriteLine("string xml = \"\";");
                        writer.WriteLine();

                        // write out a comment for the word locals
                        writer.WriteComment("locals");
                        writer.WriteLine("string " + xmlVariableName + " = String.Empty;");
                        writer.WriteLine("string indentString = TextHelper.Indent(indent);");
                        
                        // write a blank line
                        writer.WriteLine();

                         // Create a string builder
                        writer.WriteComment(stringBuilderComment);
                        writer.WriteLine(createStringBuilder);

                        // Write blank line
                        writer.WriteLine();

                        // Write command for and write append the indentString
                        writer.WriteComment("Add the indentString");
                        writer.WriteLine("sb.Append(indentString);");

                        // Write blank line
                        writer.WriteLine();

                        // Write the Favorites Node
                        writer.WriteComment("Add the open " + className + " Node");
                        writer.WriteLine(topLevelNode);
                        
                        // Write a comment
                        writer.WriteComment("Add a new line");
                        writer.WriteLine(newLine);
                        
                        // write a blank line
                        writer.WriteLine();
                        
                        // write a line to test if we have one or more objects
                        writer.WriteComment("If there are one or more " + className + " objects");
                        writer.WriteLine(ifHasOneOrMoreItems);
                        writer.WriteOpenBracket(true);
                       
                        // Write a comment about iterating the collection
                        writer.WriteComment("Iterate the " + variableName + " collection");
                        writer.WriteLine(foreachObject);

                        // Write the open bracket
                        writer.WriteOpenBracket(true);

                        // Write the code for exporting a single instance
                        writer.WriteComment("Get the xml for this " + variableName);
                        writer.WriteLine(xmlVariableName + " = Export" + className + "(" + instanceName + ", indent + 2);");

                        // Write a blank line
                        writer.WriteLine();

                        // Write a comment
                        writer.WriteComment("If the " + xmlVariableName + " string exists");
                        writer.WriteLine("if (TextHelper.Exists(" + xmlVariableName + "))");

                        // Write an open bracked and increase the indent
                        writer.WriteOpenBracket(true);

                        // Write a comment
                        writer.WriteComment("Add this " + variableName + " to the xml");
                        writer.WriteLine("sb.Append(" + xmlVariableName + ");");

                        // Write a closeBracket and decrease the indent
                        writer.WriteCloseBracket(true);
                       
                        // Write the close bracket
                        writer.WriteCloseBracket(true);

                        // Write the close bracket
                        writer.WriteCloseBracket(true);

                        // write a blank line
                        writer.WriteLine();
                        
                        // Add the closing node
                        writer.WriteComment("Add the close " + writerName + " Node");
                        writer.WriteLine("sb.Append(indentString);");
                        writer.WriteLine(closeTopLevelNode);
                        
                        // Write out the Set the return value comment
                        writer.WriteComment("Set the return value");
                        writer.WriteLine("xml = sb.ToString();");
                        
                        // write a blank line
                        writer.WriteLine();

                        // Write the comment for the return value and the return value
                        writer.WriteComment("return value");
                        writer.WriteLine("return xml;");
                        writer.WriteCloseBracket(true);
                        writer.EndRegion();

                        // Write a blank line
                        writer.WriteLine();
                    }
                }
            }
            #endregion
            
            #region WriteExportObjectMethod(ObjectLoaderWriter writer, string className)
            /// <summary>
            /// This method Write Export Object Method
            /// </summary>
            public void WriteExportObjectMethod(ObjectLoaderWriter writer, string className)
            {
                // verify the writer and the className both exist
                if ((NullHelper.Exists(writer)) && (TextHelper.Exists(className)))
                {
                    // Get the variableName
                    string variableName = CSharpClassWriter.CapitalizeFirstCharEx(className, true);
                    string xmlVariableName = variableName + "Xml";
                    string openNode = "<" + className + ">";
                    string closeNode = "</" + className + ">";

                    // set the regionName
                    string regionName = "Export" + className + "(" + className + " " + variableName + ", int indent = 0)";

                    // set the methodDeclaration
                    string methodDeclaration = "public static string " + regionName;

                    // Write the region
                    writer.BeginRegion(regionName);

                    // write the open summary tag
                    writer.WriteComment("<Summary>");

                    // Write out a comment
                    writer.WriteComment("This method is used to export a " + className + " object to xml.");
                    
                    // Write the close summary
                    writer.WriteComment("</Summary>");

                    // Write a line
                    writer.WriteLine(methodDeclaration);

                    // Write an open bracket
                    writer.WriteOpenBracket(true);

                    // Write a comment for the initial value
                    writer.WriteComment("initial value");

                    // get the initial value line
                    string initialValue = "string " + xmlVariableName + " = \"\";";

                    // Write the initial value line
                    writer.WriteLine(initialValue);

                    // Write a blank line
                    writer.WriteLine();

                    // Write a comment for local and a variable to hold the indentString
                    writer.WriteComment("locals");
                    writer.WriteLine("string indentString = TextHelper.Indent(indent);");
                    writer.WriteLine("string indentString2 = TextHelper.Indent(indent + 2);");

                    // Write a blank line
                    writer.WriteLine();

                    // Write out the test for if the instance object exists
                    writer.WriteComment("If the " + variableName + " object exists");
                    writer.WriteLine("if (NullHelper.Exists(" + variableName + "))");

                    // Write an open bracket
                    writer.WriteOpenBracket(true);

                    // Write the comment for and create a StringBuilder
                    writer.WriteComment("Create a StringBuilder");
                    writer.WriteLine("StringBuilder sb = new StringBuilder();");

                    // Write a blank line
                    writer.WriteLine();

                    // Write a comment and add the IndentString
                    writer.WriteComment("Append the indentString");
                    writer.WriteLine("sb.Append(indentString);");

                    // write a blank line
                    writer.WriteLine();
                    
                    // Write out the openNode
                    writer.WriteComment("Write the open " + variableName + " node");
                    writer.WriteLine("sb.Append(\"" + openNode + "\" + Environment.NewLine);");
                    
                    // write a blank line
                    writer.WriteLine();
                    
                    // Write a comment for each property
                    writer.WriteComment("Write out each property");

                    // Write a blank line
                    writer.WriteLine();
                    
                    // iterate the fields
                    foreach (FieldValuePair field in this.Fields)
                    {
                        // Only write fields that are not skipped
                        if (!field.Skip)
                        {
                            // Write a comment
                            writer.WriteComment("Write out the value for " + field.FieldName);
                        
                            // write a blank line
                            writer.WriteLine();

                            // If the field is a generic list
                            if (field.FieldDataType == DataTypeEnum.GenericList)
                            {
                                // Generic Lists have to be handled differently

                                // Get the collection data type
                                string collectionDataType = field.FieldDataTypeString.Substring(field.FieldDataTypeString.LastIndexOf(".")).Replace("]", "").Replace(".", "");

                                // locals
                                string writerName = field.FieldName + "Writer";
                                string writerVariableName = CSharpClassWriter.CapitalizeFirstCharEx(writerName, true);
                                string fieldXmlVariable = CSharpClassWriter.CapitalizeFirstCharEx(collectionDataType, true) + "Xml";
                            
                                // Now create the writer
                                writer.WriteComment("Create the " + writerName);
                                writer.WriteLine(writerName + " " + writerVariableName + " = new " + writerName + "();");

                                // Write a blank line
                                writer.WriteLine();

                                // Write a line to get the xml
                                string pluralFieldName = PluralWordHelper.GetPlural(field.FieldName, TextCaseOptionsEnum.Upper_Case_First_Char);
                                writer.WriteComment("Export the " + pluralFieldName + " collection to xml");
                                writer.WriteLine("string " + fieldXmlVariable + " = " + writerVariableName + ".ExportList(" + variableName + "." + field.FieldName + ", indent + 2);");
                            
                                // Write a line to add this collection 
                                writer.WriteLine("sb.Append(" + fieldXmlVariable + ");");
                                writer.WriteLine("sb.Append(Environment.NewLine);");
                            }
                            else
                            {
                                // Write out this property
                                writer.WriteLine("sb.Append(indentString2);");
                            
                                // This line contains the value for this field
                                string fieldValueLine = "\"<" +  field.FieldName + ">\" + " + variableName + "." + field.FieldName + " + " + "\"</" + field.FieldName + ">\" + Environment.NewLine";
                                writer.WriteLine("sb.Append(" + fieldValueLine + ");");
                            }

                            // Write a blank line
                            writer.WriteLine();
                        }
                    }

                    // Write a comment and add the IndentString
                    writer.WriteComment("Append the indentString");
                    writer.WriteLine("sb.Append(indentString);");

                    // write a blank line
                    writer.WriteLine();
                    
                    // Write out the closeNode
                    writer.WriteComment("Write out the close " + variableName + " node");
                    writer.WriteLine("sb.Append(\"" + closeNode + "\" + Environment.NewLine);");

                    // Write a blank line
                    writer.WriteLine();

                    // Write a comment for set the return value
                    writer.WriteComment("set the return value");
                    writer.WriteLine(xmlVariableName + " = sb.ToString();");
                    
                    // Write a close bracket
                    writer.WriteCloseBracket(true);

                    // Write a comment for the return value
                    writer.WriteComment("return value");

                    // Write the return value
                    writer.WriteLine("return " + xmlVariableName + ";");

                    // Write an close bracket
                    writer.WriteCloseBracket(true);

                    // Write the end of the region
                    writer.EndRegion();
                }
            }
            #endregion
            
            #region WriteFieldMap(ObjectLoaderWriter writer, string variableName, FieldMap fieldMap)
            /// <summary>
            /// This method writes out the mapping for the FieldMap given.
            /// </summary>
            private void WriteFieldMap(ObjectLoaderWriter writer, string variableName, FieldMap fieldMap)
            {
                // locals
                string propertySetter = "";
                
                // if the writer exists and the variableName exists and the fieldMap exists
                if ((writer != null) && (TextHelper.Exists(variableName)) && (fieldMap != null))
                {
                    // create a line for the case statement
                    string caseLine = "case \"" + fieldMap.SourceFieldName + "\":";

                    // write out the case line
                    writer.WriteLine(caseLine);

                    // add the period to variableName
                    variableName = TextHelper.CombineStrings(variableName, ".");

                    // if the fieldMap has one or more items
                    if (ListHelper.HasOneOrMoreItems(fieldMap.FieldLinks))
                    {
                        // increase the indent
                        writer.Indent++;

                        // iterate the FieldLink objects
                        foreach (FieldLink fieldLink in fieldMap.FieldLinks)
                        {
                            // create the propertySetter
                            propertySetter = CreatePropertySetter(fieldLink, variableName);
                            
                            // if the propertySetter text exists
                            if (TextHelper.Exists(propertySetter))
                            {
                                // write out a blank line
                                writer.WriteLine();

                                // set the TargetFieldName
                                writer.WriteComment("Set the value for " + variableName + fieldLink.TargetFieldName);

                                // write out the propertySetter
                                writer.WriteLine(propertySetter);
                            }
                        }

                        // write a blank line
                        writer.WriteLine();

                        // write a comment required
                        writer.WriteComment("required");

                        // write the word break
                        writer.WriteLine("break;");

                        // write a blank line
                        writer.WriteLine();

                        // decrease the indent
                        writer.Indent--;
                    }
                }
            }
            #endregion
            
            #region WriteLoadListMethod(ObjectLoaderWriter writer, string className)
            /// <summary>
            /// This method returns the Load List Method
            /// </summary>
            private void WriteLoadListMethod(ObjectLoaderWriter writer, string className, string pluralClassName)
            {
                // locals
                string loadMethodRegionText = "Load[PLURALCLASSNAME](string sourceXmlText)";
                string paramText = "<param name=\"sourceXmlText\">The source xml to be parsed.</param>";
                string methodDescription = "This method is used to load a list of '[CLASSNAME]' objects.";
                string methodDeclarationText = "public List<[CLASSNAME]> Load[PLURALCLASSNAME](string sourceXmlText)";
                string returnText = "<returns>A list of '[CLASSNAME]' objects.</returns>";
                string variableName = "";
                string variableDeclarationText = "List<[CLASSNAME]>";
                string parseObjectsText = "";

                // if the writer exists
                if ((writer != null) && (TextHelper.Exists(className, pluralClassName)))
                {
                    // set the methodDescription
                    methodDescription = methodDescription.Replace("[CLASSNAME]", className);

                    // set the formattedText
                    returnText = returnText.Replace("[CLASSNAME]", className);

                    // set the variableName & variable text
                    variableName = PluralWordHelper.GetPlural(className, TextCaseOptionsEnum.Lower_Case_First_Char);
                    variableDeclarationText = variableDeclarationText.Replace("[CLASSNAME]", className) + " " + variableName;
                    variableDeclarationText = TextHelper.CombineStrings(variableDeclarationText, " = null;");

                    // replace out the loadMethodRegionText
                    loadMethodRegionText = loadMethodRegionText.Replace("[PLURALCLASSNAME]", pluralClassName);
                    
                    // set the methodDeclarationText
                    methodDeclarationText = methodDeclarationText.Replace("[CLASSNAME]", className);
                    methodDeclarationText = methodDeclarationText.Replace("[PLURALCLASSNAME]", pluralClassName);

                    // set the parseObjectsText
                    parseObjectsText = variableName + " = Parse[PLURALCLASSNAME](this.XmlDoc.RootNode);";
                    parseObjectsText = parseObjectsText.Replace("[PLURALCLASSNAME]", pluralClassName);

                    // write the begin region
                    writer.BeginRegion(loadMethodRegionText);

                    // write out the summary for the class
                    writer.WriteLine("/// <summary>");
                    writer.WriteLine("/// " + methodDescription);
                    writer.WriteLine("/// </summary>");
                    writer.WriteLine("/// " + paramText);
                    writer.WriteLine("/// " + returnText);
                    writer.WriteLine(methodDeclarationText);

                    // increase the indent
                    writer.WriteOpenBracket(true);

                    // write the initial value
                    writer.WriteComment("initial value");
                    writer.WriteLine(variableDeclarationText);

                    // write a blank line
                    writer.WriteLine();

                    // Write a comment if the text exists
                    writer.WriteComment("if the source text exists");

                    // write out the check to test if the text exists
                    writer.WriteLine("if (TextHelper.Exists(sourceXmlText))");

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write a comment before creating an instance of the parser
                    writer.WriteComment("create an instance of the parser");

                    // now create an instance of the parser
                    writer.WriteLine("XmlParser parser = new XmlParser();");

                    // write a blank line
                    writer.WriteLine();

                    // write out the comment to load the XmlDoc
                    writer.WriteComment("Create the XmlDoc");

                    // write out the line to create the xml document
                    writer.WriteLine("this.XmlDoc = parser.ParseXmlDocument(sourceXmlText);");

                    // Write blank line
                    writer.WriteLine();

                    // write comment to test if the XmlDoc exists
                    writer.WriteComment("If the XmlDoc exists and has a root node.");

                    // write line to test if the XmlDoc exists
                    writer.WriteLine("if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))");

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // Write comment
                    writer.WriteComment("parse the " + variableName);

                    // now parse the objects
                    writer.WriteLine(parseObjectsText);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a blank line
                    writer.WriteLine();

                    // write the initial value
                    writer.WriteComment("return value");
                    writer.WriteLine("return " + variableName + ";");

                    // decreate the indent
                    writer.WriteCloseBracket(true);

                    // write the end region
                    writer.EndRegion();
                }

                // finished writing the Load method
            }
            #endregion
            
            #region WriteParseListMethod(ObjectLoaderWriter writer, string className, string pluralClassName)
            /// <summary>
            /// This method writes out the Parse List Method.
            /// </summary>
            private void WriteParseListMethod(ObjectLoaderWriter writer, string className, string pluralClassName)
            {
                // locals
                string parseMethodRegionText = "Parse[PLURALCLASSNAME](XmlNode xmlNode, [VARIABLEDECLARATIONTEXT])";
                string paramText = "<param name=\"XmlNode\">The XmlNode to be parsed.</param>";
                string methodDescription = "This method is used to parse a list of '[CLASSNAME]' objects.";
                string methodDeclarationText = "public List<[CLASSNAME]> Parse[PLURALCLASSNAME](XmlNode xmlNode, [VARIABLEDECLARATIONTEXT])";
                string returnText = "<returns>A list of '[CLASSNAME]' objects.</returns>";
                string variableName = "";
                string variableDeclarationText = "List<[CLASSNAME]>";
                string singleObjectName = writer.LowerCaseFirstChar(className);
                string localDeclarationLine = className + " " + singleObjectName + " = null;";
                string isCollectionLine = "";
                string instanciateCollectionLine = "";
                string isNewObjectLine = "else if ((fullName == \"[NEWOBJECTNAME]\") && ([VARIABLENAME] != null))";
                string selfCallText = "[VARIABLENAME] = Parse[PLURALCLASSNAME](childNode, [VARIABLENAME]);";
                string parsingLine = "";
                
                // if the writer exists
                if ((writer != null) && (TextHelper.Exists(className, pluralClassName)))
                {
                    // set the methodDescription
                    methodDescription = methodDescription.Replace("[CLASSNAME]", className);

                    // set the formattedText
                    returnText = returnText.Replace("[CLASSNAME]", className);

                    // set the variableName & variable text
                    variableName = PluralWordHelper.GetPlural(className, TextCaseOptionsEnum.Lower_Case_First_Char);

                    // now that we have the variableName we must set the selfCallText
                    selfCallText = selfCallText.Replace("[VARIABLENAME]", variableName);
                    selfCallText = selfCallText.Replace("[PLURALCLASSNAME]", pluralClassName);

                    // now set the variableDeclarationText
                    variableDeclarationText = variableDeclarationText.Replace("[CLASSNAME]", className) + " " + variableName;
                    variableDeclarationText = TextHelper.CombineStrings(variableDeclarationText, " = null");

                    // set the methodDeclarationText
                    methodDeclarationText = methodDeclarationText.Replace("[CLASSNAME]", className);
                    methodDeclarationText = methodDeclarationText.Replace("[PLURALCLASSNAME]", pluralClassName);

                    // now replace out the  
                    methodDeclarationText = methodDeclarationText.Replace("[VARIABLEDECLARATIONTEXT]", variableDeclarationText);

                    // replace out the loadMethodRegionText
                    parseMethodRegionText = parseMethodRegionText.Replace("[PLURALCLASSNAME]", pluralClassName);
                    parseMethodRegionText = parseMethodRegionText.Replace("[VARIABLEDECLARATIONTEXT]", variableDeclarationText);

                    // write the begin region 
                    writer.BeginRegion(parseMethodRegionText);

                    // write out the summary for the class
                    writer.WriteLine("/// <summary>");
                    writer.WriteLine("/// " + methodDescription);
                    writer.WriteLine("/// </summary>");
                    writer.WriteLine("/// " + paramText);
                    writer.WriteLine("/// " + returnText);
                    writer.WriteLine(methodDeclarationText);

                    // increase the indent
                    writer.WriteOpenBracket(true);

                    // Write out the local variables for this method
                    writer.WriteComment("locals");
                    writer.WriteLine(localDeclarationLine);
                    writer.WriteLine("bool cancel = false;");

                    // write a blank line
                    writer.WriteLine();

                    // write out a comment if the xmlNode exists
                    writer.WriteComment("if the xmlNode exists");

                    // write out the test to ensure the xmlNode exists
                    writer.WriteLine("if (xmlNode != null)");

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write a comment before getting the full name for this node.
                    writer.WriteComment("get the full name for this node");
                    
                    // write out the string to get the full name for this node 
                    writer.WriteLine("string fullName = xmlNode.GetFullName();");

                    // write a blank line
                    writer.WriteLine();

                    // write a comment to test if this is the Collection start line
                    writer.WriteComment("if this is the new collection line");

                    // write out the test to see if this is the new Collection start line
                    isCollectionLine = "if (fullName == \"" + this.SelectedMirror.CollectionNodeName +"\"" + ")";
                   
                    // write out the isCollection line
                    writer.WriteLine(isCollectionLine);

                    // write an open brack
                    writer.WriteOpenBracket(true);

                    // write a comment before calling Parsing
                    writer.WriteComment("Raise event Parsing is starting.");

                    // call Parsing event to indicate the collection parsing is starting.
                    parsingLine = "cancel = Parsing(xmlNode);";
                    writer.WriteLine(parsingLine);

                    // write a blank line
                    writer.WriteLine();

                    // write a comment  if not cancelled
                    writer.WriteComment("If not cancelled");
                    writer.WriteLine("if (!cancel)");
                    writer.WriteOpenBracket(true);

                    // write a line to instanciate the return value
                    instanciateCollectionLine = TextHelper.CombineStrings(variableName, " = ", "new List<[CLASSNAME]>();");
                    instanciateCollectionLine = instanciateCollectionLine.Replace("[CLASSNAME]", className);

                    // write out the instanciate line
                    writer.WriteComment("create the return collection");
                    writer.WriteLine(instanciateCollectionLine);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a close brack
                    writer.WriteCloseBracket(true);

                    // need to create the isNewObjectLine
                    isNewObjectLine = isNewObjectLine.Replace("[NEWOBJECTNAME]",  this.SelectedMirror.NewObjectNodeName).Replace("[VARIABLENAME]", variableName);

                    // write out a comment before writing the else if new object line
                    writer.WriteComment("if this is the new object line and the return collection exists");

                    // write out the isNewObjectLine 
                    writer.WriteLine(isNewObjectLine);

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write a blank line here as a place holder for now.
                    writer.WriteComment("Create a new object");

                    // create a line to instance the new object
                    string instanciateObjectText = singleObjectName + " = new " + className + "();";

                    // write out the instanciate object
                    writer.WriteLine(instanciateObjectText);

                    // write a blank line
                    writer.WriteLine();

                    // write comment Perform post parse operations
                    writer.WriteComment("Perform pre parse operations");

                    // write out the call to Parsing event
                    parsingLine = "cancel = Parsing(xmlNode, ref " + singleObjectName + ");";
                    writer.WriteLine(parsingLine);

                    // write a blank line
                    writer.WriteLine();

                    // write out the comment to test for the parse object
                    writer.WriteComment("If not cancelled");

                    // write out the test for not cancelling
                    writer.WriteLine("if (!cancel)");

                    // write the open bracket
                    writer.WriteOpenBracket(true);

                    // Write a comment parse this object
                    writer.WriteComment("parse this object");

                    // create a parse line
                    string parseObjectLine = singleObjectName + " = Parse" + className + "(ref " + singleObjectName + ", xmlNode);";

                    // write out the parse object line
                    writer.WriteLine(parseObjectLine);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a blank line
                    writer.WriteLine();

                    // write comment Perform post parse operations
                    writer.WriteComment("Perform post parse operations");

                    // write out the call to OnParsed method
                    string onParsedLine = "cancel = Parsed(xmlNode, ref " + singleObjectName + ");";
                    writer.WriteLine(onParsedLine);

                    // write a blank line
                    writer.WriteLine();

                    // write out the comment to test for the parse object
                    writer.WriteComment("If not cancelled");

                    // write out the test for not cancelling
                    writer.WriteLine("if (!cancel)");

                    // write the open bracket
                    writer.WriteOpenBracket(true);

                    // write a comment add to this collection
                    writer.WriteComment("Add this object to the return value");

                    // add this object to the return value
                    string addObjectLine = variableName + ".Add(" + singleObjectName + ");";

                    // write the line to add this object
                    writer.WriteLine(addObjectLine);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a blank linke
                    writer.WriteLine();

                    // write a comment If this node has child nodes
                    writer.WriteComment("if there are ChildNodes");

                    // write out a line to test if this node has child nodes
                    writer.WriteLine("if (xmlNode.HasChildNodes)");

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write a comment // iterate the child nodes
                    writer.WriteComment("iterate the child nodes");

                    // create the foreachLine
                    string foreachLine = "foreach(XmlNode childNode in xmlNode.ChildNodes)";
                    writer.WriteLine(foreachLine);

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write the self call comment
                    writer.WriteComment("self call this method for each childNode");

                    // now write the self call method
                    writer.WriteLine(selfCallText);

                    // close the bracket
                    writer.WriteCloseBracket(true);

                    // close the bracket
                    writer.WriteCloseBracket(true);

                    // close the bracket
                    writer.WriteCloseBracket(true);

                    // write a blank line
                    writer.WriteLine();

                    // write the initial value
                    writer.WriteComment("return value");
                    writer.WriteLine("return " + variableName + ";");

                    // decreate the indent
                    writer.WriteCloseBracket(true);

                    // write the EndRegion
                    writer.EndRegion();
                }
            }
            #endregion
            
            #region WriteParseObjectMethod(ObjectLoaderWriter writer, string className)
            /// <summary>
            /// This method writes out the Parse Object Method (ParseMessage for example).
            /// </summary>
            private void WriteParseObjectMethod(ObjectLoaderWriter writer, string className)
            {
                // locals
                string variableName = "";
                string methodName = "";
                string methodDescription = "This method is used to parse " + className + " objects.";
                string methodDeclarationLine = "";

                // if the writer exists, the className is set and the SelectedMirror exists
                if ((writer != null) && (TextHelper.Exists(className)) && (this.HasSelectedMirror))
                {
                    // set the variableName
                    variableName = writer.LowerCaseFirstChar(className);

                    // set the methodName
                    methodName = TextHelper.CombineStrings("Parse", className, "(ref [CLASSNAME] [VARIABLENAME], XmlNode xmlNode)").Replace("[CLASSNAME]",className).Replace("[VARIABLENAME]", variableName);

                    // set the methodDeclarationLine
                    methodDeclarationLine = "public " + className + " " + methodName;

                    // Write a region for the method
                    writer.BeginRegion(methodName);

                    // Write out the method summary
                    writer.WriteLine("/// <summary>");
                    writer.WriteLine("/// " + methodDescription);
                    writer.WriteLine("/// </summary>");

                    // write out the methodDeclarationLine
                    writer.WriteLine(methodDeclarationLine);

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write a comment to test if the objects exists
                    string ifExistsComment = "if the " + variableName + " object exists and the xmlNode exists";
                    writer.WriteComment(ifExistsComment);

                    // write out a blank line
                    string ifExistsLine = "if ((" + variableName + " != null) && (xmlNode != null))";
                    writer.WriteLine(ifExistsLine);

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // if htis object has a date field link
                    if (this.SelectedMirror.HasDateFieldLink)
                    {
                        // write a comment
                        writer.WriteComment("locals");

                        // write out the locals
                        writer.WriteLine("DateTime defaultDate = new DateTime(2000, 1, 1);");
                        writer.WriteLine("DateTime errorDate = new DateTime(1900, 1, 1);");

                        // write a blank line
                        writer.WriteLine();
                    }

                    // write out a comment // get the full name of this node
                    writer.WriteComment("get the full name of this node");

                    // now set the fullName
                    string getFullNameLine = "string fullName = xmlNode.GetFullName();";

                    // write out the getFullName
                    writer.WriteLine(getFullNameLine);

                    // write a blank line
                    writer.WriteLine();

                    // if there is a selected mirror
                    if (this.SelectedMirror.HasOneOrMoreFieldLinks)
                    {
                        // write out a comment that we are testing if this field is mapped to a property
                        writer.WriteComment("Check the name of this node to see if it is mapped to a property");

                        // write out the swtich start
                        writer.WriteLine("switch(fullName)");

                        // write an open bracket
                        writer.WriteOpenBracket(true);

                        // In the early testing of XmlMirror it was found that when a SourceFieldName is mapped to
                        // more than one target property than the switch statement written in the ParseObject method
                        // (ParseUser for example) would contain a duplicate option which does not compile.
                        // To fix this the FieldLinks must be converted to a List<FieldMap>.
                        List<FieldMap> mappedFields = MapFields(this.SelectedMirror.FieldLinks);

                        // if there are one or more items in the collection.
                        if (ListHelper.HasOneOrMoreItems(mappedFields))
                        {
                            // iterate the fieldLink
                            foreach (FieldMap fieldMap in mappedFields)
                            {
                                // write out the fieldMap
                                WriteFieldMap(writer, variableName, fieldMap);
                            }
                        }

                        // write out a close bracket
                        writer.WriteCloseBracket(true);

                        // write out a blank line
                        writer.WriteLine();
                    }

                    // write a comment If this node has child nodes
                    writer.WriteComment("if there are ChildNodes");

                    // write out a line to test if this node has child nodes
                    writer.WriteLine("if (xmlNode.HasChildNodes)");

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write a comment // iterate the child nodes
                    writer.WriteComment("iterate the child nodes");

                    // create the foreachLine
                    string foreachLine = " foreach(XmlNode childNode in xmlNode.ChildNodes)";
                    writer.WriteLine(foreachLine);

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write a comment // append to this object
                    writer.WriteComment("append to this " + className);

                    // string appendMethod 
                    string appendMethod = variableName + " = Parse" + className + "(ref " + variableName + ", childNode);";
                    writer.WriteLine(appendMethod);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write out a blank line
                    writer.WriteLine();

                    // write comment return value
                    writer.WriteComment("return value");

                    // now write out the return value
                    writer.WriteLine(TextHelper.CombineStrings("return ", variableName, ";"));

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write out the end region
                    writer.EndRegion();
                }
            }
            #endregion
            
            #region WriteParseSingletonMethod(ObjectLoaderWriter writer, string className)
            /// <summary>
            /// This method writes the Parse Singleton Method
            /// </summary>
            private void WriteParseSingletonMethod(ObjectLoaderWriter writer, string className)
            {  
                // if the writer exists
                if ((writer != null) && (TextHelper.Exists(className)))
                {
                    // locals
                    string methodDescription = "This method is used to parse an object of type '[CLASSNAME]'.";
                    string returnText = "<returns>An object of type '[CLASSNAME]'.</returns>";
                    string variableName = writer.LowerCaseFirstChar(className);
                    string parameterName = variableName + "XmlText";
                    string parseMethodRegionText = "Parse[CLASSNAME](string " + parameterName + ")";
                    string paramText = "<param name=\"" + parameterName + "\">The source xml to be parsed.</param>";
                    string methodDeclarationText = "public [CLASSNAME] Parse[CLASSNAME](string " + parameterName + ")";
                    string variableDeclarationText = "[CLASSNAME]";
                    string selfCallText = "[VARIABLENAME] = Parse[CLASSNAME](childNode, [VARIABLENAME]);";
                    string preParsingLine = "bool cancel = Parsing(this.XmlDoc.RootNode, ref [VariableName]);";
                    string postParsingLine = "cancel = Parsed(this.XmlDoc.RootNode, ref [VariableName]);";

                    // set the methodDescription
                    methodDescription = methodDescription.Replace("[CLASSNAME]", className);

                    // set the formattedText
                    returnText = returnText.Replace("[CLASSNAME]", className);

                    // now that we have the variableName we must set the selfCallText
                    selfCallText = selfCallText.Replace("[VARIABLENAME]", variableName);
                    selfCallText = selfCallText.Replace("[CLASSNAME]", className);

                    // now set the variableDeclarationText
                    variableDeclarationText = variableDeclarationText.Replace("[CLASSNAME]", className) + " " + variableName;
                    variableDeclarationText = TextHelper.CombineStrings(variableDeclarationText, " = null");

                    // set the methodDeclarationText
                    methodDeclarationText = methodDeclarationText.Replace("[CLASSNAME]", className);
                    
                    // now replace out the  
                    methodDeclarationText = methodDeclarationText.Replace("[VARIABLEDECLARATIONTEXT]", variableDeclarationText);

                    // replace out the loadMethodRegionText
                    parseMethodRegionText = parseMethodRegionText.Replace("[CLASSNAME]", className);
                    parseMethodRegionText = parseMethodRegionText.Replace("[VARIABLEDECLARATIONTEXT]", variableDeclarationText);

                    // set the value for preParsing
                    preParsingLine = preParsingLine.Replace("[VariableName]", variableName);

                    // set the value for postParsingLine
                    postParsingLine = postParsingLine.Replace("[VariableName]", variableName);

                    // write the begin region 
                    writer.BeginRegion(parseMethodRegionText);

                    // write out the summary for the class
                    writer.WriteLine("/// <summary>");
                    writer.WriteLine("/// " + methodDescription);
                    writer.WriteLine("/// </summary>");
                    writer.WriteLine("/// " + paramText);
                    writer.WriteLine("/// " + returnText);
                    writer.WriteLine(methodDeclarationText);

                    // increase the indent
                    writer.WriteOpenBracket(true);

                    // write initial value comment
                    writer.WriteComment("initial value");

                    // create the text for the line to declare the initial value
                    string initialValueText = className + " " + variableName + " = null;";

                    // write out the initialValueText
                    writer.WriteLine(initialValueText);

                    // write a blank line
                    writer.WriteLine();

                    // write comment to test if the sourceXml string exists
                    writer.WriteComment("if the sourceXmlText exists");

                    // write line to test if the sourceXml string exists
                    writer.WriteLine("if (TextHelper.Exists(" + parameterName + "))");

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write comment '// create an instance of the parser'
                    writer.WriteComment("create an instance of the parser");
                    
                    // Create the parser
                    writer.WriteLine("XmlParser parser = new XmlParser();");

                    // write a blank line
                    writer.WriteLine();

                    // Write Comment 'Create the XmlDoc'
                    writer.WriteComment("Create the XmlDoc");

                    // Create the XmlDoc
                    writer.WriteLine("this.XmlDoc = parser.ParseXmlDocument(" + parameterName + ");");

                    // write a blank line
                    writer.WriteLine();

                    // write a comment ' // If the XmlDoc exists and has a root node.'
                    writer.WriteComment("If the XmlDoc exists and has a root node.");

                    // write a line to test if the XmlDoc exists and has a root node
                    writer.WriteLine("if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))");

                    // write an open bracket
                    writer.WriteOpenBracket(true);

                    // write comment as a placeholder
                    writer.WriteComment("Create a new " + variableName);

                    // write line to create the new object
                    writer.WriteLine(variableName + " = new " + className + "();");

                    // write a blank line
                    writer.WriteLine();

                    // Write comment for Parsing
                    writer.WriteComment("Perform preparsing operations");

                    // Write comment for Parsing
                    writer.WriteLine(preParsingLine);

                    // write a blank line
                    writer.WriteLine();

                    // Write a comment 'if the parsing should not be cancelled'
                    writer.WriteComment("if the parsing should not be cancelled");

                    // write out the test for not cancelled
                    writer.WriteLine("if (!cancel)");

                    // Write the open bracket and increase the indent
                    writer.WriteOpenBracket(true);

                    // Write a comment to parse the object
                    writer.WriteComment("Parse the '" + className + "' object");

                    // write the line to parse the object
                    writer.WriteLine(variableName + " = Parse" + className + "(ref " + variableName + ", this.XmlDoc.RootNode);");

                    // write a blank line
                    writer.WriteLine();

                    // Write a comment
                    writer.WriteComment("Perform post parsing operations");

                    // Write out the call to the Parsed event
                    writer.WriteLine(postParsingLine);

                    // write a blank line
                    writer.WriteLine();

                    // write a comment for a 'if the parsing should be cancelled'
                    writer.WriteComment("if the parsing should be cancelled");

                    // write out the test for cancelled
                    writer.WriteLine("if (cancel)");

                    // Write the open bracket and increase the indent
                    writer.WriteOpenBracket(true);

                    // write a comment to set the variable name to null
                    writer.WriteComment("Set the '" + variableName + "' object to null");

                    // Set the variable to null
                    writer.WriteLine(variableName + " = null;");

                    // Write the close bracket and decrease indent
                    writer.WriteCloseBracket(true);

                    // Write the close bracket and decrease indent
                    writer.WriteCloseBracket(true);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a close bracket
                    writer.WriteCloseBracket(true);

                    // write a blank line
                    writer.WriteLine();

                    // write the initial value
                    writer.WriteComment("return value");
                    writer.WriteLine("return " + variableName + ";");

                    // decreate the indent
                    writer.WriteCloseBracket(true);

                    // write the EndRegion
                    writer.EndRegion();
                }
            }
            #endregion
            
            #region WriteUsingStatements(ObjectLoaderWriter writer, List<Reference> usingStatements)
            /// <summary>
            /// This method writes out the Using Statements given.
            /// </summary>
            private void WriteUsingStatements(ObjectLoaderWriter writer, List<Reference> usingStatements)
            {
                // if the writer exists
                if (writer != null)
                {
                    // write two lines
                    writer.WriteLine();
                    writer.WriteLine();

                    // write the open region for using statemens
                    writer.BeginRegion("using statements");

                    // write a blank line
                    writer.WriteLine();

                    // if there are one or more using statements
                    if (ListHelper.HasOneOrMoreItems(usingStatements))
                    {
                        // iterate the using statements
                        foreach (Reference reference in usingStatements)
                        {
                            // write out this using statements
                            writer.WriteLine("using " + reference.ReferenceName + ";");
                        }
                    }

                    // write a blank line
                    writer.WriteLine();

                    // Write the endregion
                    writer.EndRegion();

                    // write a blank line
                    writer.WriteLine();
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region ClassName
            /// <summary>
            /// This read only property returns the value for 'ClassName'.
            /// </summary>
            public string ClassName
            {
                get
                {
                    // initial value
                    string className = this.ClassNameControl.Text;

                    // if the string is null
                    if (!TextHelper.Exists(className))
                    {
                        // if the SelectedMirror exists
                        if (this.HasSelectedMirror)
                        {
                            // set the parserName
                            className = this.SelectedMirror.Name;
                        }
                    }

                    // if the className exists
                    if (TextHelper.Exists(className))
                    {
                        // Remove .cs or .mir
                        className = className.Replace(".cs", "").Replace(".mir", "");
                    }

                    // return value
                    return className;
                }
            }
            #endregion

            #region CollectionNodeName
            /// <summary>
            /// This property gets or sets the value for 'CollectionNodeName'.
            /// </summary>
            public string CollectionNodeName
            {
                get { return collectionNodeName; }
                set { collectionNodeName = value; }
            }
            #endregion
            
            #region FieldLinks
            /// <summary>
            /// This property gets or sets the value for 'FieldLinks'.
            /// </summary>
            public List<FieldLink> FieldLinks
            {
                get { return fieldLinks; }
                set { fieldLinks = value; }
            }
            #endregion

            #region Fields
            /// <summary>
            /// This property gets or sets the value for 'Fields'.
            /// </summary>
            public List<FieldValuePair> Fields
            {
                get { return fields; }
                set { fields = value; }
            }
            #endregion
            
            #region FindTargetObjectIndex(string selectedClassName)
            /// <summary>
            /// This property gets or sets the value for 'selectedClassName'.
            /// </summary>
            private int FindTargetObjectIndex(string selectedClassName)
            {
                // initial value
                int selectedIndex = -1;

                // locals
                int index = -1;
                string item = "";

                // iterate the items
                foreach (object obj in this.TargetClassComboBox.Items)
                {
                    // set the index
                    index++;

                    // set the item
                    item = obj.ToString();

                    // if this is the class being sought
                    if (item == selectedClassName)
                    {
                        // set the selectedIndex
                        selectedIndex = index;

                        // break out of the loop
                        break;
                    }
                }

                // return value
                return selectedIndex;
            }
            #endregion
            
            #region HasClassName
            /// <summary>
            /// This property returns true if the 'ClassName' exists.
            /// </summary>
            public bool HasClassName
            {
                get
                {
                    // initial value
                    bool hasClassName = (!String.IsNullOrEmpty(this.ClassName));
                    
                    // return value
                    return hasClassName;
                }
            }
            #endregion
            
            #region HasCollectionNodeName
            /// <summary>
            /// This property returns true if the 'CollectionNodeName' exists.
            /// </summary>
            public bool HasCollectionNodeName
            {
                get
                {
                    // initial value
                    bool hasCollectionNodeName = (!String.IsNullOrEmpty(this.CollectionNodeName));
                    
                    // return value
                    return hasCollectionNodeName;
                }
            }
            #endregion
            
            #region HasFieldLinks
            /// <summary>
            /// This property returns true if this object has a 'FieldLinks'.
            /// </summary>
            public bool HasFieldLinks
            {
                get
                {
                    // initial value
                    bool hasFieldLinks = (this.FieldLinks != null);
                    
                    // return value
                    return hasFieldLinks;
                }
            }
            #endregion
            
            #region HasFields
            /// <summary>
            /// This property returns true if this object has a 'Fields'.
            /// </summary>
            public bool HasFields
            {
                get
                {
                    // initial value
                    bool hasFields = (this.Fields != null);
                    
                    // return value
                    return hasFields;
                }
            }
            #endregion
            
            #region HasNewFieldName
            /// <summary>
            /// This property returns true if the 'NewFieldName' exists.
            /// </summary>
            public bool HasNewFieldName
            {
                get
                {
                    // initial value
                    bool hasNewFieldName = (!String.IsNullOrEmpty(this.NewFieldName));
                    
                    // return value
                    return hasNewFieldName;
                }
            }
            #endregion
            
            #region HasNewObjectNodeName
            /// <summary>
            /// This property returns true if the 'NewObjectNodeName' exists.
            /// </summary>
            public bool HasNewObjectNodeName
            {
                get
                {
                    // initial value
                    bool hasNewObjectNodeName = (!String.IsNullOrEmpty(this.NewObjectNodeName));
                    
                    // return value
                    return hasNewObjectNodeName;
                }
            }
            #endregion
            
            #region HasOutputFolder
            /// <summary>
            /// This property returns true if the 'OutputFolder' exists.
            /// </summary>
            public bool HasOutputFolder
            {
                get
                {
                    // initial value
                    bool hasOutputFolder = (!String.IsNullOrEmpty(this.OutputFolder));
                    
                    // return value
                    return hasOutputFolder;
                }
            }
            #endregion
            
            #region HasSelectedAssemblyName
            /// <summary>
            /// This property returns true if the 'SelectedAssemblyName' exists.
            /// </summary>
            public bool HasSelectedAssemblyName
            {
                get
                {
                    // initial value
                    bool hasSelectedAssemblyName = (!String.IsNullOrEmpty(this.SelectedAssemblyName));
                    
                    // return value
                    return hasSelectedAssemblyName;
                }
            }
            #endregion
            
            #region HasSelectedClassName
            /// <summary>
            /// This property returns true if the 'SelectedClassName' exists.
            /// </summary>
            public bool HasSelectedClassName
            {
                get
                {
                    // initial value
                    bool hasSelectedClassName = (!String.IsNullOrEmpty(this.SelectedClassName));
                    
                    // return value
                    return hasSelectedClassName;
                }
            }
            #endregion
            
            #region HasSelectedMirror
            /// <summary>
            /// This property returns true if this object has a 'SelectedMirror'.
            /// </summary>
            public bool HasSelectedMirror
            {
                get
                {
                    // initial value
                    bool hasSelectedMirror = (this.SelectedMirror != null);
                    
                    // return value
                    return hasSelectedMirror;
                }
            }
            #endregion
            
            #region HasSourceFileName
            /// <summary>
            /// This property returns true if the 'SourceFileName' exists.
            /// </summary>
            public bool HasSourceFileName
            {
                get
                {
                    // initial value
                    bool hasSourceFileName = (!String.IsNullOrEmpty(this.SourceFileName));
                    
                    // return value
                    return hasSourceFileName;
                }
            }
            #endregion
            
            #region HasTargetObjectFilePath
            /// <summary>
            /// This property returns true if the 'TargetObjectFilePath' exists.
            /// </summary>
            public bool HasTargetObjectFilePath
            {
                get
                {
                    // initial value
                    bool hasTargetObjectFilePath = (!String.IsNullOrEmpty(this.TargetObjectFilePath));
                    
                    // return value
                    return hasTargetObjectFilePath;
                }
            }
            #endregion
            
            #region HasXmlDoc
            /// <summary>
            /// This property returns true if this object has a 'XmlDoc'.
            /// </summary>
            public bool HasXmlDoc
            {
                get
                {
                    // initial value
                    bool hasXmlDoc = (this.XmlDoc != null);
                    
                    // return value
                    return hasXmlDoc;
                }
            }
            #endregion
            
            #region MenuDropDownOpen
            /// <summary>
            /// This property gets or sets the value for 'MenuDropDownOpen'.
            /// </summary>
            public bool MenuDropDownOpen
            {
                get { return menuDropDownOpen; }
                set { menuDropDownOpen = value; }
            }
            #endregion
            
            #region NewFieldName
            /// <summary>
            /// This property gets or sets the value for 'NewFieldName'.
            /// </summary>
            public string NewFieldName
            {
                get { return newFieldName; }
                set { newFieldName = value; }
            }
            #endregion
            
            #region NewObjectNodeName
            /// <summary>
            /// This property gets or sets the value for 'NewObjectNodeName'.
            /// </summary>
            public string NewObjectNodeName
            {
                get { return newObjectNodeName; }
                set { newObjectNodeName = value; }
            }
            #endregion
            
            #region OutputFolder
            /// <summary>
            /// This property gets or sets the value for 'OutputFolder'.
            /// </summary>
            public string OutputFolder
            {
                get
                {
                    // initial value
                    string outputFolder = this.OutputFolderControl.Text;

                    // return value
                    return outputFolder;
                }
            }
            #endregion

            #region OutputType
            /// <summary>
            /// This property gets or sets the value for 'OutputType'.
            /// </summary>
            public OutputTypeEnum OutputType
            {
                get { return outputType; }
                set 
                { 
                    // set the values
                    outputType = value;

                    // Display the output type
                    DisplayOutputType();
                }
            }
            #endregion
            
            #region SelectedAssemblyName
            /// <summary>
            /// This property gets or sets the value for 'SelectedAssemblyName'.
            /// </summary>
            public string SelectedAssemblyName
            {
                get
                {
                    // initial value
                    string selectedAssemblyName = this.TargetDllTextBox.Text;

                    // return value
                    return selectedAssemblyName;
                }
            }
            #endregion

            #region SelectedClassName
            /// <summary>
            /// This property gets or sets the value for 'SelectedClassName'.
            /// </summary>
            public string SelectedClassName
            {
                get
                {
                    // initial value
                    string selectedClassName = "";
                    
                    // if the SelectedObject exists
                    if (this.TargetClassComboBox.HasSelectedObject)
                    {
                        // Set the class name
                        selectedClassName = TargetClassComboBox.SelectedObject.ToString();
                    }

                    // return value
                    return selectedClassName;
                }
            }
            #endregion
            
            #region SelectedMirror
            /// <summary>
            /// This property gets or sets the value for 'SelectedMirror'.
            /// </summary>
            public Mirror SelectedMirror
            {
                get { return selectedMirror; }
                set { selectedMirror = value; }
            }
            #endregion
            
            #region SourceFileName
            /// <summary>
            /// This property gets or sets the value for 'SourceFileName'.
            /// </summary>
            public string SourceFileName
            {
                get { return sourceFileName; }
                set { sourceFileName = value; }
            }
            #endregion
            
            #region TargetObjectFilePath
            /// <summary>
            /// This property gets or sets the value for 'TargetObjectFilePath'.
            /// </summary>
            public string TargetObjectFilePath
            {
                get { return targetObjectFilePath; }
                set { targetObjectFilePath = value; }
            }
            #endregion
            
            #region XmlDoc
            /// <summary>
            /// This property gets or sets the value for 'XmlDoc'.
            /// </summary>
            public XmlDocument XmlDoc
            {
                get { return xmlDoc; }
                set { xmlDoc = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
