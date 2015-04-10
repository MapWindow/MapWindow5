using System;
using System.Collections.Generic;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    // at least to prevent adding types that are not suppported
    public interface IDatasource: IComWrapper, IDisposable
    {
        string Filename { get; }

        void Close();

        string OpenDialogFilter { get; }

        LayerType LayerType { get; }

        string ToolTipText { get; }
    }
}
