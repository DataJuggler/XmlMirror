

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NoteBoard.Model
{

    #region class Note
    /// <summary>
    /// This class represents a note
    /// </summary>
    public class Note
    {
        
        #region Private Variables
        private int id;
        private string title;
        private string description;
        private PriorityEnum priority;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a Note object.
        /// </summary>
        public Note()
        {
            // Default to Normal until a user makes a selection
            Priority = PriorityEnum.Normal;    
        }
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// This method is used to display a little more info about this object.
            /// This is usesful in debugging.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // set the value 
                string returnValue = Title + " " + "Id: " + Id.ToString();

                // return the string
                return returnValue;
            }
            #endregion

        #endregion

        #region Properties

            #region Description
            /// <summary>
            /// This property gets or sets the value for 'Description'.
            /// </summary>
            public string Description
                {
                    get { return description; }
                    set { description = value; }
                }
                #endregion
            
            #region HasDescription
            /// <summary>
            /// This property returns true if the 'Description' exists.
            /// </summary>
            public bool HasDescription
            {
                get
                {
                    // initial value
                    bool hasDescription = (!String.IsNullOrEmpty(this.Description));
                    
                    // return value
                    return hasDescription;
                }
            }
            #endregion
            
            #region HasId
            /// <summary>
            /// This property returns true if the 'Id' is set.
            /// </summary>
            public bool HasId
            {
                get
                {
                    // initial value
                    bool hasId = (this.Id > 0);
                    
                    // return value
                    return hasId;
                }
            }
            #endregion
            
            #region HasTitle
            /// <summary>
            /// This property returns true if the 'Title' exists.
            /// </summary>
            public bool HasTitle
            {
                get
                {
                    // initial value
                    bool hasTitle = (!String.IsNullOrEmpty(this.Title));
                    
                    // return value
                    return hasTitle;
                }
            }
            #endregion
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            #endregion
            
            #region Priority
            /// <summary>
            /// This property gets or sets the value for 'Priority'.
            /// </summary>
            public PriorityEnum Priority
            {
                get { return priority; }
                set { priority = value; }
            }
            #endregion
            
            #region Title
            /// <summary>
            /// This property gets or sets the value for 'Title'.
            /// </summary>
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
