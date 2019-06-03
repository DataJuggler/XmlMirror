

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

    #region class NotesWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Note' objects to xml.
    /// </summary>
    public class NotesWriter
    {

        #region Methods

            #region ExportList(List<Note> notes, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Note' objects to xml
            // </Summary>
            public string ExportList(List<Note> notes, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string notesXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Note Node
                sb.Append("<Notes>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Note objects
                if ((notes != null) && (notes.Count > 0))
                {
                    // Iterate the notes collection
                    foreach (Note note  in notes)
                    {
                        // Get the xml for this notes
                        notesXml = ExportNote(note, indent + 2);

                        // If the notesXml string exists
                        if (TextHelper.Exists(notesXml))
                        {
                            // Add this notes to the xml
                            sb.Append(notesXml);
                        }
                    }
                }

                // Add the close NotesWriter Node
                sb.Append(indentString);
                sb.Append("</Notes>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportNote(Note note, int indent = 0)
            // <Summary>
            // This method is used to export a Note object to xml.
            // </Summary>
            public string ExportNote(Note note, int indent = 0)
            {
                // initial value
                string noteXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the note object exists
                if (NullHelper.Exists(note))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open note node
                    sb.Append("<Note>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for Description

                    sb.Append(indentString2);
                    sb.Append("<Description>" + note.Description + "</Description>" + Environment.NewLine);

                    // Write out the value for HasDescription

                    sb.Append(indentString2);
                    sb.Append("<HasDescription>" + note.HasDescription + "</HasDescription>" + Environment.NewLine);

                    // Write out the value for HasId

                    sb.Append(indentString2);
                    sb.Append("<HasId>" + note.HasId + "</HasId>" + Environment.NewLine);

                    // Write out the value for HasTitle

                    sb.Append(indentString2);
                    sb.Append("<HasTitle>" + note.HasTitle + "</HasTitle>" + Environment.NewLine);

                    // Write out the value for Id

                    sb.Append(indentString2);
                    sb.Append("<Id>" + note.Id + "</Id>" + Environment.NewLine);

                    // Write out the value for Priority

                    sb.Append(indentString2);
                    sb.Append("<Priority>" + note.Priority + "</Priority>" + Environment.NewLine);

                    // Write out the value for Title

                    sb.Append(indentString2);
                    sb.Append("<Title>" + note.Title + "</Title>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close note node
                    sb.Append("</Note>" + Environment.NewLine);

                    // set the return value
                    noteXml = sb.ToString();
                }
                // return value
                return noteXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
