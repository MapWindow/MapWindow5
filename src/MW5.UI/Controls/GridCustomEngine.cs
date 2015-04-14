using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.UI.Controls
{
    /// <summary>
    /// GroupingEngineFactory provides GroupingRecordRow elements that
    /// support saving row heights.
    /// </summary>
    public class GroupingEngineFactory : GridEngineFactoryBase
    {
        // Add this line in your forms ctor:
        // GroupingEngineFactory provides a modified GridChildTable that adds an extra section
        // GridEngineFactory.Factory = new GroupingEngineFactory();

        public override GridEngine CreateEngine()
        {
            return new GroupingEngine();
        }
    }

    public class GroupingEngine : GridEngine
    {
        public override RecordRow CreateRecordRow(RecordRowsPart parent)
        {
            return new GroupingRecordRow(parent);
        }

        public override CaptionRow CreateCaptionRow(CaptionSection parent)
        {
            return new GroupingCaptionRow(parent);
        }

        public override ColumnHeaderRow CreateColumnHeaderRow(ColumnHeaderSection parent)
        {
            return new GroupingColumnHeaderRow(parent);
        }

        // same pattern can be used for:
        // FilterBarRow CreateFilterBarRow(FilterBarSection parent)
        // GroupFooterSection CreateGroupFooterSection(Group parent)
        // GroupHeaderSection CreateGroupHeaderSection(Group parent)
        // RecordPreviewRow CreateRecordPreviewRow(RecordPreviewRowsPart parent)
    }

    public class GroupingRecordRow : GridRecordRow, IGridRowHeight
    {
        int rowHeight = -1;

        /// <summary>
        /// Initializes a new object in the specifed record part.
        /// </summary>
        /// <param name="parent">The parent element.</param>
        public GroupingRecordRow(RecordRowsPart parent)
            : base(parent)
        {
        }
        #region IGridRowHeight Members

        /// <summary>
        /// Determines if elements supports storing row heights 
        /// </summary>
        /// <returns></returns>
        public bool SupportsRowHeight()
        {
            return true;
        }

        /// <summary>
        /// The row height 
        /// </summary>
        public int RowHeight
        {
            get
            {
                return rowHeight;
            }
            set
            {
                if (rowHeight != value)
                {
                    rowHeight = value;
                    this.InvalidateCounterBottomUp();
                }
            }
        }

        /// <summary>
        /// Checks if row height was modified or if default setting should be used.
        /// </summary>
        public bool HasRowHeight
        {
            get
            {
                return rowHeight != -1;
            }
        }

        #endregion

        /// <summary>
        /// This is where the row height then gets integrated with the engine
        /// YAmount Counter logic.
        /// </summary>
        /// <returns></returns>
        public override double GetYAmountCount()
        {
            // Note: whenever the value that is returned by GetYAmountCount changes
            // make sure you call InvalidateCounterBottomUp so that the engine
            // is aware of the change and counters are recalculated. See
            // the RowHeight setter. 
            return rowHeight != -1 ? rowHeight : base.GetYAmountCount();
        }

    }


    public class GroupingCaptionRow : GridCaptionRow, IGridRowHeight
    {
        int rowHeight = -1;

        /// <summary>
        /// Initializes a new object in the specifed record part.
        /// </summary>
        /// <param name="parent">The parent element.</param>
        public GroupingCaptionRow(CaptionSection parent)
            : base(parent)
        {
        }
        #region IGridRowHeight Members

        /// <summary>
        /// Determines if elements supports storing row heights 
        /// </summary>
        /// <returns></returns>
        public bool SupportsRowHeight()
        {
            return true;
        }

        /// <summary>
        /// The row height 
        /// </summary>
        public int RowHeight
        {
            get
            {
                return rowHeight;
            }
            set
            {
                if (rowHeight != value)
                {
                    rowHeight = value;
                    this.InvalidateCounterBottomUp();
                }
            }
        }

        /// <summary>
        /// Checks if row height was modified or if default setting should be used.
        /// </summary>
        public bool HasRowHeight
        {
            get
            {
                return rowHeight != -1;
            }
        }

        #endregion


        /// <summary>
        /// This is where the row height then gets integrated with the engine
        /// YAmount Counter logic.
        /// </summary>
        /// <returns></returns>
        public override double GetYAmountCount()
        {
            // Note: whenever the value that is returned by GetYAmountCount changes
            // make sure you call InvalidateCounterBottomUp so that the engine
            // is aware of the change and counters are recalculated. See
            // the RowHeight setter. 
            return rowHeight != -1 ? rowHeight : base.GetYAmountCount();
        }

    }


    public class GroupingColumnHeaderRow : GridColumnHeaderRow, IGridRowHeight
    {
        int rowHeight = -1;

        /// <summary>
        /// Initializes a new object in the specifed record part.
        /// </summary>
        /// <param name="parent">The parent element.</param>
        public GroupingColumnHeaderRow(ColumnHeaderSection parent)
            : base(parent)
        {
        }
        #region IGridRowHeight Members

        /// <summary>
        /// Determines if elements supports storing row heights 
        /// </summary>
        /// <returns></returns>
        public bool SupportsRowHeight()
        {
            return true;
        }

        /// <summary>
        /// The row height 
        /// </summary>
        public int RowHeight
        {
            get
            {
                return rowHeight;
            }
            set
            {
                if (rowHeight != value)
                {
                    rowHeight = value;
                    this.InvalidateCounterBottomUp();
                }
            }
        }

        /// <summary>
        /// Checks if row height was modified or if default setting should be used.
        /// </summary>
        public bool HasRowHeight
        {
            get
            {
                return rowHeight != -1;
            }
        }

        #endregion


        /// <summary>
        /// This is where the row height then gets integrated with the engine
        /// YAmount Counter logic.
        /// </summary>
        /// <returns></returns>
        public override double GetYAmountCount()
        {
            // Note: whenever the value that is returned by GetYAmountCount changes
            // make sure you call InvalidateCounterBottomUp so that the engine
            // is aware of the change and counters are recalculated. See
            // the RowHeight setter. 
            return rowHeight != -1 ? rowHeight : base.GetYAmountCount();
        }

    }

}

