

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.UltimateHelper;

#endregion

namespace XmlMirror
{

    #region class AboutXMLMirror
    /// <summary>
    /// This class is used to show the About Box form
    /// </summary>
    public partial class AboutXMLMirror : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of an XML Mirror
        /// </summary>
        public AboutXMLMirror()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                
            }
            #endregion
            
        #endregion
        
        #region Events
            
            #region OKButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'OKButton' is clicked.
            /// </summary>
            private void OKButton_Click(object sender, EventArgs e)
            {
                // Close this form
                this.Close();
            }
            #endregion
            
            #region OKButton_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when OK Button _ Mouse Enter
            /// </summary>
            private void OKButton_MouseEnter(object sender, EventArgs e)
            {
                // change the cursor to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region OKButton_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when OK Button _ Mouse Leave
            /// </summary>
            private void OKButton_MouseLeave(object sender, EventArgs e)
            {
                // restore the cursor back to normal
                this.Cursor = Cursors.Default;
            }
        #endregion

        #endregion
            
    }
    #endregion

}
