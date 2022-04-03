

#region using statements

using XmlMirror.Runtime6.Objects;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime6.Util;

#endregion

namespace XmlMirror.Xml.Parsers
{

    #region class MirrorsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Mirror' objects.
    /// </summary>
    public partial class MirrorsParser : ParserBaseClass
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

            #region Parsing(XmlNode xmlNode, ref Mirror mirror)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="mirror"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref Mirror mirror)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref Mirror mirror)
            /// <summary>
            /// This event is fired AFTER the mirror is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="mirror"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref Mirror mirror)
            {
                // initial value
                bool cancel = false;

                // if the mirror exists
                if (NullHelper.Exists(mirror))
                {
                    // Create a new instance of a 'FieldLinksParser' object.
                    FieldLinksParser fieldLinksParser = new FieldLinksParser();

                    // Parse the FieldLinks (if present)
                    mirror.FieldLinks = fieldLinksParser.ParseFieldLinks(xmlNode);

                    // Create a new instance of a 'FieldsParser' object.
                    FieldsParser fieldsParser = new FieldsParser();

                    // parse the FieldValuePairs (if present)
                    mirror.Fields = fieldsParser.ParseFieldValuePairs(xmlNode);
                }

                // return value
                return cancel;
            }
            #endregion

        #endregion

    }
    #endregion

}
