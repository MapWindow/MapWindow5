using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.BO;
using BL.Interfaces;
using BL.PluginManager;
using BaseComponents.BaseClasses.Forms;
using BaseComponents.InterFaces.Forms;
using MapWinGIS;
using System.Windows.Forms;
using BaseComponents;


namespace BL.Aggregator
{
    public class Aggregate : ICallback
    {
        public List<Group> Groups { get; set; }
        public LayerCollection CollectionLayer { get; set; }
        public ILayerControl LayerControl { get; set; }
        public MapWinControl.MapWinControl MapWin { get; set; }
        public PluginCompositionHelper PluginFactory { get; set; }
        public BaseMainForm MainForm { get; set; }

        List<IMenu> menus = new List<IMenu>();

        public Aggregate()
        {
            PluginFactory = new PluginCompositionHelper();

            CollectionLayer = new LayerCollection();

            //Assembles the components that will participate in composition
            PluginFactory.AssemblePlugins();
        }

        public void LayerAdded()
        {
            if(LayerControl != null)
            {
                LayerControl.AddLayer(CollectionLayer);
            }
        }

        public void AddGroup(Group group)
        {
            if(Groups == null)
            {
                // Create new group
                Groups = new List<Group>();
            }

            // Check if group already exists
            if (Groups.FirstOrDefault(elm => elm.Name == group.Name) == null)
            {
                // Add group to list
                Groups.Add(group);
            }
        }

        public void AddMenu(IMenu menu)
        {
            menus.Add(menu);

            menu.OnButtonClicked += new EventHandler(menu_OnButtonClicked);
        }

        void menu_OnButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AddPluginManager()
        {

        }
    
        public void  Error(string KeyOfSender, string ErrorMsg)
        {
            // MessageBox.Show(ErrorMsg);
            Console.WriteLine(ErrorMsg);
        }

        public void  Progress(string KeyOfSender, int Percent, string Message)
        {
            // TODO: Status-Control hier updates
        }
}
}
