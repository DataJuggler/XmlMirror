

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlMirror.Runtime6.Objects;
using DataJuggler.Net6;

#endregion

namespace XmlMirror.Util
{

    #region class ObjectLoaderWriter
    /// <summary>
    /// This class is used to create the writer for the type of object that will be loaded.
    /// </summary>
    public class ObjectLoaderWriter : CSharpClassWriter
    {
        
        #region Private Variables
        
        #endregion

        #region Parameterized Constructor(ProjectFileManager fileManager, bool businessObjectPass, IsEnumerationDelegate isEnumerationMethod, GetEnumerationDataTypeDelegate getDataTypeMethod) : base(fileManager, businessObjectPass, isEnumerationMethod, getDataTypeMethod)
        /// <summary>
        /// Create a new instance of an ObjectLoaderWriter
        /// </summary>
        /// <param name="fileManager"></param>
        /// <param name="businessObjectPass"></param>
        /// <param name="isEnumerationMethod"></param>
        /// <param name="getDataTypeMethod"></param>
        public ObjectLoaderWriter(ProjectFileManager fileManager, bool businessObjectPass) : base(fileManager, businessObjectPass)
        {
           
        }
        #endregion

        #region Methods

            #region WriteObjectLoader(Mirror mirror)
            /// <summary>
            /// This method writes out an Object Loader
            /// </summary>
            /// <param name="mirror"></param>
            public void WriteObjectLoader(Mirror mirror)
            {
                
            }
            #endregion
            
        #endregion

        #region Properties

           
            
        #endregion
        
    }
    #endregion

}
