using System.ComponentModel.Composition;
using System.Linq;
using BL.PluginManager;
using BaseComponents.BaseClasses.Forms;
//using BaseComponents.BaseClasses.Plugins;
using System.Windows.Forms;
//using BasePlugin = PluginInterface.BasePlugin;

namespace ProjectPlugin
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("PluginName", "ProjectPlugin")]
    public class Main : BasePlugin
    {

        //public override void StartUp(BaseMainForm mainForm)
        //{
        //    base.StartUp(mainForm);
        //}

        private const string FILE = "File";
        private const string FILE_OPEN = "FileOpen";
        private const string FILE_CLOSE = "FileClose";
        private const string FILE_TOOLSTRIP = "FileToolStrip";
        private const string FILE_TOOL_OPEN = "FileOpenTool";

        protected override void CreateMenu()
        {
            if (MainForm.MainMenuStrip != null)
            {
                ToolStripMenuItem fileToolStripMenuItem = new ToolStripMenuItem(FILE,null,null,FILE);

                ToolStripItem openToolStripItem = new ToolStripButton("Open", null, MainForm.MenuButtonClicked, FILE_OPEN);
                openToolStripItem.Tag = "ProjectPlugin";
                fileToolStripMenuItem.DropDownItems.Add(openToolStripItem);

                ToolStripItem closeToolStripItem = new ToolStripButton("Close", null, MainForm.MenuButtonClicked, FILE_CLOSE);
                closeToolStripItem.Tag = "ProjectPlugin";
                fileToolStripMenuItem.DropDownItems.Add(closeToolStripItem);

                MainForm.MainMenuStrip.Items.Add(fileToolStripMenuItem);
            }
        }

   
        protected override void CreateToolbar()
        {
            if (MainForm.ContainerToolstrip != null)
            {
                ToolStripButton fileButton = new ToolStripButton("OpenFile", null, MainForm.ToolButtonClicked,
                                                                 FILE_TOOL_OPEN);
                fileButton.Tag = "ProjectPlugin";

                ToolStrip strip;

                Control[] controls = MainForm.ContainerToolstrip.TopToolStripPanel.Controls.Find(FILE_TOOLSTRIP, false);
                if (controls.Any())
                {
                    strip = controls[0] as ToolStrip;
                }
                else
                {
                    strip = new ToolStrip { Dock = DockStyle.Top, Name = FILE_TOOLSTRIP };
                }

                strip.Items.Add(fileButton);
                MainForm.ContainerToolstrip.TopToolStripPanel.Controls.Add(strip);
            }
        }

        protected override void RemoveMenu()
        {
            if (MainForm.MainMenuStrip != null)
            {
                if( MainForm.MainMenuStrip.Items.ContainsKey(FILE))
                {
                    ToolStripMenuItem fileMenuItem = MainForm.MainMenuStrip.Items[FILE] as ToolStripMenuItem;
                    
                    // Remove dropdown-items
                    fileMenuItem.DropDownItems.RemoveByKey(FILE_OPEN);
                    fileMenuItem.DropDownItems.RemoveByKey(FILE_CLOSE);

                    // Remove MenuItem if no dropdownitems exist
                    if (fileMenuItem.DropDownItems.Count == 0)
                    {
                        MainForm.MainMenuStrip.Items.RemoveByKey(FILE);
                    }
                }
            }
        }

        protected override void RemoveToolbar()
        {
            if(MainForm.ContainerToolstrip != null)
            {
                Control[] controls = MainForm.ContainerToolstrip.TopToolStripPanel.Controls.Find(FILE_TOOLSTRIP, false);
                
                if (controls.Any())
                {
                    ToolStrip toolstrip = MainForm.ContainerToolstrip.TopToolStripPanel.Controls[FILE_TOOLSTRIP] as ToolStrip;
                    toolstrip.Items.RemoveByKey(FILE_TOOL_OPEN);

                    if (toolstrip.Controls.Count == 0)
                    {
                        MainForm.ContainerToolstrip.TopToolStripPanel.Controls.RemoveByKey(FILE_TOOLSTRIP);
                    }
                }

            }
        }

        public override void MenuButtonClicked(string menuItem)
        {
            switch (menuItem)
            {
                case  "FileOpen":
                 //   MessageBox.Show("Menu is geclicked in plugin");
                    FileDialog dlg = new OpenFileDialog();
                    dlg.ShowDialog();
                    break;

                case "FileClose":
                    //   MessageBox.Show("Menu is geclicked in plugin");
                    MessageBox.Show("Close");
                    break;
            }
            
        }

        public override void ToolButtonClicked(string toolButtonName, object[] args)
        {

            
            MessageBox.Show("project toolbutton");
        }
    }
}
