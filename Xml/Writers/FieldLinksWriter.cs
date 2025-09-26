

#region using statements

using XmlMirror.Runtime9.Objects;
using System;
using System.Collections.Generic;
using DataJuggler.UltimateHelper;
using System.Text;

#endregion

namespace XmlMirror.Xml.Writers
{

    #region class FieldLinksWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'FieldLink' objects to xml.
    /// </summary>
    public class FieldLinksWriter
    {

        #region Methods

            #region ExportList(List<FieldLink> fieldLinks, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'FieldLink' objects to xml
            // </Summary>
            public string ExportList(List<FieldLink> fieldLinks, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string fieldLinksXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open FieldLink Node
                sb.Append("<FieldLinks>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more FieldLink objects
                if ((fieldLinks != null) && (fieldLinks.Count > 0))
                {
                    // Iterate the fieldLinks collection
                    foreach (FieldLink fieldLink  in fieldLinks)
                    {
                        // Get the xml for this fieldLinks
                        fieldLinksXml = ExportFieldLink(fieldLink, indent + 2);

                        // If the fieldLinksXml string exists
                        if (TextHelper.Exists(fieldLinksXml))
                        {
                            // Add this fieldLinks to the xml
                            sb.Append(fieldLinksXml);
                        }
                    }
                }

                // Add the close FieldLinksWriter Node
                sb.Append(indentString);
                sb.Append("</FieldLinks>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportFieldLink(FieldLink fieldLink, int indent = 0)
            // <Summary>
            // This method is used to export a FieldLink object to xml.
            // </Summary>
            public string ExportFieldLink(FieldLink fieldLink, int indent = 0)
            {
                // initial value
                string fieldLinkXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the fieldLink object exists
                if (NullHelper.Exists(fieldLink))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open fieldLink node
                    sb.Append("<FieldLink>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for FieldValuePair

                    sb.Append(indentString2);
                    sb.Append("<FieldValuePair>" + fieldLink.FieldValuePair + "</FieldValuePair>" + Environment.NewLine);

                    // Write out the value for ID

                    sb.Append(indentString2);
                    sb.Append("<ID>" + fieldLink.ID + "</ID>" + Environment.NewLine);

                    // Write out the value for MapType

                    sb.Append(indentString2);
                    sb.Append("<MapType>" + fieldLink.MapType + "</MapType>" + Environment.NewLine);

                    // Write out the value for RelationshipType

                    sb.Append(indentString2);
                    sb.Append("<RelationshipType>" + fieldLink.RelationshipType + "</RelationshipType>" + Environment.NewLine);

                    // Write out the value for SourceFieldName

                    sb.Append(indentString2);
                    sb.Append("<SourceFieldName>" + fieldLink.SourceFieldName + "</SourceFieldName>" + Environment.NewLine);

                    // Write out the value for TargetDataType

                    sb.Append(indentString2);
                    sb.Append("<TargetDataType>" + fieldLink.TargetDataType + "</TargetDataType>" + Environment.NewLine);

                    // Write out the value for TargetFieldName

                    sb.Append(indentString2);
                    sb.Append("<TargetFieldName>" + fieldLink.TargetFieldName + "</TargetFieldName>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close fieldLink node
                    sb.Append("</FieldLink>" + Environment.NewLine);

                    // set the return value
                    fieldLinkXml = sb.ToString();
                }
                // return value
                return fieldLinkXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
