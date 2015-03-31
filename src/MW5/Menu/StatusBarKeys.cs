using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Menu
{
    internal static class StatusBarKeys
    {
        public const string ProjectionDropDown = "statusProjectionDropDown";
        public const string ChooseProjection = "statusChooseProjection";
        public const string ProjectionProperties = "statusProjectionProperties";
        public const string ProjShowLoadingReport = "statusProjectionShowLoadingReport";
        public const string ProjShowWarnings = "statusProjectionShowWarnings";
        public const string AbsenseBehavior = "statusProjectionAbsenseBehavior";
        public const string MismatchBehavior = "statusProjectionMismatchBehavior";
        public const string SelectedCount = "statusSelectedCount";

        public const string AbsenseIgnore = "statusProjAbsenseIgnore";
        public const string AbsenseAssign = "statusProjAbsenseAssign";
        public const string AbsenseSkip = "statusProjAbsenseSkip";

        public const string MismatchIgnore = "statusProjMismatchIgnore";
        public const string MismatchReproject = "statusProjMismatchReproject";
        public const string MismatchSkip = "statusProjMismatchSkip";

        public const string TileProvider = "statusTileProvider";
        public const string ProgressMsg = "statusProgressMsg";
        public const string ProgressBar = "statusProgressBar";
    }
}
