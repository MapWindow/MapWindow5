using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BL.Aggregator;
using BL.DataContracts;
using BL.Utilities;
using BaseComponents.BaseClasses.Forms;
using MapWinControl;
using System.Windows.Forms;
using BL.BO;

namespace BL.BusinessLogic
{
    public class ProjectFileSettings
    {
        public static void ReadProjectFile(string projectFile, MapWinControl.MapWinControl mapWinControl, Aggregate aggregator)
        {
            // Read the projectfile
            string projectFileText = File.ReadAllText(projectFile);
            MapWinProject mapWinProject = projectFileText.DeserializeXml<MapWinProject>();

            // Add the layers from the projectfile
            AddLayers(mapWinProject, mapWinControl, projectFile, aggregator);

            LoadPlugins(mapWinProject, aggregator);
        }

        private static void LoadPlugins(MapWinProject mapWinProject, Aggregate aggregator)
        {
            foreach (var plugin in mapWinProject.MapWindow.Plugins)
            {
                aggregator.PluginFactory.CreatePlugin(plugin.Key, aggregator);
            }  
        }

        public static void SaveProjectFile(Aggregate aggregator, MapWinControl.MapWinControl mapWinControl, string projectFile)
        {
            MapWinProject mapwinProject = new MapWinProject();
          //  mapwinProject.Name = frmMain.Text.Replace("'", "");
            mapwinProject.Type = "projectfile.2";
            mapwinProject.Version = "4.8.5";

            // Get the mapstate from the ocx
            string state = mapWinControl.LoadMapState(true, Path.GetDirectoryName(projectFile));
            mapwinProject.MapwinGis = state.DeserializeXml<MapWinProject.MapWinGIS>();

            // Fill the mapwindos projectSettings
            string mapwindow = FillMapwindowSettings(aggregator);

            mapwinProject.MapWindow = mapwindow.DeserializeXml<MapWinProject.MapWindow4>();

            string prjSetting = mapwinProject.SerializeXml<MapWinProject>();

            using (StreamWriter outfile = new StreamWriter(projectFile))
            {
                // Save settings to file
                outfile.Write(prjSetting);
            }

        }

        public static void SaveProjectFile(BaseMainForm frmMain, MapWinControl.MapWinControl mapWinControl, string projectFile)
        {
            //frmMain.ContainerToolstrip
            // welke menu's zijn actief????



            //// Todo setting zoals version uit een settingfile oid halen

            //MapWinProject mapwinProject = new MapWinProject();
            //mapwinProject.Name = frmMain.Text.Replace("'", "");
            //mapwinProject.Type = "projectfile.2";
            //mapwinProject.Version = "4.8.5";

            //// Get the mapstate from the ocx
            //string state = mapWinControl.LoadMapState(true, Path.GetDirectoryName(projectFile));
            //mapwinProject.MapwinGis = state.DeserializeXml<MapWinProject.MapWinGIS>();

            //// Fill the mapwindos projectSettings
            //string mapwindow = FillMapwindowSettings();

            //mapwinProject.MapWindow = mapwindow.DeserializeXml<MapWinProject.MapWindow4>();
            

            //// Serialize the settings
            //string prjSetting = mapwinProject.SerializeXml<MapWinProject>();

            //// TODO nog even opslaan als een nieuw bestand.
            //using (StreamWriter outfile = new StreamWriter(projectFile))
            //{
            //    // Save settings to file
            //    outfile.Write(prjSetting);
            //}
        }

        private static string FillMapwindowSettings( Aggregate aggregator)
        {
            // TODO deze functie vult even tijdelijk wat gegevens in, maar moet in een later stadium vervangen worden met de echte gegevens
            string projectFileText = File.ReadAllText(@"C:\Dev\SampleData\Newton\Newton.mwprj");
            MapWinProject mapWinProject = projectFileText.DeserializeXml<MapWinProject>();

            mapWinProject.MapWindow.Plugins = new List<MapWinProject.Plugin>();

            // TODO PM 9/4/2013: ActivePlugins is always null.
            if (aggregator.PluginFactory.ActivePlugins != null)
            {
                foreach (var plugin in aggregator.PluginFactory.ActivePlugins)
                {
                    MapWinProject.Plugin filePlugin = new MapWinProject.Plugin();
                    filePlugin.Key = plugin;

                    mapWinProject.MapWindow.Plugins.Add(filePlugin);
                }
            }

            return mapWinProject.MapWindow.SerializeXml<MapWinProject.MapWindow4>();
        }

