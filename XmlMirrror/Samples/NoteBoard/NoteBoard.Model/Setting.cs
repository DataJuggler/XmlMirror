

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NoteBoard.Model
{

    #region class Settings
    /// <summary>
    /// This class is used to keep track of options
    /// </summary>
    public class Setting
    {
        
        #region Private Variables
        private bool promptForDelete;
        private bool disableHoverControl;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a Settings object
        /// </summary>
        public Setting()
        {
            // default to true
            this.PromptForDelete = true;
        }
        #endregion
        
        #region Properties
            
            #region DisableHoverControl
            /// <summary>
            /// This property gets or sets the value for 'DisableHoverControl'.
            /// </summary>
            public bool DisableHoverControl
            {
                get { return disableHoverControl; }
                set { disableHoverControl = value; }
            }
            #endregion
            
            #region PromptForDelete
            /// <summary>
            /// This property gets or sets the value for 'PromptForDelete'.
            /// </summary>
            public bool PromptForDelete
            {
                get { return promptForDelete; }
                set { promptForDelete = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
