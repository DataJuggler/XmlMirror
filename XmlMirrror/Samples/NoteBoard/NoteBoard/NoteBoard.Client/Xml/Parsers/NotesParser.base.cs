

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

    #region class NotesParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Note' objects.
    /// </summary>
    public partial class NotesParser : ParserBaseClass
    {

        #region Methods

            #region LoadNotes(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'Note' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'Note' objects.</returns>
            public List<Note> LoadNotes(string sourceXmlText)
            {
                // initial value
                List<Note> notes = null;

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
                        // parse the notes
                        notes = ParseNotes(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return notes;
            }
            #endregion

            #region ParseNote(ref Note note, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse Note objects.
            /// </summary>
            public Note ParseNote(ref Note note, XmlNode xmlNode)
            {
                // if the note object exists and the xmlNode exists
                if ((note != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Notes.Note.Description":

                            // Set the value for note.Description
                            note.Description = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Notes.Note.Id":

                            // Set the value for note.Id
                            note.Id = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Notes.Note.Priority":

                            // Set the value for note.Priority
                            note.Priority = EnumHelper.GetEnumValue<NoteBoard.Model.PriorityEnum>(xmlNode.FormattedNodeValue, NoteBoard.Model.PriorityEnum.Normal);

                            // required
                            break;

                        case "Notes.Note.Title":

                            // Set the value for note.Title
                            note.Title = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this Note
                            note = ParseNote(ref note, childNode);
                        }
                    }
                }

                // return value
                return note;
            }
            #endregion

            #region ParseNotes(XmlNode xmlNode, List<Note> notes = null)
            /// <summary>
            /// This method is used to parse a list of 'Note' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'Note' objects.</returns>
            public List<Note> ParseNotes(XmlNode xmlNode, List<Note> notes = null)
            {
                // locals
                Note note = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Notes")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            notes = new List<Note>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Notes.Note") && (notes != null))
                    {
                        // Create a new object
                        note = new Note();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref note);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            note = ParseNote(ref note, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref note);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            notes.Add(note);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            notes = ParseNotes(childNode, notes);
                        }
                    }
                }

                // return value
                return notes;
            }
            #endregion

        #endregion

    }
    #endregion

}