        private static void AddLayers(MapWinProject mapWinProject, MapWinControl.MapWinControl mapWinControl, string projectFile, Aggregate aggregator)
        {
            // List met layers aanmaken
            // layers met alle data vullen
            // groups ophalen
            // layers toevoegen met de group erbij


            List<Layer> layers = new List<Layer>(); 

            
            // check if there are layers in the projectfile
            if(mapWinProject.MapwinGis.Layers != null)
            {
                // Loop through all layers
                foreach (var prjLayer in mapWinProject.MapwinGis.Layers)
                {
                    // Skip layer if the path to the layer does not exist in the projectfile
                    if (prjLayer.Filename != string.Empty)
                    {
                        
                        // Add layer to ocx
                        int handle = LayerLogic.AddLayer(Path.GetFullPath(prjLayer.Filename), ZoomMode.ZoomToExtents, false, aggregator);

                        if (handle != -1)
                        {
                            // Create the layer-object and add it to the temporary list of layers
                            Layer layer = LayerLogic.FillMapWingisLayerData(handle, prjLayer);
                            layers.Add(layer);
                         //   aggregator.Layers.Add(layer);

                            // Restore the state of the layer
                            RestoreLayerState(mapWinControl, prjLayer, handle);
                        }

                    }
                }

                // Restore the state of the map
                RestoreMapState(mapWinProject, mapWinControl, projectFile);

                // Fill data from the mapwindow-section
                FillMapWindowData(mapWinProject, aggregator, layers);

                //// Add the layers to a group
                //AddLayerToGroup(aggregator, layers);

                // Give aggregator signal that layer has been added
                aggregator.LayerAdded();
            }
        }

        //private static void AddLayerToGroup(Aggregate aggregator, List<Layer> layers)
        //{
        //    // Add layers to the groups
        //    foreach (Layer layer in layers)
        //    {
        //        Group group = null;

        //        if (aggregator.Groups != null)
        //        {
        //            // Try to find the group for the layer
        //            group = aggregator.Groups.FirstOrDefault(elm => elm.Name == layer.GroupName);
        //        }

        //        if (group == null)
        //        {
        //            // Group does not exist, create a new group
        //            LayerLogic.AssignLayerToDefaultGroup(aggregator,layer);
        //        }
        //        else
        //        {
        //            // Add layer to the existing group
        //            group.AddLayer(layer);
        //        }                
        //    }
        //}

        private static void FillMapWindowData(MapWinProject mapWinProject, Aggregate aggregator, List<Layer> layers)
        {
            if (mapWinProject.MapWindow != null && mapWinProject.MapWindow.Layers != null &&
                mapWinProject.MapWindow.Layers.Count == mapWinProject.MapwinGis.Layers.Count)
            {
                List<Group> groups = new List<Group>();

                // Add Groups
                foreach (MapWinProject.Group prjGroup in mapWinProject.MapWindow.Groups)
                {
                    Group group = LayerLogic.LoadGroupDataFromProjectFile(prjGroup);
                    groups.Add(group);
                }

                // Add layers
                foreach (MapWinProject.LayerMapWin4 prjLayer in mapWinProject.MapWindow.Layers)
                {
                    Layer layer = LayerLogic.LoadLayerDataFromProjectFile(prjLayer, layers);

                    Group group = groups.FirstOrDefault(elm => elm.Name == prjLayer.GroupName);
                    if(layer == null)
                    {
                        throw new Exception("Error loading layer");
                    }
                    else if(group == null)
                    {
                        aggregator.CollectionLayer.Add(layer);
                    }
                    else
                    {
                        aggregator.CollectionLayer.Add(layer,group);
                    }
                }
            }
        }

        private static void RestoreMapState(MapWinProject mapWinProject, MapWinControl.MapWinControl mapWinControl, string projectFile)
        {
            string aap = mapWinProject.MapwinGis.SerializeXml<MapWinProject.MapWinGIS>();
            aap = aap.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n", "");

            if (!mapWinControl.RestoreMapState(aap, false, Path.GetFullPath(projectFile)))
            {
                MessageBox.Show("Error restoring mapstate.");
            }
        }

        private static void RestoreLayerState(MapWinControl.MapWinControl mapWinControl, MapWinProject.Layer layer, int handle)
        {
            if (handle != -1)
            {
                string layerState = layer.SerializeXml<MapWinProject.Layer>();

                // Restore the layerstate
                bool result = mapWinControl.RestorLayerState(handle, layerState);

                if (!result)
                {
                    MessageBox.Show("Error restoring layerstate");
                }
            }
        }
    }
}
