using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlMirror.Enumerations
{

    #region TextCaseOptionsEnum : int
    /// <summary>
    /// This enum is used with the PluralizationHelper to deteremine if you want to change the case or no
    /// </summary>
    public enum TextCaseOptionsEnum : int
    { 
        Do_Not_Change_Case = 0,
        Upper_Case_First_Char = 1,
        Lower_Case_First_Char = 2
    }
    #endregion

}
