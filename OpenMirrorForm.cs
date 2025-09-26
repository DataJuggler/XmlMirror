

#region using statements

using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using XmlMirror.Runtime9.Objects;
using XmlMirror.Xml.Parsers;

#endregion

namespace XmlMirror
{

    #region class OpenMirrorForm
    /// <summary>
    /// This 
    /// </summary>
    public partial class OpenMirrorForm : Form
    {
        
        #region Private Variables
        private List<Mirror> mirrors;
        private Mirror selectedMirror;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of an OpenMirrorForm.
        /// </summary>
        public OpenMirrorForm()
        {
            // Create controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region MirrorFilesListBox_DoubleClick(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Mirror Files List Box _ Double Click
            /// </summary>
            private void MirrorFilesListBox_DoubleClick(object sender, EventArgs e)
            {
                try
                {
                    // set the path
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string fileName = "";

                    // if path already has backslash
                    if (path.EndsWith(@"\"))
                    {
                        // append the mirror folder
                        fileName = path + @"Data Juggler\XML Mirror\Mirrors\";
                    }
                    else
                    {
                        // append the mirror folder
                        fileName = path + @"\Data Juggler\XML Mirror\Mirrors\";
                    }

                    // get the selected fileName
                    fileName = fileName + this.MirrorFilesListBox.SelectedItem.ToString() + ".mir";

                    // if the fileName exists
                    if (File.Exists(fileName))
                    {
                        // Get all the text from this file
                        string mirrorText = File.ReadAllText(fileName);

                        // Create a new instance of a 'MirrorsParser' object.
                        MirrorsParser parser = new MirrorsParser();

                        // set the SelectedMirror
                        this.SelectedMirror = parser.ParseMirror(mirrorText);
                        
                        // close this form
                        this.Close();
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // Show the user a message
                    MessageBox.Show("An error occurred opening mirror: " + error.ToString(), "Open Mirror Failed");
                }
            }
            #endregion
            
            #region MirrorFilesListBox_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// This event is fired when Mirror Files List Box _ Key Down
            /// </summary>
            private void MirrorFilesListBox_KeyDown(object sender, KeyEventArgs e)
            {
                // locals
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fullFilePath = "";
                string fileName = "";

                // if the Delete key was exists
				if ((e.KeyCode == Keys.Delete) && (this.MirrorFilesListBox.SelectedItem != null))
				{
                    // get the mirrorNameToDelete
                    string mirrorNameToDelete = this.MirrorFilesListBox.SelectedItem.ToString();

                    // set the message & title
                    string message = "Are you wish to delete the mirror named '" + mirrorNameToDelete + "'?" + Environment.NewLine + Environment.NewLine + "This action cannot be undone.";
                    string title = "Confirm Delete?";

                    // get the result
                    DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // if the user gave the ok to delete
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // if path already has backslash
                        if (path.EndsWith(@"\"))
                        {
                            // append the mirror folder
                            path = path + @"Data Juggler\XML Mirror\Mirrors\";
                        }
                        else
                        {
                            // append the mirror folder
                            path = path + @"\Data Juggler\XML Mirror\Mirrors\";
                        }

                        // if the path exists
                        if (Directory.Exists(path))
                        {
                            // get the files in the Mirrors directory
                            string[] files = Directory.GetFiles(path);

                            // iterate the files in the directory
                            foreach (string file in files)
                            {
                                // set the fullFilePath
                                fullFilePath = file;

                                // if this is a Mirror file
                                if (file.EndsWith(".mir"))
                                {
                                    // get the index of the last backslash
                                    int index = file.LastIndexOf(@"\") + 1;

                                    // get the fileName
                                    fileName = file.Substring(index);

                                    // set the fileName without the extension
                                    fileName = fileName.Replace(".mir", "");

                                    // if this is the mirror being sought
                                    if (TextHelper.IsEqual(fileName, mirrorNameToDelete))
                                    {
                                        // Delete the file
                                        File.Delete(fullFilePath);

                                        // get the index of the file
                                        index = this.MirrorFilesListBox.Items.IndexOf(fileName);

                                        // remove this item
                                        if (index >= 0)
                                        {
                                            // remove this item
                                            this.MirrorFilesListBox.Items.RemoveAt(index);
                                        }

                                        // break out of loop
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // load the mirrors
                this.Mirrors = LoadMirrors();
            }
            #endregion
            
            #region LoadMirrors()
            /// <summary>
            /// This method returns a list of Mirrors
            /// </summary>
            private List<Mirror> LoadMirrors()
            {  
                // initial value
                List<Mirror> mirrors = new List<Mirror>();

                // locals
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fileName = "";

                // if path already has backslash
                if (path.EndsWith(@"\"))
                {
                    // append the mirror folder
                    path = path + @"Data Juggler\XML Mirror\Mirrors\";
                }
                else
                {
                    // append the mirror folder
                    path = path + @"\Data Juggler\XML Mirror\Mirrors\";
                }
                
                // if the path exists
                if (Directory.Exists(path))
                {
                    // get the files in the Mirrors directory
                    string[] files = Directory.GetFiles(path);

                    // iterate the files in the directory
                    foreach (string file in files)
                    {
                        // if this is a Mirror file
                        if (file.EndsWith(".mir"))
                        {
                            // get the index of the last backslash
                            int index = file.LastIndexOf(@"\") + 1;

                            // get the fileName
                            fileName = file.Substring(index);

                            // set the fileName without the extension
                            fileName = fileName.Replace(".mir", "");

                            // Add this file
                            this.MirrorFilesListBox.Items.Add(fileName);
                        }
                    }
                }

                // return value
                return mirrors;
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasMirrors
            /// <summary>
            /// This property returns true if this object has a 'Mirrors'.
            /// </summary>
            public bool HasMirrors
            {
                get
                {
                    // initial value
                    bool hasMirrors = (this.Mirrors != null);
                    
                    // return value
                    return hasMirrors;
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
            
            #region Mirrors
            /// <summary>
            /// This property gets or sets the value for 'Mirrors'.
            /// </summary>
            public List<Mirror> Mirrors
            {
                get { return mirrors; }
                set { mirrors = value; }
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
            
        #endregion
        
    }
    #endregion

}
