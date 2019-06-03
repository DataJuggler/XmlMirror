

#region using statements

using System;
using System.Collections.Generic;
using System.Drawing;
using NoteBoard.Client.Controls;
using NoteBoard.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NoteBoard.Client.Util
{

    #region class LayoutManager
    /// <summary>
    /// This class is used to keep track of all the controls 
    /// </summary>
    public class LayoutManager
    {
        
        #region Private Variables
        private List<NoteControl> highPriorityItems;
        private List<NoteControl> normalPriorityItems;
        private List<NoteControl> lowPriorityItems;

        // constants
        private const int HighPrioirityRow = 88;
        private const int NormalPrioirityRow = 292;
        private const int LowPrioirityRow = 496;
        private const int LeftStart = 64;
        private const int ControlSpacing = 270;
        #endregion

        #region Constructor()
        /// <summary>
        /// This class is used to keep track of where each control is.
        /// </summary>
        public LayoutManager()
        {
            // create each group
            this.LowPriorityItems = new List<NoteControl>();
            this.NormalPriorityItems = new List<NoteControl>();
            this.HighPriorityItems = new List<NoteControl>();
        }
        #endregion

        #region Methods

            #region Add(NoteControl noteControl, PriorityEnum priority)
            /// <summary>
            /// method returns the
            /// </summary>
            public Point Add(NoteControl noteControl, PriorityEnum priority)
            {
                // initial value
                Point point = new Point(0, 0);
                
                // Determine the action by the priority
                switch (priority)
                {
                    case PriorityEnum.High:
                    
                        // Add this item
                        this.HighPriorityItems.Add(noteControl);

                        // set the x and y
                        point.X = LeftStart + ((HighPriorityItems.Count - 1) * ControlSpacing);
                        point.Y = HighPrioirityRow;
                    
                        // required
                        break;
                    
                    case PriorityEnum.Normal:

                        // Add to NormalPriorityItems
                        NormalPriorityItems.Add(noteControl);

                        // set the x and y
                        point.X = LeftStart + ((NormalPriorityItems.Count - 1) * ControlSpacing);
                        point.Y = NormalPrioirityRow;
                    
                        // required
                        break;
                    
                    case PriorityEnum.Low:
                    
                        // Add to LowPriorityItems
                        LowPriorityItems.Add(noteControl);

                          // set the x and y
                        point.X = LeftStart + ((LowPriorityItems.Count - 1) * ControlSpacing);
                        point.Y = LowPrioirityRow;
                    
                        // required
                        break;
                }
                
                // return value
                return point;
            }
            #endregion

        #endregion

        #region Properties

            #region HighPriorityItems
            /// <summary>
            /// This property gets or sets the value for 'HighPriorityItems'.
            /// </summary>
            public List<NoteControl> HighPriorityItems
            {
                get { return highPriorityItems; }
                set { highPriorityItems = value; }
            }
            #endregion
            
            #region LowPriorityItems
            /// <summary>
            /// This property gets or sets the value for 'LowPriorityItems'.
            /// </summary>
            public List<NoteControl> LowPriorityItems
            {
                get { return lowPriorityItems; }
                set { lowPriorityItems = value; }
            }
            #endregion
            
            #region NormalPriorityItems
            /// <summary>
            /// This property gets or sets the value for 'NormalPriorityItems'.
            /// </summary>
            public List<NoteControl> NormalPriorityItems
            {
                get { return normalPriorityItems; }
                set { normalPriorityItems = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
