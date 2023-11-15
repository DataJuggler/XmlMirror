

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.Win.Controls.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;
using XmlMirror.Runtime6.Objects;
using XmlMirror.Xml.Writers;

#endregion

namespace XmlMirror
{

    #region class SaveMirrorForm
    /// <summary>
    /// This class is used to save the current Mirror.
    /// </summary>
    public partial class SaveMirrorForm : Form, ISaveCancelHost
    {
        
        #region Private Variables
        private bool userCancelled;
        private Mirror mirror;
        #endregion
        
        #region Constructor
        /// <summary>
        /// This 
        /// </summary>
        public SaveMirrorForm()
        {
            // Create controls
            InitializeComponent();

            // default to true
            this.UserCancelled = true;
        }
        #endregion

        #region Events

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
            
            #region CancelSaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'CancelSaveButton' is clicked.
            /// </summary>
            private void CancelSaveButton_Click(object sender, EventArgs e)
            {
                // the user did cancel
                this.OnCancel();
            }
            #endregion
            
            #region OnCancel();
            /// <summary>
            /// The event to call when Cancel is clicked.
            /// </summary>
            public void OnCancel()
            {
                // the user did cancel
                this.UserCancelled = true;

                // close this form
                this.Close();
            }
            #endregion

            #region OnSave(bool close);
            /// <summary>
            /// The event to call when Save is clicked.
            /// </summary>
            public bool OnSave(bool close)
            {
                // initial value
                bool saved = false;

                // locals
                string mirrorName = "";
                string fileName = "";
                string backupFileName = "";
                
                // if the Mirror exists
                if (this.HasMirror)
                { 
                    // set the fileName
                    mirrorName = this.MirrorFileNameTextBox.Text;

                    // if the mirrorNameToDelete already has the extension
                    if (mirrorName.EndsWith(".mir"))
                    {
                        // set the fileName without the extension
                        mirrorName = mirrorName.Substring(0, fileName.Length - 4);
                    }

                    // if the mirrorNameToDelete exists
                    if (TextHelper.Exists(mirrorName))
                    {
                        // set the mirror name
                        mirror.Name = mirrorName;

                        // set the path
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    
                        // local
                        string timeStamp = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        timeStamp = timeStamp.Replace("/", "-").Replace(":", " ");
                    
                        // if path already has backslash
                        if (path.EndsWith(@"\"))
                        {
                            // append the mirror folder
                            fileName = path + @"Data Juggler\XML Mirror\Mirrors\" + mirrorName + ".mir";

                            // set the backupFileName
                            backupFileName = path + @"Data Juggler\XML Mirror\Mirrors\Backup\" + mirrorName + " " + timeStamp + ".mir";
                        }
                        else
                        {
                            // append the mirror folder
                            fileName = path + @"\Data Juggler\XML Mirror\Mirrors\" + mirrorName + ".mir";

                            // set the backupFileName
                            backupFileName = path + @"\Data Juggler\XML Mirror\Mirrors\Backup\" + mirrorName + " " + timeStamp + ".mir";
                        }

                        // Create a MirrorWriter
                        MirrorsWriter writer = new MirrorsWriter();

                        // Export the mirror
                        string mirrorXml = writer.ExportMirror(Mirror);
                        
                        // Write Out The Mirror
                        WriteMirror(mirrorXml, fileName);

                        // Write Out The Backup Mirror
                        WriteMirror(mirrorXml, backupFileName);

                        // Show a message
                        MessageBox.Show("All changes have been saved.", "Changes Saved");
                    
                        // if close is true
                        if (close)
                        {
                            // close this form
                            this.Close();
                        }
                    }
                    else
                    {
                        // Show a message FileName is required.
                        MessageBox.Show("You must enter a name for this Xml Mirror file.", "Filename Required");
                    }
                }
                else
                {
                    // Show a message FileName is required.
                    MessageBox.Show("System error Xml Mirror does not exist.", "Mirror Required - System Error");
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'SaveButton' is clicked.
            /// </summary>
            private void SaveButton_Click(object sender, EventArgs e)
            {
                // save the Mirror
                OnSave(true);
            }
            #endregion
            
        #endregion

        #region Methods

            #region WriteMirror(string mirrorXml, string fileName)
            /// <summary>
            /// This method saves the mirrorXml to the fileName given
            /// </summary>
            /// <param name="mirrorXml"></param>
            /// <param name="fileName"></param>
            public void WriteMirror(string mirrorXml, string fileName)
            {
                // if the mirrorXml and fileName both exist
                if (TextHelper.Exists(mirrorXml, fileName))
                {
                    // if the file already exists
                    if (File.Exists(fileName))
                    {
                        // Delete the existing file
                        File.Delete(fileName);
                    }
                    
                    // Now write out the file
                    File.WriteAllText(fileName, mirrorXml);
                }
                else
                {
                    // if the mirrorXml exists  
                    if (!TextHelper.Exists(mirrorXml))
                    {
                        // Write this to the output window
                        DebugHelper.WriteDebugError("WriteMirror", "SaveMirrorForm", new Exception("The mirrorXml text does not exist"));
                    }
                    
                    // if the fileName does not exist
                    if (!TextHelper.Exists(fileName))
                    {
                        // Write this to the output window
                        DebugHelper.WriteDebugError("WriteMirror", "SaveMirrorForm", new Exception("The fileName does not exist"));
                    }
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasMirror
            /// <summary>
            /// This property returns true if this object has a 'Mirror'.
            /// </summary>
            public bool HasMirror
            {
                get
                {
                    // initial value
                    bool hasMirror = (this.Mirror != null);
                    
                    // return value
                    return hasMirror;
                }
            }
            #endregion
            
            #region Mirror
            /// <summary>
            /// This property gets or sets the value for 'Mirror'.
            /// </summary>
            public Mirror Mirror
            {
                get { return mirror; }
                set 
                { 
                    // set the return value
                    mirror = value;

                    // if the mirror exists
                    if (mirror != null)
                    {
                        // if this mirror has a name
                        if (mirror.HasName)
                        {
                            // set the Mirror file name to the Mirror Name
                            this.MirrorFileNameTextBox.Text = mirror.Name;
                        }
                        else
                        {
                            // set the Mirror file name to be the TargetClassName
                            this.MirrorFileNameTextBox.Text = mirror.TargetClassName;
                        }
                    }
                }
            }
            #endregion
            
            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
