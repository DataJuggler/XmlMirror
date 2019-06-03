

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace XmlMirror
{

    #region class Program
    /// <summary>
    /// This class is the main entry point for this application
    /// </summary>
    static class Program
    {
        
        #region Private Variables
       
        #endregion
        
        #region Methods
            
            #region Main
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // This must be called before any dialogs (the License IT Trial Form for instance) 
                // are shown or an error is thrown.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                // Create an instance of the mainForm
                MainForm mainForm = new MainForm();
                
                // run the mainForm
                Application.Run(mainForm);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
