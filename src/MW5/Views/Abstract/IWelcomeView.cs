using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;

namespace MW5.Views.Abstract
{
    public interface IWelcomeView: IView<WelcomeViewModel>
    {
        event Action GettingStartedClicked;
        event Action DocumentsClicked;
        event Action DonateClicked;
        event Action OpenLayerClicked;
        event Action OpenProjectClicked;
        event Action LogoClicked;

        int ProjectId { get; }
    }
}
