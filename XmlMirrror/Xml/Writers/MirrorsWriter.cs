

#region using statements

using XmlMirror.Runtime.Objects;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Util;
using System.Text;

#endregion

namespace XmlMirror.Xml.Writers
{

    #region class MirrorsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Mirror' objects to xml.
    /// </summary>
    public class MirrorsWriter
    {

        #region Methods

            #region ExportList(List<Mirror> mirrors, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Mirror' objects to xml
            // </Summary>
            public string ExportList(List<Mirror> mirrors, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string mirrorsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Mirror Node
                sb.Append("<Mirrors>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Mirror objects
                if ((mirrors != null) && (mirrors.Count > 0))
                {
                    // Iterate the mirrors collection
                    foreach (Mirror mirror  in mirrors)
                    {
                        // Get the xml for this mirrors
                        mirrorsXml = ExportMirror(mirror, indent + 2);

                        // If the mirrorsXml string exists
                        if (TextHelper.Exists(mirrorsXml))
                        {
                            // Add this mirrors to the xml
                            sb.Append(mirrorsXml);
                        }
                    }
                }

                // Add the close MirrorsWriter Node
                sb.Append(indentString);
                sb.Append("</Mirrors>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportMirror(Mirror mirror, int indent = 0)
            // <Summary>
            // This method is used to export a Mirror object to xml.
            // </Summary>
            public string ExportMirror(Mirror mirror, int indent = 0)
            {
                // initial value
                string mirrorXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the mirror object exists
                if (NullHelper.Exists(mirror))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open mirror node
                    sb.Append("<Mirror>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for ClassName

                    sb.Append(indentString2);
                    sb.Append("<ClassName>" + mirror.ClassName + "</ClassName>" + Environment.NewLine);

                    // Write out the value for CollectionNodeName

                    sb.Append(indentString2);
                    sb.Append("<CollectionNodeName>" + mirror.CollectionNodeName + "</CollectionNodeName>" + Environment.NewLine);

                    // Write out the value for FieldLinks

                    // Create the FieldLinksWriter
                    FieldLinksWriter fieldLinksWriter = new FieldLinksWriter();

                    // Export the FieldLinks collection to xml
                    string fieldLinkXml = fieldLinksWriter.ExportList(mirror.FieldLinks, indent + 2);
                    sb.Append(fieldLinkXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for Fields

                    // Create the FieldsWriter
                    FieldsWriter fieldsWriter = new FieldsWriter();

                    // Export the Fields collection to xml
                    string fieldValuePairXml = fieldsWriter.ExportList(mirror.Fields, indent + 2);
                    sb.Append(fieldValuePairXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for MirrorType

                    sb.Append(indentString2);
                    sb.Append("<MirrorType>" + mirror.MirrorType + "</MirrorType>" + Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + mirror.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for Namespace

                    sb.Append(indentString2);
                    sb.Append("<Namespace>" + mirror.Namespace + "</Namespace>" + Environment.NewLine);

                    // Write out the value for NewObjectNodeName

                    sb.Append(indentString2);
                    sb.Append("<NewObjectNodeName>" + mirror.NewObjectNodeName + "</NewObjectNodeName>" + Environment.NewLine);

                    // Write out the value for OutputFolderPath

                    sb.Append(indentString2);
                    sb.Append("<OutputFolderPath>" + mirror.OutputFolderPath + "</OutputFolderPath>" + Environment.NewLine);

                    // Write out the value for OutputType

                    sb.Append(indentString2);
                    sb.Append("<OutputType>" + mirror.OutputType + "</OutputType>" + Environment.NewLine);

                    // Write out the value for SourceXmlFilePath

                    sb.Append(indentString2);
                    sb.Append("<SourceXmlFilePath>" + mirror.SourceXmlFilePath + "</SourceXmlFilePath>" + Environment.NewLine);

                    // Write out the value for TargetClassName

                    sb.Append(indentString2);
                    sb.Append("<TargetClassName>" + mirror.TargetClassName + "</TargetClassName>" + Environment.NewLine);

                    // Write out the value for TargetObjectFilePath

                    sb.Append(indentString2);
                    sb.Append("<TargetObjectFilePath>" + mirror.TargetObjectFilePath + "</TargetObjectFilePath>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close mirror node
                    sb.Append("</Mirror>" + Environment.NewLine);

                    // set the return value
                    mirrorXml = sb.ToString();
                }
                // return value
                return mirrorXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
