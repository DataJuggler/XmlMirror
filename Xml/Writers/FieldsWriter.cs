

#region using statements

using XmlMirror.Runtime9.Objects;
using System;
using System.Collections.Generic;
using DataJuggler.UltimateHelper;
using System.Text;

#endregion

namespace XmlMirror.Xml.Writers
{

    #region class FieldsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'FieldValuePair' objects to xml.
    /// </summary>
    public class FieldsWriter
    {

        #region Methods

            #region ExportList(List<FieldValuePair> fields, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'FieldValuePair' objects to xml
            // </Summary>
            public string ExportList(List<FieldValuePair> fields, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string fieldsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open FieldValuePair Node
                sb.Append("<Fields>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more FieldValuePair objects
                if ((fields != null) && (fields.Count > 0))
                {
                    // Iterate the fields collection
                    foreach (FieldValuePair fieldValuePair  in fields)
                    {
                        // Get the xml for this fields
                        fieldsXml = ExportFieldValuePair(fieldValuePair, indent + 2);

                        // If the fieldsXml string exists
                        if (TextHelper.Exists(fieldsXml))
                        {
                            // Add this fields to the xml
                            sb.Append(fieldsXml);
                        }
                    }
                }

                // Add the close FieldsWriter Node
                sb.Append(indentString);
                sb.Append("</Fields>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportFieldValuePair(FieldValuePair fieldValuePair, int indent = 0)
            // <Summary>
            // This method is used to export a FieldValuePair object to xml.
            // </Summary>
            public string ExportFieldValuePair(FieldValuePair fieldValuePair, int indent = 0)
            {
                // initial value
                string fieldValuePairXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the fieldValuePair object exists
                if (NullHelper.Exists(fieldValuePair))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open fieldValuePair node
                    sb.Append("<FieldValuePair>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for EnumDataTypeName

                    sb.Append(indentString2);
                    sb.Append("<EnumDataTypeName>" + fieldValuePair.EnumDataTypeName + "</EnumDataTypeName>" + Environment.NewLine);

                    // Write out the value for FieldDataType

                    sb.Append(indentString2);
                    sb.Append("<FieldDataType>" + fieldValuePair.FieldDataType + "</FieldDataType>" + Environment.NewLine);

                    // Write out the value for FieldDataTypeString

                    sb.Append(indentString2);
                    sb.Append("<FieldDataTypeString>" + fieldValuePair.FieldDataTypeString + "</FieldDataTypeString>" + Environment.NewLine);

                    // Write out the value for FieldName

                    sb.Append(indentString2);
                    sb.Append("<FieldName>" + fieldValuePair.FieldName + "</FieldName>" + Environment.NewLine);

                    // Write out the value for FieldValue

                    sb.Append(indentString2);
                    sb.Append("<FieldValue>" + fieldValuePair.FieldValue + "</FieldValue>" + Environment.NewLine);

                    // Write out the value for IsEnumeration

                    sb.Append(indentString2);
                    sb.Append("<IsEnumeration>" + fieldValuePair.IsEnumeration + "</IsEnumeration>" + Environment.NewLine);

                    // Write out the value for Skip

                    sb.Append(indentString2);
                    sb.Append("<Skip>" + fieldValuePair.Skip + "</Skip>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close fieldValuePair node
                    sb.Append("</FieldValuePair>" + Environment.NewLine);

                    // set the return value
                    fieldValuePairXml = sb.ToString();
                }
                // return value
                return fieldValuePairXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
