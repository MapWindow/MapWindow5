using System;
using System.Windows.Forms;
using BaseComponents.InterFaces.Forms;

namespace BaseComponents.BaseClasses.Forms
{
    public class BaseMainForm : Form, IBaseMainForm
    {
    //    public MapWinControl.MapWinControl MapWinControl { get; set; }

        public ToolStripContainer ContainerToolstrip { get; set; }

        public virtual void MenuButtonClicked(object sender, EventArgs args)
        {
        }

        public virtual void ToolButtonClicked(object sender, EventArgs args)
        {
            
        }

        public virtual void ZoomIn()
        {
            
        }
    }
}
