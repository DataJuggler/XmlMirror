
#region using statements


using NoteBoard.Xml.Writers;
using NoteBoard.Xml.Parsers;
using DataJuggler.Core.UltimateHelper;
using NoteBoard.Client.Controls;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteBoard.Model;
using NoteBoard.Client.Util;

#endregion

namespace NoteBoard.Client
{

    #region class MainForm
    /// <summary>
    /// This is the main form for this application.
    /// </summary>
    public partial class MainForm : Form, ICheckChangedListener
    {

        #region Private Variables
        private string xmlFile;
        private string settingsFile;
        private List<Note> notes;
        private NoteControl selectedNoteControl;
        private Setting settings;
        private LayoutManager layoutManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region AddNoteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AddNoteButton' is clicked.
            /// </summary>
            private void AddNoteButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of a 'NoteEditorForm' object.
                NoteEditorForm noteEditorForm = new NoteEditorForm();

                // Create a new instance of a 'Note' object.
                Note note = new Note();

                // Set the NoteId
                note.Id = this.Notes.Max(x => x.Id) + 1;

                // Set the note so the Id is displayed
                noteEditorForm.Note = note;

                // show the form to the user
                noteEditorForm.ShowDialog();

                // if the user 'Saved'
                if (!noteEditorForm.UserCancelled)
                {
                    // Save this note to our Xml File
                    if (noteEditorForm.HasNote)
                    {
                        // get the updated note
                        note = noteEditorForm.Note;
                        
                        // Add this note
                        this.Notes.Add(noteEditorForm.Note);
                        
                        // Save the Notes
                        Save();

                        // Display the current notes
                        DisplayNotes();
                    }
                }
            }
            #endregion
            
            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region DeleteNoteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DeleteNoteButton' is clicked.
            /// </summary>
            private void DeleteNoteButton_Click(object sender, EventArgs e)
            {
                // local
                bool confirmed = true;

                // if the value for HasSelectedNote is true
                if ((HasSelectedNote) && (HasNotes))
                {
                    // if a user's response is required
                    if (this.PromptForDeleteControl.Checked)
                    {
                        // now default to false until the user sets it up
                        confirmed = false;

                        // Prompt the user
                        DialogControlForm dialog = new DialogControlForm();  

                        // Setup the control
                        dialog.Setup("Are you wish to delete the selected note? This action cannot be undone.", "Confirm Delete");

                        // Show the dialog
                        dialog.ShowDialog();

                        // get the user's response
                        if (dialog.UserResponse == UserResponseEnum.Confirmed)
                        {
                            // user is confirmed to delete
                            confirmed = true;
                        }
                    }

                    // if ok to delete
                    if (confirmed)
                    {
                        // find the note by Id
                        Note note = Notes.FirstOrDefault(x => x.Id == SelectedNote.Id);

                        // If the note object exists
                        if (NullHelper.Exists(note))
                        {
                            // remove this item
                            Notes.Remove(note);

                            // Save the notes with this item removed
                            Save();

                            // redisplay the notes
                            DisplayNotes();
                        }
                    }
                }
            }
            #endregion
            
