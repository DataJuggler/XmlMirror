

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace NoteBoard
{

    #region class NoteEditorForm
    /// <summary>
    /// This form is used edit notes
    /// </summary>
    public partial class NoteEditorForm : Form, ITextChanged, ISelectedIndexListener
    {
        
        #region Private Variables
        private Note note;
        private bool userCancelled;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'NoteEditorForm' object.
        /// </summary>
        public NoteEditorForm(Note note = null)
        {
            // store the arg
            this.Note = note;

            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
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
            
            #region CancelButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CancelButton' is clicked.
            /// </summary>
            private void CancelButton_Click(object sender, EventArgs e)
            {
                // the user did cancel
                this.UserCancelled = true;

                // close this form
                this.Close();
            }
            #endregion

            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            /// <param name="selectedItem"></param>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // if the value for HasNote is true
                if (HasNote)    
                {
                    // Parse the Priority based upon the selected index
                    this.Note.Priority = ParsePriority(selectedIndex);
                }
            }
            #endregion

            #region OnTextChanged(LabelTextBoxControl sender, string text);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnTextChanged(Control control, string text)
            {
                // set the control as a sender
                LabelTextBoxControl sender = control as LabelTextBoxControl;

                // if the value for HasNote is true
                if ((HasNote) && (NullHelper.Exists(sender)))
                {
                    // determine the action by the name of the control
                    switch (sender.Name)
                    {
                        case "IdControl":

                            // set the value
                            IdControl.Text = text;

                            // required
                            break;

                        case "TitleControl":

                            // Set the Title
                            Note.Title = text;
                        
                            // required
                            break;

                        case "DescriptionControl":

                            // set the Description
                            Note.Description = text;
                        
                            // required
                            break;
                    }
                }
            }
            #endregion
            
            #region SaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'SaveButton' is clicked.
            /// </summary>
            private void SaveButton_Click(object sender, EventArgs e)
            {
                // capture the values from this control
                if (this.HasNote)
                {
                    // set the properties
                    this.Note.Title = this.TitleControl.Text;
                    this.Note.Description = this.DescriptionControl.Text;
                    this.Note.Priority = ParsePriority(PriorityControl.SelectedIndex);

                    // set to false
                    this.UserCancelled = false;

                    // close this form
                    this.Close();
                }
            }
            #endregion

        #endregion

        #region Methods

            #region DisplayNote()
            /// <summary>
            /// This method Displays a Note
            /// </summary>
            public void DisplayNote()
            {
                // initial values
                string title = "";
                string description = "";
                PriorityEnum priority = PriorityEnum.Normal;
                int noteId = 0;
                
                // if the object exists
                if (this.HasNote)
                {
                    // set the values
                    title = Note.Title;
                    description = Note.Description;
                    priority = Note.Priority;
                    noteId = Note.Id;
                }

                // display the values
                this.TitleControl.Text = title;
                this.DescriptionControl.Text = description;
                this.PriorityControl.SelectedIndex = PriorityControl.FindItemIndexByValue(priority.ToString());
                this.IdControl.Text = noteId.ToString();

                // display the note in the Note Editor
                this.Text = "Note Editor - " + noteId;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // wire up the events
                this.IdControl.OnTextChangedListener = this;
                this.TitleControl.OnTextChangedListener = this;
                this.DescriptionControl.OnTextChangedListener = this;
                this.PriorityControl.SelectedIndexListener = this;

                // default to the user did cancel
                this.UserCancelled = true;
            
                // Load the drop down for Priority
                this.PriorityControl.LoadItems(typeof(PriorityEnum));

                // If the Note object does not exist
                if (!this.HasNote)
                {
                    // Create a new instance of a 'Note' object.
                    this.Note = new Note();
                }
            }
            #endregion
            
            #region ParsePriority(int priorirtyIndex)
            /// <summary>
            /// This method returns the Priority
            /// </summary>
            public PriorityEnum ParsePriority(int priorirtyIndex)
            {
                // initial value
                PriorityEnum priority = PriorityEnum.Normal;
                
                // set the value
                switch (priorirtyIndex)
                {
                    case 0:

                        // set the value
                        priority = PriorityEnum.Low;
                        
                        // required
                        break;

                    case 2:

                        // set the value
                        priority = PriorityEnum.High;
                        
                        // required
                        break;
                }

                // return value
                return priority;
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasNote
            /// <summary>
            /// This property returns true if this object has a 'Note'.
            /// </summary>
            public bool HasNote
                {
                    get
                    {
                        // initial value
                        bool hasNote = (this.Note != null);
                    
                        // return value
                        return hasNote;
                    }
                }
                #endregion
            
            #region Note
            /// <summary>
            /// This property gets or sets the value for 'Note'.
            /// </summary>
            public Note Note
            {
                get { return note; }
                set 
                { 
                    // set the value
                    note = value;

                    // if this is not a new note
                    if ((HasNote) && (note.Id > 0))
                    {
                        // Display the note
                        DisplayNote();
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
