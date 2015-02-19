using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapWinControl;
using BL.DataContracts;
using System.IO;
using MapWinGIS;
using System.Windows.Forms;
using BL.Utilities;
using BL.Aggregator;
using BL.BO;

namespace BL.BusinessLogic
{
    public class LayerLogic
    {
        //public static Layer Current
        //{
        //    get
        //    {
        //        // Controleer eerst of currentLayer  null is
        //        // Zoja geef dan de eerste/laatste?? laag terug
        //        return new Layer();
        //    }

        //    set { ; }
        //}

        //public static Layer GetCurrentLayer(List<Group> groups)
        //{
        //    return new Layer();
        //}

        private static void Zoom(Aggregate aggregator, ZoomMode zoomMode, int layerHandle)
        {
            if (zoomMode == ZoomMode.ZoomToExtents)
            {
                // Zoom to maxExtents
                aggregator.MapWin.ZoomToMaxExtents();
            }
            else
            {
                // Zoom to the extents of the given layer
                aggregator.MapWin.ZoomToLayer(layerHandle);
            }
        }


        public static int AddLayer(string filePath, ZoomMode zoomMode, bool addSymbology, Aggregate aggregator)
        {
            int layerHandle = -1;
            
            try
            {
                // Lock the window
                aggregator.MapWin.LockWindow(tkLockMode.lmLock);

                // Get extions of the file
                string extension = Path.GetExtension(filePath);
                
                if (!string.IsNullOrEmpty(extension))
                {
                    // Try to add the layer as a shape
                    layerHandle = ShapefileLogic.AddLayer(aggregator, filePath);

                    if (layerHandle == -1)
                    {
                        // Try to add the layer as an image
                        layerHandle = ImageLogic.AddLayer(aggregator, filePath);
                    }

                    if (layerHandle == -1)
                    {
                        // Try to add the layer as a gird
                        layerHandle = GridLogic.AddLayer(aggregator, filePath);
                    }


                    if (layerHandle != -1)
                    {
                        // Check if symbology has to be added
                        if (addSymbology)
                        {
                            // Add symbology
                            string layerDesc = string.Empty;
                            aggregator.MapWin.LoadLayerOptions(layerHandle, "", ref layerDesc);

                            // Add the layer to the default-group
                            FillLayerAndAddToDefaultGroup(layerHandle, filePath, aggregator);

                            // Signal to aggregator that a layer is added
                            aggregator.LayerAdded();
                        }

                        // Zoom
                        Zoom(aggregator, zoomMode, layerHandle);
                    }
                }
                
                return layerHandle;

            }
            catch (Exception ex)
            {

                throw new Exception("Error adding layer", ex);
            }
            finally
            {
                // Unlock 
                aggregator.MapWin.LockWindow(tkLockMode.lmUnlock);
            }
        }

        private static void FillLayerAndAddToDefaultGroup(int layerHandle, string filePath, Aggregate aggregator)
        {
            // Create Layer-object
            Layer layer = new Layer();
            layer.Handle = layerHandle;
            layer.Filename = Path.GetFileName(filePath);
            layer.LayerVisible = true;
            layer.Name = Path.GetFileName(filePath);

            aggregator.CollectionLayer.Add(layer);

            // Assign the layer to the default group
           // AssignLayerToDefaultGroup(aggregator, layer);
        }

        //public static void AssignLayerToDefaultGroup(Aggregate aggregator, Layer layer)
        //{
        //    Group group = null;

        //    if (aggregator.Groups != null)
        //    {
        //        // Check if group already exists in the group-list
        //        group = aggregator.Groups.FirstOrDefault(elm => elm.Name == Constants.DEFAULT_GROUP);
        //    }

        //    if (group == null)
        //    {
        //        // Create group
        //        group = new Group() { Expanded = true, Name = Constants.DEFAULT_GROUP, Position = 999 };

        //        // add group to list
        //        aggregator.AddGroup(group);
        //    }

        //    // Add layer to group
        //    group.AddLayer(layer);
        //}

        public static Layer FillMapWingisLayerData(int handle, MapWinProject.Layer prjLayer)
        {
            // Set layerName to filename if it does not exist in the projectfile
           // string layerName = prjLayer.LayerName != string.Empty ? prjLayer.LayerName : Path.GetFileName(prjLayer.Filename);

            Layer layer = new Layer();
            layer.Handle = handle;
            layer.Name = prjLayer.LayerName != string.Empty ? prjLayer.LayerName : Path.GetFileName(prjLayer.Filename);
            layer.LayerType = (LayerType)Enum.Parse(typeof(LayerType), prjLayer.LayerType); // (LayerType)prjLayer.LayerType;
            layer.LayerVisible = prjLayer.LayerVisible == "1";
            layer.Position = handle;
            //layer.LayerKey = prjLayer.LayerKey;
            //layer.DynamicVisibility = prjLayer.DynamicVisibility == "1";
            //layer.MinVisibleScale = prjLayer.MinVisibleScale;
            //layer.MaxVisibleScale = prjLayer.MaxVisibleScale;
            //layer.Filename = prjLayer.Filename; // TODO volledige pad invullen????

            return layer;

            //aggregator.AddLayer(layer);
 
        }

