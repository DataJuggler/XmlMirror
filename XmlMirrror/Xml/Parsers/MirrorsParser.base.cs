

#region using statements

using XmlMirror.Runtime.Objects;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Util;

#endregion

namespace XmlMirror.Xml.Parsers
{

    #region class MirrorsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Mirror' objects.
    /// </summary>
    public partial class MirrorsParser : ParserBaseClass
    {

        #region Methods

            #region ParseMirror(string mirrorXmlText)
            /// <summary>
            /// This method is used to parse an object of type 'Mirror'.
            /// </summary>
            /// <param name="mirrorXmlText">The source xml to be parsed.</param>
            /// <returns>An object of type 'Mirror'.</returns>
            public Mirror ParseMirror(string mirrorXmlText)
            {
                // initial value
                Mirror mirror = null;

                // if the sourceXmlText exists
                if (TextHelper.Exists(mirrorXmlText))
                {
                    // create an instance of the parser
                    XmlParser parser = new XmlParser();

                    // Create the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument(mirrorXmlText);

                    // If the XmlDoc exists and has a root node.
                    if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                    {
                        // Create a new mirror
                        mirror = new Mirror();

                        // Perform preparsing operations
                        bool cancel = Parsing(this.XmlDoc.RootNode, ref mirror);

                        // if the parsing should not be cancelled
                        if (!cancel)
                        {
                            // Parse the 'Mirror' object
                            mirror = ParseMirror(ref mirror, this.XmlDoc.RootNode);

                            // Perform post parsing operations
                            cancel = Parsed(this.XmlDoc.RootNode, ref mirror);

                            // if the parsing should be cancelled
                            if (cancel)
                            {
                                // Set the 'mirror' object to null
                                mirror = null;
                            }
                        }
                    }
                }

                // return value
                return mirror;
            }
            #endregion

            #region ParseMirror(ref Mirror mirror, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse Mirror objects.
            /// </summary>
            public Mirror ParseMirror(ref Mirror mirror, XmlNode xmlNode)
            {
                // if the mirror object exists and the xmlNode exists
                if ((mirror != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Mirror.ClassName":

                            // Set the value for mirror.ClassName
                            mirror.ClassName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.CollectionNodeName":

                            // Set the value for mirror.CollectionNodeName
                            mirror.CollectionNodeName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.MirrorType":

                            // Set the value for mirror.MirrorType
                            mirror.MirrorType = EnumHelper.GetEnumValue<XmlMirror.Runtime.Enumerations.MirrorTypeEnum>(xmlNode.FormattedNodeValue, XmlMirror.Runtime.Enumerations.MirrorTypeEnum.Unknown);

                            // required
                            break;

                        case "Mirror.Name":

                            // Set the value for mirror.Name
                            mirror.Name = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.Namespace":

                            // Set the value for mirror.Namespace
                            mirror.Namespace = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.NewObjectNodeName":

                            // Set the value for mirror.NewObjectNodeName
                            mirror.NewObjectNodeName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.OutputFolderPath":

                            // Set the value for mirror.OutputFolderPath
                            mirror.OutputFolderPath = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.OutputType":

                            // Set the value for mirror.OutputFolderPath
                            mirror.OutputType = EnumHelper.GetEnumValue<XmlMirror.Runtime.Enumerations.OutputTypeEnum>(xmlNode.FormattedNodeValue, XmlMirror.Runtime.Enumerations.OutputTypeEnum.Unknown);

                            // required
                            break;

                        case "Mirror.SourceXmlFilePath":

                            // Set the value for mirror.SourceXmlFilePath
                            mirror.SourceXmlFilePath = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.TargetClassName":

                            // Set the value for mirror.TargetClassName
                            mirror.TargetClassName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Mirror.TargetObjectFilePath":

                            // Set the value for mirror.TargetObjectFilePath
                            mirror.TargetObjectFilePath = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this Mirror
                            mirror = ParseMirror(ref mirror, childNode);
                        }
                    }
                }

                // return value
                return mirror;
            }
            #endregion

        #endregion

    }
    #endregion

}
