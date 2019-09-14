

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
using ResponseLibrary;
using System.IO;
using ResponseParserTest.Parsers;

#endregion

namespace ResponseParserTest
{

    #region class MainForm
    /// <summary>
    /// MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Initialize Controls
            InitializeComponent();

            // change the label color
            this.SourceXmlControl.LabelColor = Color.Black;
        }
        #endregion
        
        #region Events
            
            #region ParseXml_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ParseXml' is clicked.
            /// </summary>
            private void ParseXml_Click(object sender, EventArgs e)
            {
                // xml
                string xml = File.ReadAllText(SourceXmlControl.Text);

                // Create a new instance of a 'ResponsesParser' object.
                ResponsesParser parser = new ResponsesParser();
                
                // load the response
                Response response = parser.ParseResponse(xml);

                // if the response object exists
                if (response != null)
                {   
                    // set each property from the response
                    EntityLineNumberControl.Text = response.EntitylineNumber.ToString();
                    EntityUIDControl.Text = response.EntityUID;
                    StatusCodeControl.Text = response.StatusCode;
                    EntityMarkControl.Text = response.EntityMark;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
