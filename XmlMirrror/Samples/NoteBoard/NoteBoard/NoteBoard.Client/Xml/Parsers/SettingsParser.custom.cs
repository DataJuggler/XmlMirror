

#region using statements

using NoteBoard.Model;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;

#endregion

namespace NoteBoard.Xml.Parsers
{

    #region class SettingsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Setting' objects.
    /// </summary>
    public partial class SettingsParser : ParserBaseClass
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

            #region Parsing(XmlNode xmlNode, ref Setting setting)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="setting"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref Setting setting)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref Setting setting)
            /// <summary>
            /// This event is fired AFTER the setting is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="setting"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref Setting setting)
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
