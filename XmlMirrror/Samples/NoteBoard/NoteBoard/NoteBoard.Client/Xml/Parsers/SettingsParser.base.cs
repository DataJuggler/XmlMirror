

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

        #region Methods

            #region ParseSetting(string settingXmlText)
            /// <summary>
            /// This method is used to parse an object of type 'Setting'.
            /// </summary>
            /// <param name="settingXmlText">The source xml to be parsed.</param>
            /// <returns>An object of type 'Setting'.</returns>
            public Setting ParseSetting(string settingXmlText)
            {
                // initial value
                Setting setting = null;

                // if the sourceXmlText exists
                if (TextHelper.Exists(settingXmlText))
                {
                    // create an instance of the parser
                    XmlParser parser = new XmlParser();

                    // Create the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument(settingXmlText);

                    // If the XmlDoc exists and has a root node.
                    if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                    {
                        // Create a new setting
                        setting = new Setting();

                        // Perform preparsing operations
                        bool cancel = Parsing(this.XmlDoc.RootNode, ref setting);

                        // if the parsing should not be cancelled
                        if (!cancel)
                        {
                            // Parse the 'Setting' object
                            setting = ParseSetting(ref setting, this.XmlDoc.RootNode);

                            // Perform post parsing operations
                            cancel = Parsed(this.XmlDoc.RootNode, ref setting);

                            // if the parsing should be cancelled
                            if (cancel)
                            {
                                // Set the 'setting' object to null
                                setting = null;
                            }
                        }
                    }
                }

                // return value
                return setting;
            }
            #endregion

            #region ParseSetting(ref Setting setting, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse Setting objects.
            /// </summary>
            public Setting ParseSetting(ref Setting setting, XmlNode xmlNode)
            {
                // if the setting object exists and the xmlNode exists
                if ((setting != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Setting.DisableHoverControl":

                            // Set the value for setting.DisableHoverControl
                            setting.DisableHoverControl = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Setting.PromptForDelete":

                            // Set the value for setting.PromptForDelete
                            setting.PromptForDelete = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this Setting
                            setting = ParseSetting(ref setting, childNode);
                        }
                    }
                }

                // return value
                return setting;
            }
            #endregion

        #endregion

    }
    #endregion

}
