using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MapWinGIS;

namespace MapWinControl
{
    public class MapWinControl : AxMap
    {
        //public MapWinControl(object menu, object pluginmanager)
        public MapWinControl()
        {
            
            // hier de verschillende onderdelen meegeven
            // voor ieder onderdeel en interface maken waar die minimaal aan moet voldoen
           

           // FileDropped += new _DMapEvents_FileDroppedEventHandler(MapWinControl_FileDropped);
        }

        //void MapWinControl_FileDropped(object sender, _DMapEvents_FileDroppedEvent e)
        //{
        //    this.LockWindow(tkLockMode.lmLock);
            
           

        //    // shp, 
        //   // MessageBox.Show(e.filename);

        //    string extension = Path.GetExtension(e.filename);
        //    if(!string.IsNullOrEmpty(extension))
        //    {
        //        MapWinGIS.IShapefile sf = new Shapefile();
                
        //        if (sf.CdlgFilter.Contains(extension))
        //        {
        //            // aparte functie van maken 
        //            if(!sf.Open(e.filename, null))
        //            {
        //                // throw exception
        //                MessageBox.Show("Kan shapefile niet openen: " + sf.ErrorMsg[sf.LastErrorCode]);
        //            }
        //            else
        //            {
        //                int layerHandle= this.AddLayer(sf, true);
        //                string layerDesc = string.Empty;
                        
        //                // Open de default symbology:
        //                this.LoadLayerOptions(layerHandle, "", ref layerDesc);
        //                // Geef layerhandle mee aan legend

        //                sf = null;
        //            }

        //        }
        //        else
        //        {
        //            MapWinGIS.Image img = new Image();

        //            if(img.CdlgFilter.Contains(extension))
        //            {
        //                if(!img.Open(e.filename,ImageType.USE_FILE_EXTENSION,false,null))
        //                {
        //                    // throw exception
        //                    MessageBox.Show("Kan image niet openen: " + img.ErrorMsg[img.LastErrorCode]);
        //                }
        //                else
        //                {
        //                    int layerHandle = this.AddLayer(img, true);
        //                    // Geef layerhandle mee aan legend

        //                    img = null;
        //                }
        //            }
        //            else
        //            {
        //                MapWinGIS.Grid grd = new Grid();
        //                if(grd.CdlgFilter.Contains(extension))
        //                {
        //                    if(!grd.Open(e.filename,GridDataType.UnknownDataType,true,GridFileType.UseExtension,null))
        //                    {
        //                        // throw exception
        //                        MessageBox.Show("Kan grid niet openen: " + grd.ErrorMsg[grd.LastErrorCode]);
        //                    }
        //                    else
        //                    {
        //                        int layerHandle = this.AddLayer(grd, true);

        //                        grd = null;
        //                    }
        //                }
        //            }
        //        }

        //    }

        //    // heeft ie een extensie
        //    // heeft ie mwprj als extensie
        //    // is het een shapefile, een grid of een image

        //    // als het shapefile, een grid of een image is dan openen en toevoegen

        //    // zoom to max extent:
        //    // TODO Instelling van maken
        //    //this.ZoomToLayer();
        
        //    this.ZoomToMaxExtents();
        //    // Refresh map:
        //    //this.Refresh();
        //    //this.Redraw();

        //    // redraw nog nodig
        //    this.LockWindow(tkLockMode.lmUnlock);
        //}

        //public void Test()
        //{
        //    this.AddLayer(null, true);
        //}

        public int AddLayer(MapWinGIS.IShapefile sf, bool visible)
        {
            return base.AddLayer(sf, visible);
        }

        public int AddLayer(MapWinGIS.Image image, bool visible)
        {
            return base.AddLayer(image, visible);
        }

        public int AddLayer(MapWinGIS.Grid grid, bool visible)
        {
            return base.AddLayer(grid, visible);
        }

        public bool RestorLayerState(int layerHandle, string newVal)
        {
            return base.DeserializeLayer(layerHandle, newVal);
        }

        public string LoadMapState(bool relativePaths, string basePath)
        {
            return base.SerializeMapState(relativePaths, basePath);
        }

        public bool RestoreMapState(string state, bool loadLayers, string basePath )
        {
            if (!base.DeserializeMapState(state, loadLayers, basePath))
            {
                MessageBox.Show(base.get_ErrorMsg(base.LastErrorCode));
                return false;
            }

            return true;

        }

        public new tkCursorMode CursorMode 
        {
            get 
            { 
                return base.CursorMode; 
            }
            set
            {
                base.CursorMode = value;
            }
        }

        public new bool LoadLayerOptions(int layerHandle, string optionsName, ref string description)
        {
            return base.LoadLayerOptions(layerHandle,optionsName, ref description);
        }

        public new void LockWindow(tkLockMode lockMode)
        {
            base.LockWindow(lockMode);
        }

        public new void ZoomToMaxExtents()
        {
            base.ZoomToMaxExtents();
        }

        public new void ZoomToLayer(int layerHandle)
        {
            base.ZoomToLayer(layerHandle);
        }

        public new bool MoveLayer(int initialPosition, int targetPosition)
        {
            return base.MoveLayer(initialPosition, targetPosition);
        }

        public void LayerVisible(int handle, bool visible)
        {
            base.set_LayerVisible(handle, visible);
           // base.get_LayerPosition()
        }
    }
}
