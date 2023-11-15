

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralizeService.Core;
using XmlMirror.Enumerations;
using DataJuggler.UltimateHelper;

#endregion

namespace XmlMirror.Util
{

    #region class PluralWordHelper
    /// <summary>
    /// This class uses Nuget packages PluralizationService.Core. (leave it a star here: https://github.com/kanisimoff/PluralizeService.Core)
    /// </summary>
    internal class PluralWordHelper
    {
        
        #region Private Variables
        #endregion
        
        #region Methods
            
            #region GetPlural(string singularWord, TextCaseOptionsEnum textCaseOptions = TextCaseOptionsEnum.Do_Not_Change_Case)
            /// <summary>
            /// method Get Plural
            /// </summary>
            public static string GetPlural(string singularWord, TextCaseOptionsEnum textCaseOptions = TextCaseOptionsEnum.Do_Not_Change_Case)
            {
                // initial value
                string plural = PluralizationProvider.Pluralize(singularWord);

                // if Lowercase
                if (textCaseOptions == TextCaseOptionsEnum.Lower_Case_First_Char)
                {
                    // lower case

                    // Set the first character to lowercase
                    plural = TextHelper.CapitalizeFirstChar(plural, true);
                }                
                else if (textCaseOptions == TextCaseOptionsEnum.Upper_Case_First_Char)
                {
                    // upper case

                    // Set the first character to upper case
                    plural = TextHelper.CapitalizeFirstChar(plural, false);
                }
                
                // return value
                return plural;
            }
            #endregion
            
            #region GetSingular(string pluralWord, TextCaseOptionsEnum textCaseOptions = TextCaseOptionsEnum.Do_Not_Change_Case)
            /// <summary>
            /// method Get Singular
            /// </summary>
            public static string GetSingular(string pluralWord, TextCaseOptionsEnum textCaseOptions = TextCaseOptionsEnum.Do_Not_Change_Case)
            {
                // initial value
                string singular = PluralizationProvider.Pluralize(pluralWord);

                // if Lowercase
                if (textCaseOptions == TextCaseOptionsEnum.Lower_Case_First_Char)
                {
                    // lower case

                    // Set the first character to lowercase
                    singular = TextHelper.CapitalizeFirstChar(singular, true);
                }                
                else if (textCaseOptions == TextCaseOptionsEnum.Upper_Case_First_Char)
                {
                    // upper case

                    // Set the first character to upper case
                    singular = TextHelper.CapitalizeFirstChar(singular, false);
                }
                
                // return value
                return singular;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
