

#region using statements

using NoteBoard.Model;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;
using System.Text;

#endregion

namespace NoteBoard.Xml.Writers
{

    #region class SettingsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Setting' objects to xml.
    /// </summary>
    public class SettingsWriter
    {

        #region Methods

            #region ExportList(List<Setting> settings, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Setting' objects to xml
            // </Summary>
            public string ExportList(List<Setting> settings, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string settingsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Setting Node
                sb.Append("<Settings>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Setting objects
                if ((settings != null) && (settings.Count > 0))
                {
                    // Iterate the settings collection
                    foreach (Setting setting  in settings)
                    {
                        // Get the xml for this settings
                        settingsXml = ExportSetting(setting, indent + 2);

                        // If the settingsXml string exists
                        if (TextHelper.Exists(settingsXml))
                        {
                            // Add this settings to the xml
                            sb.Append(settingsXml);
                        }
                    }
                }

                // Add the close SettingsWriter Node
                sb.Append(indentString);
                sb.Append("</Settings>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportSetting(Setting setting, int indent = 0)
            // <Summary>
            // This method is used to export a Setting object to xml.
            // </Summary>
            public string ExportSetting(Setting setting, int indent = 0)
            {
                // initial value
                string settingXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the setting object exists
                if (NullHelper.Exists(setting))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open setting node
                    sb.Append("<Setting>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for DisableHoverControl

                    sb.Append(indentString2);
                    sb.Append("<DisableHoverControl>" + setting.DisableHoverControl + "</DisableHoverControl>" + Environment.NewLine);

                    // Write out the value for PromptForDelete

                    sb.Append(indentString2);
                    sb.Append("<PromptForDelete>" + setting.PromptForDelete + "</PromptForDelete>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close setting node
                    sb.Append("</Setting>" + Environment.NewLine);

                    // set the return value
                    settingXml = sb.ToString();
                }
                // return value
                return settingXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
