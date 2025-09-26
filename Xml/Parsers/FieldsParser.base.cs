

#region using statements

using XmlMirror.Runtime9.Objects;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime9.Util;

#endregion

namespace XmlMirror.Xml.Parsers
{

    #region class FieldsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'FieldValuePair' objects.
    /// </summary>
    public partial class FieldsParser : ParserBaseClass
    {

        #region Methods

            #region LoadFieldValuePairs(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'FieldValuePair' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'FieldValuePair' objects.</returns>
            public List<FieldValuePair> LoadFieldValuePairs(string sourceXmlText)
            {
                // initial value
                List<FieldValuePair> fieldValuePairs = null;

                // if the source text exists
                if (TextHelper.Exists(sourceXmlText))
                {
                    // create an instance of the parser
                    XmlParser parser = new XmlParser();

                    // Create the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument(sourceXmlText);

                    // If the XmlDoc exists and has a root node.
                    if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                    {
                        // parse the fieldValuePairs
                        fieldValuePairs = ParseFieldValuePairs(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return fieldValuePairs;
            }
            #endregion

            #region ParseFieldValuePair(ref FieldValuePair fieldValuePair, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse FieldValuePair objects.
            /// </summary>
            public FieldValuePair ParseFieldValuePair(ref FieldValuePair fieldValuePair, XmlNode xmlNode)
            {
                // if the fieldValuePair object exists and the xmlNode exists
                if ((fieldValuePair != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Mirror.Fields.FieldValuePair.EnumDataTypeName":

                            // Set the value for fieldValuePair.EnumDataTypeName
                            fieldValuePair.EnumDataTypeName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.Fields.FieldValuePair.FieldDataType":

                            // Set the value for fieldValuePair.FieldDataType
                            // Select the default value of this enum fieldValuePair.FieldDataType = EnumHelper.GetEnumValue<XmlMirror.Runtime.Enumerations.DataTypeEnum>(xmlNode.FormattedNodeValue, XmlMirror.Runtime.Enumerations.DataTypeEnum);

                            // required
                            break;

                        case "Mirror.Fields.FieldValuePair.FieldDataTypeString":

                            // Set the value for fieldValuePair.FieldDataTypeString
                            fieldValuePair.FieldDataTypeString = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.Fields.FieldValuePair.FieldName":

                            // Set the value for fieldValuePair.FieldName
                            fieldValuePair.FieldName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.Fields.FieldValuePair.FieldValue":

                            // Set the value for fieldValuePair.FieldValue
                            // fieldValuePair.FieldValue = // this field must be parsed manually.

                            // required
                            break;

                        case "Mirror.Fields.FieldValuePair.IsEnumeration":

                            // Set the value for fieldValuePair.IsEnumeration
                            fieldValuePair.IsEnumeration = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Mirror.Fields.FieldValuePair.Skip":

                            // Set the value for fieldValuePair.Skip
                            fieldValuePair.Skip = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this FieldValuePair
                            fieldValuePair = ParseFieldValuePair(ref fieldValuePair, childNode);
                        }
                    }
                }

                // return value
                return fieldValuePair;
            }
            #endregion

            #region ParseFieldValuePairs(XmlNode xmlNode, List<FieldValuePair> fieldValuePairs = null)
            /// <summary>
            /// This method is used to parse a list of 'FieldValuePair' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'FieldValuePair' objects.</returns>
            public List<FieldValuePair> ParseFieldValuePairs(XmlNode xmlNode, List<FieldValuePair> fieldValuePairs = null)
            {
                // locals
                FieldValuePair fieldValuePair = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Mirror.Fields")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            fieldValuePairs = new List<FieldValuePair>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Mirror.Fields.FieldValuePair") && (fieldValuePairs != null))
                    {
                        // Create a new object
                        fieldValuePair = new FieldValuePair();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref fieldValuePair);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            fieldValuePair = ParseFieldValuePair(ref fieldValuePair, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref fieldValuePair);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            fieldValuePairs.Add(fieldValuePair);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            fieldValuePairs = ParseFieldValuePairs(childNode, fieldValuePairs);
                        }
                    }
                }

                // return value
                return fieldValuePairs;
            }
            #endregion

        #endregion

    }
    #endregion

}
