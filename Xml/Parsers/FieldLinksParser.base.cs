

#region using statements

using XmlMirror.Runtime9.Objects;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime9.Util;
using XmlMirror.Runtime9.Enumerations;

#endregion

namespace XmlMirror.Xml.Parsers
{

    #region class FieldLinksParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'FieldLink' objects.
    /// </summary>
    public partial class FieldLinksParser : ParserBaseClass
    {

        #region Methods

            #region LoadFieldLinks(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'FieldLink' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'FieldLink' objects.</returns>
            public List<FieldLink> LoadFieldLinks(string sourceXmlText)
            {
                // initial value
                List<FieldLink> fieldLinks = null;

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
                        // parse the fieldLinks
                        fieldLinks = ParseFieldLinks(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return fieldLinks;
            }
            #endregion

            #region ParseFieldLink(ref FieldLink fieldLink, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse FieldLink objects.
            /// </summary>
            public FieldLink ParseFieldLink(ref FieldLink fieldLink, XmlNode xmlNode)
            {
                // if the fieldLink object exists and the xmlNode exists
                if ((fieldLink != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Mirror.FieldLinks.FieldLink.FieldValuePair":

                            // Set the value for fieldLink.FieldValuePair
                            // fieldLink.FieldValuePair = // this field must be parsed manually.

                            // required
                            break;

                        case "Mirror.FieldLinks.FieldLink.ID":

                            // if the FormattedNodeValue exists
                            if (TextHelper.Exists(xmlNode.FormattedNodeValue))
                            {
                                // Create a tempGuid
                                Guid tempGuid = Guid.Empty;

                                // attempt to parse the Guid
                                if (Guid.TryParse(xmlNode.FormattedNodeValue, out tempGuid))
                                {
                                    // Set the value for fieldLink.ID
                                    fieldLink.ID = tempGuid;
                                }
                            }

                            // required
                            break;

                        case "Mirror.FieldLinks.FieldLink.MapType":

                            // Set the value for fieldLink.MapType
                            fieldLink.MapType = EnumHelper.GetEnumValue<MapTypeEnum>(xmlNode.FormattedNodeValue, MapTypeEnum.Unknown);

                            // required
                            break;

                        case "Mirror.FieldLinks.FieldLink.RelationshipType":

                            // Set the value for fieldLink.RelationshipType
                            fieldLink.RelationshipType = EnumHelper.GetEnumValue<InstanceTypeEnum>(xmlNode.FormattedNodeValue, InstanceTypeEnum.Unknown);

                            // required
                            break;

                        case "Mirror.FieldLinks.FieldLink.SourceFieldName":

                            // Set the value for fieldLink.SourceFieldName
                            fieldLink.SourceFieldName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.FieldLinks.FieldLink.TargetDataType":

                            // Set the value for fieldLink.TargetDataType
                            fieldLink.TargetDataType = EnumHelper.GetEnumValue<DataTypeEnum>(xmlNode.FormattedNodeValue, DataTypeEnum.NotSupported);

                            // required
                            break;

                        case "Mirror.FieldLinks.FieldLink.TargetFieldName":

                            // Set the value for fieldLink.TargetFieldName
                            fieldLink.TargetFieldName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this FieldLink
                            fieldLink = ParseFieldLink(ref fieldLink, childNode);
                        }
                    }
                }

                // return value
                return fieldLink;
            }
            #endregion

            #region ParseFieldLinks(XmlNode xmlNode, List<FieldLink> fieldLinks = null)
            /// <summary>
            /// This method is used to parse a list of 'FieldLink' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'FieldLink' objects.</returns>
            public List<FieldLink> ParseFieldLinks(XmlNode xmlNode, List<FieldLink> fieldLinks = null)
            {
                // locals
                FieldLink fieldLink = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Mirror.FieldLinks")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            fieldLinks = new List<FieldLink>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Mirror.FieldLinks.FieldLink") && (fieldLinks != null))
                    {
                        // Create a new object
                        fieldLink = new FieldLink();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref fieldLink);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            fieldLink = ParseFieldLink(ref fieldLink, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref fieldLink);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            fieldLinks.Add(fieldLink);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            fieldLinks = ParseFieldLinks(childNode, fieldLinks);
                        }
                    }
                }

                // return value
                return fieldLinks;
            }
            #endregion

        #endregion

    }
    #endregion

}
