using System.ComponentModel.Composition;
using BL.PluginManager;
//using BaseComponents.BaseClasses.Plugins;
using System.Windows.Forms;
//using BasePlugin = PluginInterface.BasePlugin;

namespace PluginDrie
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("PluginName", "DeDerdePlugin")]
    public class Class1 : BasePlugin
    {
        //public override void StartUp(BaseMainForm mainForm)
        //{
        //    MainForm = mainForm;

        //    CreateMenu();
        //    CreateToolbar();
        //}

        protected override void CreateMenu()
        {
            if(MainForm.MainMenuStrip != null)
            {
                MessageBox.Show("Menu clicked");
            }
            else
            {
                MessageBox.Show("Geen menu gevonden");
            }
        }

        protected override void CreateToolbar()
        {
            
        }
    }
}