        public static Group LoadGroupDataFromProjectFile(MapWinProject.Group prjGroup )
        {

            Group group = new Group();

            group.Name = prjGroup.Name;
            group.Expanded = prjGroup.Expanded == "True";
            group.Position = Convert.ToInt32(prjGroup.Position);
            group.Handle = group.Position;

            return group;
        }


        public static Layer LoadLayerDataFromProjectFile(MapWinProject.LayerMapWin4 prjLayer, List<Layer> layers )
        {
            // Find Layer
            Layer layer = layers.FirstOrDefault(elm => elm.Name == prjLayer.Name);

            if(layer != null)
            {
                // Add data to layer
                layer.PositionInGroup = Convert.ToInt32(prjLayer.PositionInGroup);
            //    layer.GroupName = prjLayer.GroupName;
            }

            return layer;
        }

        public static bool MoveLayer(string destinationNode, string movingNode, Aggregate aggregator)
        {
            // bepaal de layer(s) die verplaatst moeten worden
            List<Layer> movingLayers =  aggregator.CollectionLayer.GetMovingLayers(movingNode);

            List<Layer> beforeMoveLayers = GenericCLone.DeepClone(movingLayers);

            //var before = from x in movingLayers
            //        select new {x.Handle, x.Position};
            
            // Move the layer(s) in the collection
            bool retVal = aggregator.CollectionLayer.Move(destinationNode, movingNode);

            if (retVal)
            {
                movingLayers = aggregator.CollectionLayer.GetMovingLayers(movingNode);
                //var after = from x in movingLayers
                //            select new { x.Handle, x.Position };

                foreach (var layer in beforeMoveLayers)
                {
                    int initialPosition = layer.Position;
                    int targetPosition = movingLayers.First(elm => elm.Handle == layer.Handle).Position;

                    // Move in de ocx
                    aggregator.MapWin.MoveLayer(initialPosition, targetPosition);
                }

                aggregator.LayerAdded();
            }

            return retVal;

            // 12 layers
            // 3 en 4 naar 8 en 9
            //

            //  Group destinationGroup = aggregator.CollectionLayer.GetGroup(destinationNode);

            //  // Find the group to which the layer will be moved
            ////  Group destinationGroup = aggregator.Groups.FirstOrDefault(elm => elm.Name == destinationNode);
            //  if(destinationGroup == null)
            //  {
            //      throw new Exception("Invalid destination group.");
            //  }

            //  var dest = aggregator.CollectionLayer.FirstOrDefault(elm => elm.Name == movingNode);
            //  if (movingNode == null)
            //  {
            //      throw new Exception("Invalid moving layer.");
            //  }


            //// Find the layer which will be moved
            //var moviginLayer = (from grp in aggregator.Groups
            //            from layer in grp.Layers
            //            where layer.Name == movingNode
            //            select layer).FirstOrDefault();

            //if(movingNode == null)
            //{
            //    throw new Exception("Invalid moving layer.");
            //}

            //// Find current group of the layer
            //Group originGroup = aggregator.Groups.FirstOrDefault(elm => elm.Name == originNode);
            //if (originGroup == null)
            //{
            //    throw new Exception("Invalid origin group.");
            //}

            //// Delete layer from the old group and add it to the new group
            //originGroup.Layers.Remove(moviginLayer);
            //destinationGroup.AddLayer(moviginLayer);




        }

        public static void ChangeVisibility(Aggregate aggregate, string itemName, bool isVisible, int handle, MapWinControl.MapWinControl mapWinControl)
        {

            Layer layer =  aggregate.CollectionLayer.FirstOrDefault(elm => elm.Handle == handle);

            //// Find the layer
            //Layer layer = (from grp in aggregate.Groups
            //              from lyr in grp.Layers
            //              where lyr.Handle == handle
            //              select lyr).FirstOrDefault();

            if(layer != null)
            {
               // Change visibility
                mapWinControl.LayerVisible(layer.Handle, isVisible);
            }
            else
            {
                Group group = aggregate.CollectionLayer.GetGroup(itemName);

               // Group group = aggregate.Groups.FirstOrDefault(elm => elm.Name == itemName);
                if (group != null)
                {
                    // 
                }
            }
        }
    }
}
