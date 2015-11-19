using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Api.Legend.Events;
using MW5.Plugins.Identifier.Controls;
using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Identifier.Views
{
    public interface IIdentifierView : IMenuProvider
    {
        IdentifierMode Mode { get; }
        bool ZoomToShape { get; }
        void Clear();
        event Action ModeChanged;
        event Action ItemSelected;
        void UpdateView();
        IdentifierNodeMetadata SelectedItem { get; }
        IEnumerable<IdentifierNodeMetadata> GetLayerItems(int handle);
    }
}