            #region EditNoteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'EditNoteButton' is clicked.
            /// </summary>
            private void EditNoteButton_Click(object sender, EventArgs e)
            {
                // if the value for HasSelectedNote is true
                if (HasSelectedNote)
                {
                    // Create a new instance of a 'NoteEditorForm' object.
                    NoteEditorForm noteEditorForm = new NoteEditorForm();

                    // Create a new note
                    noteEditorForm.Note = this.SelectedNote;

                    // show the form to the user
                    noteEditorForm.ShowDialog();

                    // if the user 'Saved'
                    if (!noteEditorForm.UserCancelled)
                    {
                        // Save this note to our Xml File
                        if (noteEditorForm.HasNote)
                        {
                            // update an existing note

                            // first we must find the note
                            Note note = this.Notes.FirstOrDefault( x => x.Id == noteEditorForm.Note.Id);

                            // If the note object exists
                            if (NullHelper.Exists(note))
                            {
                                // Find the Id of this note
                                int noteIndex = FindNoteIndex(note.Id);

                                // if the noteIndex was found
                                if (noteIndex >= 0)
                                {
                                    // Update the note
                                    Notes[noteIndex] = noteEditorForm.Note;
                                }
                            }

                            // Save the Notes
                            Save();

                            // Display the current notes
                            DisplayNotes();

                            // Erase any selections
                            SelectedNoteControl = null;
                        }
                    }
                }
            }
            #endregion

            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked);
            /// <summary>
            /// The checkbox has been checked or unchecked.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // if the value for HasSettings is true
                if (HasSettings)
                {
                    if (sender.Name == PromptForDeleteControl.Name)
                    {
                        // Set the value
                        Settings.PromptForDelete = isChecked;
                    }
                    else if (sender.Name == DisableHoveringControl.Name)
                    {
                        // set the value
                        Settings.DisableHoverControl = isChecked;
                    }

                    // if the value for HasSettingsFile is true
                    if (HasSettingsFile)
                    {
                        // Save the Settings
                        SaveSettings();
                    }
                }
            }
            #endregion
            
            #region Unselect_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'Unselect' is clicked.
            /// </summary>
            private void Unselect_Click(object sender, EventArgs e)
            {
                // erase
                this.SelectedNoteControl = null;
            }
            #endregion
            
        #endregion
    
        #region Methods

            #region ClickDeleteButton()
            /// <summary>
            /// This method Click Delete Button
            /// </summary>
            public void ClickDeleteButton()
            {
                // if the value for HasSelectedNote is true
                if (HasSelectedNote)
                {
                    // Click the Delete Button
                    DeleteNoteButton_Click(this, new EventArgs());
                }
            }
            #endregion
            
            #region ClickEditButton()
            /// <summary>
            /// This method Clicks the Edit Button
            /// </summary>
            public void ClickEditButton()
            {  
                // if the value for HasSelectedNote is true
                if (HasSelectedNote)
                {
                    // Click the edit button
                    EditNoteButton_Click(this, new EventArgs());
                }
            }
            #endregion
            
            #region DisplayNotes()
            /// <summary>
            /// This method Display Notes
            /// </summary>
            public void DisplayNotes()
            {
                // Suspend updates
                this.SuspendLayout();    
            
                // RemoveNoteControls
                RemoveNoteControls();

                // Create a new instance of a 'LayoutManager' object.
                this.LayoutManager = new LayoutManager();

                // Create a new instance of a 'Point' object.
                Point point = new Point();

                 // Create a new instance of a 'NoteControl' object.
                NoteControl noteControl = null;

                // if the value for HasNotes is true
                if (HasNotes)
                {
                    // order by priority in descending order
                    List<Note> notes = Notes.OrderBy(x => x.Priority).OrderBy(x => x.Id).ToList();

                    // Iterate the collection of Note objects
                    foreach (Note note in Notes)
                    {
                        // Create a new instance of a 'NoteControl' object.
                        noteControl = new NoteControl();

                        // set the note
                        noteControl.Note = note;
                        noteControl.Dock = DockStyle.None;

                        // Add this control
                        this.Controls.Add(noteControl);

                        // determine which panel to add this to
                        switch (note.Priority)
                        {
                            case PriorityEnum.Low:

                                // get the point
                                point = layoutManager.Add(noteControl, PriorityEnum.Low);

                                // required
                                break;

                            case PriorityEnum.Normal:

                                // get the point
                                point = layoutManager.Add(noteControl, PriorityEnum.Normal);

                                // required
                                break;

                            case PriorityEnum.High:

                                // get the point
                                point = layoutManager.Add(noteControl, PriorityEnum.High);

                                // required
                                break;
                        }    
                        
                        // set the location
                        noteControl.Location = point;
                    }

                    // resume updates
                    this.ResumeLayout();

                    // refresh everything
                    this.Refresh();
                }
            }
            #endregion
            
            #region FindNoteIndex(int id)
            /// <summary>
            /// This method returns the Note Index
            /// </summary>
            public int FindNoteIndex(int id)
            {
                // initial value
                int noteIndex = -1;
                int tempIndex = -1;

                // if the id is set and the Notes collection exists
                if ((id > 0) && (this.HasNotes))
                {
                    // Iterate the collection of Note objects
                    foreach (Note note in Notes)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        //  if this is the id being sought
                        if (note.Id == id)
                        {
                            // set the return value
                            noteIndex = tempIndex;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return noteIndex;
            }
            #endregion
            
            #region HideHoverControl()
            /// <summary>
            /// This method Hide Hover Control
            /// </summary>
            public void HideHoverControl()
            {
                // hide the NoteHoverControl
                NoteHoverControl.Visible = false;

                // Refresh now
                this.Refresh();
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new instance of a 'LayoutManager' object.
                this.LayoutManager = new LayoutManager();

                // wire up the check changed listeners
                this.PromptForDeleteControl.CheckChangedListener = this;
                this.DisableHoveringControl.CheckChangedListener = this;

                // Always open Maximized
                this.WindowState = FormWindowState.Maximized;

                // add any initialization code here
                this.XmlFile = Path.Combine(Environment.CurrentDirectory, "NoteBoard.xml");
                this.SettingsFile = Path.Combine(Environment.CurrentDirectory, "Setting.xml");

                // If the file exists
                if (File.Exists(XmlFile))
                {
                    // set the xmlText
                    string xmlText = File.ReadAllText(XmlFile);

                    // If the xmlText string exists
                    if (TextHelper.Exists(xmlText))
                    {
                        // create a notes parser
                        NotesParser parser = new NotesParser();

                        // load the notes
                        this.Notes = parser.LoadNotes(xmlText);
                    }
                }

                // If the file exists
                if (File.Exists(SettingsFile))
                {
                    // set the xmlText
                    string xmlText = File.ReadAllText(SettingsFile);

                    // If the xmlText string exists
                    if (TextHelper.Exists(xmlText))
                    {
                        // create a notes parser
                        SettingsParser parser = new SettingsParser();

                        // load the Settings
                        Settings = parser.ParseSetting(xmlText);
                    }
                }

                // if the Settings does not exist
                if (!HasSettings)
                {
                    // Create a new settings object
                    this.Settings = new Setting();
                }

                // Set the value of Prompt for Delete
                this.PromptForDeleteControl.Checked = Settings.PromptForDelete;
                this.DisableHoveringControl.Checked = Settings.DisableHoverControl;
                
                // If the Notes object does not exist
                if (!this.HasNotes)
                {
                    // Create a new collection of 'Note' objects.
                    this.Notes = new List<Note>();
                }

                // Display the Notes
                this.DisplayNotes();

                // enable the conntrols
                UIControl();
            }
            #endregion

            #region RemoveNoteControls()
            /// <summary>
            /// This method Remove Note Controls
            /// </summary>
            public void RemoveNoteControls()
            {
                // if the value for HasLayoutManager is true
                if (HasLayoutManager)
                {
                    // first remove the high priority items
                    foreach (NoteControl noteControl in LayoutManager.HighPriorityItems)
                    {
                        // remove the noteControl
                        this.Controls.Remove(noteControl);
                    }

                    // now remove the normal priority items
                    foreach (NoteControl noteControl in LayoutManager.NormalPriorityItems)
                    {
                        // remove the noteControl
                        this.Controls.Remove(noteControl);
                    }

                    // and finally remove the low priority items
                     foreach (NoteControl noteControl in LayoutManager.LowPriorityItems)
                    {
                        // remove the noteControl
                        this.Controls.Remove(noteControl);
                    }
                }
            }
            #endregion
            
            #region Save()
            /// <summary>
            /// This method saves the Notes to xml
            /// </summary>
            public bool Save()
            {
                // initial value
                bool saved = false;

                // if the value for HasNotes is true
                if ((HasNotes) && (HasXmlFile))
                {
                    // Create a new instance of a 'NotesWriter' object.
                    NotesWriter writer = new NotesWriter();

                    // export the notes to xml
                    string xml = writer.ExportList(Notes);

                    // if the file exists on the hard drive
                    if (File.Exists(XmlFile))
                    {
                        // Delete the existing file
                        File.Delete(XmlFile);
                    }

                    // write out the xml
                    File.AppendAllText(XmlFile, xml);                    
                }
                
                // return value
                return saved;
            }
            #endregion

            #region SaveSettings()
            /// <summary>
            /// This method saves the Settings to xml
            /// </summary>
            public bool SaveSettings()
            {
                // initial value
                bool saved = false;

                // if the value for HasSettings is true and the SettingsFile exists
                if ((HasSettings) && (HasSettingsFile))
                {
                    // Create a new instance of a 'SettingsWriter' object.
                    SettingsWriter writer = new SettingsWriter();

                    // export the notes to xml
                    string xml = writer.ExportSetting(Settings);

                    // if the file exists on the hard drive
                    if (File.Exists(SettingsFile))
                    {
                        // Delete the existing file
                        File.Delete(SettingsFile);
                    }

                    // write out the xml
                    File.AppendAllText(SettingsFile, xml);                    
                }
                
                // return value
                return saved;
            }
            #endregion
            
            #region ShowHoverControl(NoteControl noteControl)
            /// <summary>
            /// This method Show Hover Control
            /// </summary>
            public void ShowHoverControl(NoteControl noteControl)
            {
                // if the Settings control exists and DisableHoverControl is false
                if ((HasSettings) && (!Settings.DisableHoverControl))
                {
                    // set the top
                    int hoverTop = 0;
                    int hoverLeft = 0;
                    Note note = null;

                    // If the note object exists
                    if ((NullHelper.Exists(noteControl)) && (noteControl.HasNote))
                    {
                        // set the note
                        note = noteControl.Note;

                        // Set the panel to the high panel at first
                        hoverTop = HighPriorityButton.Top + 240;
                        hoverLeft = noteControl.Left + 88;

                        // determine where to show the note
                        if (note.Priority == PriorityEnum.Low)
                        {
                            // Go above the control for the low panel
                            hoverTop = LowPriorityButton.Top - 160;
                        }
                        else if (note.Priority == PriorityEnum.Normal)
                        {
                            // use the NormalPanel
                            hoverTop = NormalPriorityButton.Top + 240;
                        }

                        // Display the Note Description
                        this.NoteHoverControl.Top = hoverTop;
                        this.NoteHoverControl.Left = hoverLeft;
                        this.NoteHoverControl.DisplayNoteDescription(note.Description);
                        this.NoteHoverControl.Visible = true;
                    }

                    // refresh everything
                    this.Refresh();
                }
            }
            #endregion
            
            #region UIControl()
            /// <summary>
            /// This method UI Control
            /// </summary>
            public void UIControl()
            {
                // default to not enabled unless we have a selected control
                this.EditNoteButton.Enabled = false;
                this.DeleteNoteButton.Enabled = false;

                // if the value for HasSelectedNoteControl is true
                if (HasSelectedNoteControl)
                {
                    // enable the edit buttons
                    this.EditNoteButton.Enabled = true;
                    this.DeleteNoteButton.Enabled = true;
                }

                // if the value for HasSelectedNote is true
                if (HasSelectedNote)
                {
                    // use the enabled buttons
                    this.EditNoteButton.BackgroundImage = NoteBoard.Client.Properties.Resources.Edit_Button;
                    this.DeleteNoteButton.BackgroundImage = NoteBoard.Client.Properties.Resources.Delete_Button;
                }
                else
                {
                    // use the disabled buttons
                    this.EditNoteButton.BackgroundImage = NoteBoard.Client.Properties.Resources.Edit_Button_Disabled;
                    this.DeleteNoteButton.BackgroundImage = NoteBoard.Client.Properties.Resources.Delete_Button_Disabled;
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion

            #region HasLayoutManager
            /// <summary>
            /// This property returns true if this object has a 'LayoutManager'.
            /// </summary>
            public bool HasLayoutManager
            {
                get
                {
                    // initial value
                    bool hasLayoutManager = (this.LayoutManager != null);
                    
                    // return value
                    return hasLayoutManager;
                }
            }
            #endregion
            
            #region HasNotes
            /// <summary>
            /// This property returns true if this object has a 'Notes'.
            /// </summary>
            public bool HasNotes
            {
                get
                {
                    // initial value
                    bool hasNotes = (this.Notes != null);
                    
                    // return value
                    return hasNotes;
                }
            }
            #endregion
           
            #region HasSelectedNote
            /// <summary>
            /// This property returns true if this object has a 'SelectedNote'.
            /// </summary>
            public bool HasSelectedNote
            {
                get
                {
                    // initial value
                    bool hasSelectedNote = (this.SelectedNote != null);
                    
                    // return value
                    return hasSelectedNote;
                }
            }
            #endregion
            
            #region HasSelectedNoteControl
            /// <summary>
            /// This property returns true if this object has a 'SelectedNoteControl'.
            /// </summary>
            public bool HasSelectedNoteControl
            {
                get
                {
                    // initial value
                    bool hasSelectedNoteControl = (this.SelectedNoteControl != null);
                    
                    // return value
                    return hasSelectedNoteControl;
                }
            }
            #endregion
            
            #region HasSelectedNoteControlId
            /// <summary>
            /// This property returns true if this object has a 'SelectedNoteControlId'.
            /// </summary>
            public bool HasSelectedNoteControlId
            {
                get
                {
                    // initial value
                    bool hasSelectedNoteControlId = (this.SelectedNoteControlId != Guid.Empty);
                    
                    // return value
                    return hasSelectedNoteControlId;
                }
            }
            #endregion
            
            #region HasSelectedNoteId
            /// <summary>
            /// This property returns true if the 'SelectedNoteId' is set.
            /// </summary>
            public bool HasSelectedNoteId
            {
                get
                {
                    // initial value
                    bool hasSelectedNoteId = (this.SelectedNoteId > 0);
                    
                    // return value
                    return hasSelectedNoteId;
                }
            }
            #endregion
            
            #region HasSettings
            /// <summary>
            /// This property returns true if this object has a 'Settings'.
            /// </summary>
            public bool HasSettings
            {
                get
                {
                    // initial value
                    bool hasSettings = (this.Settings != null);
                    
                    // return value
                    return hasSettings;
                }
            }
            #endregion
            
            #region HasSettingsFile
            /// <summary>
            /// This property returns true if the 'SettingsFile' exists.
            /// </summary>
            public bool HasSettingsFile
            {
                get
                {
                    // initial value
                    bool hasSettingsFile = (!String.IsNullOrEmpty(this.SettingsFile));
                    
                    // return value
                    return hasSettingsFile;
                }
            }
            #endregion
            
            #region HasXmlFile
            /// <summary>
            /// This property returns true if the 'XmlFile' exists.
            /// </summary>
            public bool HasXmlFile
            {
                get
                {
                    // initial value
                    bool hasXmlFile = (!String.IsNullOrEmpty(this.XmlFile));
                    
                    // return value
                    return hasXmlFile;
                }
            }
            #endregion
            
            #region LayoutManager
            /// <summary>
            /// This property gets or sets the value for 'LayoutManager'.
            /// </summary>
            public LayoutManager LayoutManager
            {
                get { return layoutManager; }
                set { layoutManager = value; }
            }
            #endregion
            
            #region Notes
            /// <summary>
            /// This property gets or sets the value for 'Notes'.
            /// </summary>
            public List<Note> Notes
            {
                get { return notes; }
                set { notes = value; }
            }
            #endregion
            
            #region SelectedNote
            /// <summary>
            /// This read only property returrns the Note from the SelectedNoteControl
            /// </summary>
            public Note SelectedNote
            {
                get 
                { 
                    // initia value
                    Note selectedNote = null;

                    // if the value for HasSelectedNoteControl is true
                    if (HasSelectedNoteControl)
                    {
                        // set the return value
                        selectedNote = SelectedNoteControl.Note;
                    }

                    // return value
                    return selectedNote;
                }
            }
            #endregion

            #region SelectedNoteControl
            /// <summary>
            /// This property gets or sets the value for 'SelectedNoteControl'.
            /// </summary>
            public NoteControl SelectedNoteControl
            {
                get { return selectedNoteControl; }
                set 
                { 
                    // if the selectedNoteControl already exists
                    if (selectedNoteControl != null)
                    {
                        if ((value == null) || (value.Id != selectedNoteControl.Id))
                        {
                            // hide selection of the old one
                            selectedNoteControl.Selected = false;
                        }
                    }

                    // set the value
                    selectedNoteControl = value;
                 
                    // Handle the buttons whenever the selection changes
                    UIControl();
                }
            }
            #endregion

            #region SelectedNoteControlId
            /// <summary>
            /// This read only returns the SelectedNoteControl
            /// </summary>
            public Guid SelectedNoteControlId
            {
                get 
                { 
                    // initial value
                    Guid selectedNoteControlId = Guid.Empty;

                    // if the value for HasSelectedNoteControl is true
                    if (HasSelectedNoteControl)
                    {
                        // set the return value
                        selectedNoteControlId = SelectedNoteControl.Id;
                    }

                    // return value
                    return selectedNoteControlId;
                }
            }
            #endregion

            #region SelectedNoteId
            /// <summary>
            /// This read only property returrns the NoteId from the SelectedNote exists, else 0 is returned.
            /// </summary>
            public int SelectedNoteId
            {
                get 
                { 
                    // initia value
                    int selectedNoteId = 0;

                    // if the value for HasSelectedNote is true
                    if (HasSelectedNote)
                    {
                        // set the return value
                        selectedNoteId = SelectedNote.Id;
                    }

                    // return value
                    return selectedNoteId;
                }
            }
            #endregion
            
            #region Settings
            /// <summary>
            /// This property gets or sets the value for 'Settings'.
            /// </summary>
            public Setting Settings
            {
                get { return settings; }
                set { settings = value; }
            }
            #endregion
            
            #region SettingsFile
            /// <summary>
            /// This property gets or sets the value for 'SettingsFile'.
            /// </summary>
            public string SettingsFile
            {
                get { return settingsFile; }
                set { settingsFile = value; }
            }
            #endregion
            
            #region XmlFile
            /// <summary>
            /// This property gets or sets the value for 'XmlFile'.
            /// </summary>
            public string XmlFile
            {
                get { return xmlFile; }
                set { xmlFile = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
