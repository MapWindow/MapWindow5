using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.BO
{
    [Serializable]
    public class Group
    {
        public string Name { get; set; }
        public bool Expanded { get; set; }
        public int Position { get; set; }
      //  public List<Layer> Layers { get; set; }
        public int Handle { get; set; }

        //public void AddLayer(Layer layer)
        //{
        //    if (Layers == null)
        //    {
        //        Layers = new List<Layer>();
        //    }

        //    Layers.Add(layer);
        //}   
    }
}
