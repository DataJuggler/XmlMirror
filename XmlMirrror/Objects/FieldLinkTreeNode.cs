

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlMirror.Runtime.Objects;

#endregion

namespace XmlMirror.Objects
{

    #region class FieldLinkTreeNode
    /// <summary>
    /// This 
    /// </summary>
    public class FieldLinkTreeNode : TreeNode
    {
        
        #region Private Variables
        private XmlNode sourceNode;
        private FieldLink fieldLink;
        private object tag;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a FieldLinkTextBox
        /// </summary>
        /// <param name="sourceNode"></param>
        /// <param name="fieldLink"></param>
        public FieldLinkTreeNode(XmlNode sourceNode, FieldLink fieldLink)
        {
            // store the values
            this.SourceNode = sourceNode;
            this.FieldLink = fieldLink;

            // if both objects exist
            if ((this.HasSourceNode) && (this.HasFieldLink))
            {
                // change the text
                this.Text = this.FieldLink.TargetFieldName + " :: " + this.FieldLink.SourceFieldName;
            }
        }
        #endregion

        #region Properties

            #region FieldLink
            /// <summary>
            /// This property gets or sets the value for 'FieldLink'.
            /// </summary>
            public FieldLink FieldLink
            {
                get { return fieldLink; }
                set { fieldLink = value; }
            }
            #endregion
            
            #region HasFieldLink
            /// <summary>
            /// This property returns true if this object has a 'FieldLink'.
            /// </summary>
            public bool HasFieldLink
            {
                get
                {
                    // initial value
                    bool hasFieldLink = (this.FieldLink != null);
                    
                    // return value
                    return hasFieldLink;
                }
            }
            #endregion
            
            #region HasSourceNode
            /// <summary>
            /// This property returns true if this object has a 'SourceNode'.
            /// </summary>
            public bool HasSourceNode
            {
                get
                {
                    // initial value
                    bool hasSourceNode = (this.SourceNode != null);
                    
                    // return value
                    return hasSourceNode;
                }
            }
            #endregion
            
            #region SourceNode
            /// <summary>
            /// This property gets or sets the value for 'SourceNode'.
            /// </summary>
            public XmlNode SourceNode
            {
                get { return sourceNode; }
                set { sourceNode = value; }
            }
            #endregion
            
            #region Tag
            /// <summary>
            /// This property gets or sets the value for 'Tag'.
            /// </summary>
            public new object Tag
            {
                get { return tag; }
                set { tag = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
