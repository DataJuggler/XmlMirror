

#region using statements

using XmlMirror.Runtime6.Objects;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime6.Util;

#endregion

namespace XmlMirror.Xml.Parsers
{

    #region class FieldsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'FieldValuePair' objects.
    /// </summary>
    public partial class FieldsParser : ParserBaseClass
    {

        #region Events

            #region Parsing(XmlNode xmlNode)
            /// <summary>
            /// This event is fired BEFORE the collection is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort parsing this collection.

                // return value
                return cancel;
            }
            #endregion

            #region Parsing(XmlNode xmlNode, ref FieldValuePair fieldValuePair)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="fieldValuePair"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref FieldValuePair fieldValuePair)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref FieldValuePair fieldValuePair)
            /// <summary>
            /// This event is fired AFTER the fieldValuePair is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="fieldValuePair"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref FieldValuePair fieldValuePair)
            {
                // initial value
                bool cancel = false;

                // Add any post processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

        #endregion

    }
    #endregion

}
