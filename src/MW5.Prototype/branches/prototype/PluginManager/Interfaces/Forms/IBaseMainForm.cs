using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using BaseComponents.BaseClasses.Plugins;

namespace BaseComponents.InterFaces.Forms
{
    public interface IBaseMainForm 
    {
       // MapWinControl.MapWinControl MapWinControl { get; set; }

        ToolStripContainer ContainerToolstrip { get; set; }

        void MenuButtonClicked(object sender, EventArgs args);

        void ToolButtonClicked(object sender, EventArgs args);

        void ZoomIn();
    }
}
