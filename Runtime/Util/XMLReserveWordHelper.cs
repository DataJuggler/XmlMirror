

#region using statements

using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace XmlMirror.Runtime8.Util
{

    #region class XMLReserveWordHelper
    /// <summary>
    /// This class is used to do Xml replacement of characters that are now allowed in Xml.
    /// </summary>
    internal class XMLReserveWordHelper
    {
        
        #region Private Variables
        // Source Values
        public const string GreaterThanSymbol = ">";
        public const string LessThanSymbol = "<";
        public const string AmpersandSymbol = "&";
        public const string PercentSymbol = "%";

        // EncodedValues
        public const string GreaterThanCode = "&gt;";
        public const string LessThanCode = "&lt;";
        public const string AmpersandCode = "&amp;";
        public const string PercentCode = "&#37;";
        #endregion

        #region Methods

            #region Decode(string sourceText)
            /// <summary>
            /// returns the
            /// </summary>
            public static string Decode(string sourceText)
            {
                // initial value
                string decodedText = "";

                // If the sourceText string exists
                if (TextHelper.Exists(sourceText))
                {
                    // replace out each string
                    decodedText = sourceText.Replace(GreaterThanCode, GreaterThanSymbol).Replace(LessThanCode, LessThanSymbol).Replace(GreaterThanSymbol, GreaterThanSymbol).Replace(AmpersandCode, AmpersandSymbol);
                }
                
                // return value
                return decodedText;
            }
            #endregion
            
            #region Encode(string sourceText)
            /// <summary>
            /// returns the
            /// </summary>
            public static string Encode(string sourceText)
            {
               // initial value
                string encodedText = "";

                // If the sourceText string exists
                if (TextHelper.Exists(sourceText))
                {
                    // replace out each string
                    encodedText = sourceText.Replace(GreaterThanSymbol, GreaterThanCode).Replace(LessThanSymbol, LessThanCode).Replace(GreaterThanSymbol, GreaterThanCode).Replace(AmpersandSymbol, AmpersandCode);
                }
                
                // return value
                return encodedText;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
