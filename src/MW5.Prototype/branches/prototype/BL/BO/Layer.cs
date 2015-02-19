using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Utilities;

namespace BL.BO
{
    [Serializable]
    public class Layer
    {
        public int Handle { get; set; }
        public string Name { get; set; }
        public LayerType LayerType { get; set; }
        public bool LayerVisible { get; set; }
        public string LayerKey { get; set; }
        public bool DynamicVisibility { get; set; }
        public string MinVisibleScale { get; set; }
        public string MaxVisibleScale { get; set; }
        public string Filename { get; set; }
        public int PositionInGroup { get; set; }
        public int Position { get; set; }
     //   public string GroupName { get; set; }
      //  public Group Group { get; set; }
        //public Image Image { get; set; }

        //public Shapefile ShapeFile { get; set; }



    }
}
