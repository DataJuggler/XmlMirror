

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteBoard.Model;

using NoteBoard.Client;

#endregion

namespace NoteBoard.Client.Controls
{

    #region class NoteControl
    /// <summary>
    /// This control is used to display a note
    /// </summary>
    public partial class NoteControl : UserControl
    {
        
        #region Private Variables
        private Note note;
        private bool selected;
        private Guid id;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'NoteControl' object.
        /// </summary>
        public NoteControl()
        {
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

                // if the note exists annd the ParentMainForm exists
                if ((HasNote) && (HasParentMainForm))
                {
                    // Show the Hover Control
                    ParentMainForm.ShowHoverControl(this);
                }
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

                // if the note exists annd the ParentMainForm exists
                if (HasParentMainForm)
                {
                    // Show the Hover Control
                    ParentMainForm.HideHoverControl();
                }
            }
            #endregion

            #region DeleteNoteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DeleteNoteButton' is clicked.
            /// </summary>
            private void DeleteNoteButton_Click(object sender, EventArgs e)
            {
                // if the value for HasParentMainForm is true
                if (HasParentMainForm)
                {
                    // Click the Delete button
                    ParentMainForm.ClickDeleteButton();
                }
            }
            #endregion

            #region EditNoteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'EditNoteButton' is clicked.
            /// </summary>
            private void EditNoteButton_Click(object sender, EventArgs e)
            {
                // if the value for HasParentMainForm is true
                if (HasParentMainForm)
                {
                    // click the edit button
                    ParentMainForm.ClickEditButton();
                }
            }
            #endregion

            #region NoteControl_DoubleClick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Note Control _ Double Click
            /// </summary>
            private void NoteControl_DoubleClick(object sender, EventArgs e)
                {
                    // if the value for HasParentMainForm is true
                    if (HasParentMainForm)
                    {
                        // Click the Edit Button
                        ParentMainForm.ClickEditButton();
                    }
                }
                #endregion
            
            #region NoteControl_Selected(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Note Control _ Selected
            /// </summary>
            private void NoteControl_Selected(object sender, EventArgs e)
            {
                // set selected to true
                this.Selected = true;
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region DisplayNote()
            /// <summary>
            /// This method Displays Note
            /// </summary>
            public void DisplayNote()
            {
                // locals
                string title = "";
                
                // If the Note object exists
                if (this.HasNote)
                {
                    // set the title
                    title = Note.Title;
                }
                
                // display the values
                this.TitleLabel.Text = title;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // add new controls 
                this.Dock = DockStyle.Left;

                // Show the Top Panel
                this.EditNoteButton.Visible = false;
                this.DeleteNoteButton.Visible = false;

                // Create a Guid
                this.Id = Guid.NewGuid();

                // Enable controls
                UIControl();
            }
            #endregion
            
            #region UIControl()
            /// <summary>
            /// This method UI Control
            /// </summary>
            public void UIControl()
            {
                // only show the buttons if selected
                this.EditNoteButton.Visible = this.Selected;
                this.DeleteNoteButton.Visible = this.Selected;
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
            
            #region HasParentMainForm
            /// <summary>
            /// This property returns true if this object has a 'ParentMainForm'.
            /// </summary>
            public bool HasParentMainForm
            {
                get
                {
                    // initial value
                    bool hasParentMainForm = (this.ParentMainForm != null);
                    
                    // return value
                    return hasParentMainForm;
                }
            }
            #endregion
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public Guid Id
            {
                get { return id; }
                set { id = value; }
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
                    
                    // Display the note
                    DisplayNote();
                }
            }
            #endregion
            
            #region ParentMainForm
            /// <summary>
            /// This read only property returns the parent form cast as MainForm object.
            /// </summary>
            public MainForm ParentMainForm
            {
                get
                {
                    // initial value
                    MainForm parentForm = this.ParentForm as MainForm;
                    
                    // return value
                    return parentForm;
                }
            }
        #endregion

            #region Selected
            /// <summary>
            /// This property gets or sets the value for 'Selected'.
            /// </summary>
            public bool Selected
            {
                get { return selected; }
                set 
                {
                    // set the value
                    selected = value;

                    // if the value for HasParentMainForm is true
                    if ((HasParentMainForm) && (selected))
                    {
                        // Set this control as the selected control
                        this.ParentMainForm.SelectedNoteControl = this;
                    }

                    // enable controls
                    UIControl();
                }
            }
        #endregion

        #endregion

    }
    #endregion

}
