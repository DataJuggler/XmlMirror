

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NoteBoard.Model
{

    public enum PriorityEnum : int
    {
		Low = 1,
		Normal = 2,
		High = 3
	}

    #region UserResponseEnum
    /// <summary>
    /// This enumeration is for the types of responses a user can have from the DialogControl. 
    /// </summary>
    public enum UserResponseEnum : int
    {
        NoResponse = 0,
        Confirmed = 1,
        Cancelled = -1
    }
    #endregion


}
