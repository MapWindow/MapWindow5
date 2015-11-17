using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Views.Abstract
{
    internal interface IGeoLocationView: IView
    {
        string LocationQuery { get; }

        KnownExtents KnownExtents { get; }

        bool UseGeoLocation { get; }

        event Action Search;

        void SetInputFocus();
    }
}
