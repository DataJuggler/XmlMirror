

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

#endregion

namespace NoteBoard.Client.Controls
{

    #region class NoteHoverControl
    /// <summary>
    /// This controls displays the Note Description
    /// </summary>
    public partial class NoteHoverControl : UserControl
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'NoteHoverControl' object.
        /// </summary>
        public NoteHoverControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region DisplayNoteDescription(string noteText)
            /// <summary>
            /// This method Displays the Note Description
            /// </summary>
            public void DisplayNoteDescription(string noteText)
            {
                // set the NoteText
                this.NoteDescriptionLabel.Text = noteText;
                this.Visible = true;
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

        #endregion

    }
    #endregion

}
