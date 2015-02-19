using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL.Utilities;

namespace BL.BO
{
    public class LayerCollection : ICollection<Layer>, IListSource
    {
        private List<LayerGroup> _innerList;
        private Layer current;

        public LayerCollection()
        {
            _innerList = new List<LayerGroup>();
        }

        public Layer Current
        {
            get
            {
                return current;
            }
            set { current = value; }
        }

        private Group GetDefaultGroup()
        {
            return new Group { Expanded = true, Handle = 99, Name = "Default Group" };
        }

        protected List<LayerGroup> InnerList
        {
            get { return _innerList; }
        }

        public Group GetGroup(string name)
        {
            LayerGroup layerGroup = _innerList.FirstOrDefault(elm => elm.Group.Name == name);
            return layerGroup != null ? layerGroup.Group : null;
        }

        public List<Layer> GetMovingLayers(string movingName)
        {
            List<Layer> movingLayers = null;

            LayerGroup movingGroup = _innerList.FirstOrDefault(elm => elm.Group.Name == movingName);
            if (movingGroup != null)
            {
                //movingLayers = (List<Layer>)(from layers in _innerList
                //where layers.Group == movingGroup.Group
                //select layers);

                Layer aap = _innerList[1];
                LayerGroup aap2 = _innerList[1];
                
                movingLayers = _innerList.FindAll(elm => elm.Group == movingGroup.Group).Cast<Layer>().ToList();
            }
            else
            {
                Layer layer = _innerList.First(elm => elm.Name == movingName);
                movingLayers = new List<Layer>() {layer};
            }

            return movingLayers;
        }

        public bool Move(string newDestination, string movingName)
        {
            try
            {
                int newDestPosition;
                Group newDestGroup;

                LayerGroup movingGroup = _innerList.FirstOrDefault(elm => elm.Group.Name == movingName);

                LayerGroup destinationGroup = _innerList.FirstOrDefault(elm => elm.Group.Name == newDestination);

                if (movingGroup != null)
                {
                    if (destinationGroup == null)
                    {
                        // A group cannot be moved to a layer
                        return false;
                    }

                    MoveGroup(movingGroup, destinationGroup);

                    return true;
                }
                else
                {
                    LayerGroup movingLayer = _innerList.FirstOrDefault(elm => elm.Name == movingName);

                    if (destinationGroup != null)
                    {
                        // Move below a group

                        // Get first layer in group
                        var destLayer = (from layer in _innerList
                                         where layer.Group == destinationGroup.Group
                                         select layer).OrderBy(elm => elm.Position).First();

                        // set new position and new group
                        newDestPosition = destLayer.Position - 1;
                        newDestGroup = destLayer.Group;
                    }
                    else
                    {
                        // Move below a layer

                        LayerGroup destLayer = _innerList.FirstOrDefault(elm => elm.Name == newDestination);
                        newDestPosition = destLayer.Position;
                        newDestGroup = destLayer.Group;
                    }

                    MoveLayer(newDestGroup, newDestPosition, movingLayer);
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void MoveGroup(LayerGroup movingGroup, LayerGroup destinationGroup)
        {
            // Get all layers in moving group
            var movingLayers = _innerList.FindAll(elm => elm.Group == movingGroup.Group);
            int maxPostionOfMovingGroup = movingLayers.Max(elm => elm.Position);

            var lastLayerInDestGroup = (from x in _innerList
                                        where x.Group == destinationGroup.Group
                                        select x).Max(elm => elm.Position);

            if (maxPostionOfMovingGroup < lastLayerInDestGroup)
            {
                // move layers down (to higher number)

                for (int i = (maxPostionOfMovingGroup + 1); i <= lastLayerInDestGroup; i ++)
                {
                    var editLayer = _innerList.FirstOrDefault(elm => elm.Position == i);
                    editLayer.Position = editLayer.Position - movingLayers.Count;
                }

                int layerPos = 1;
                foreach (var movingLayer in movingLayers)
                {
                    movingLayer.Position = lastLayerInDestGroup - movingLayers.Count + layerPos;
                    layerPos++;
                }
            }
            else
            {
                int minPostionOfMovingGroup = movingLayers.Min(elm => elm.Position);

                for (int i = (minPostionOfMovingGroup - 1); i > lastLayerInDestGroup; i--)
                {
                    var editLayer = _innerList.FirstOrDefault(elm => elm.Position == i);
                    editLayer.Position = editLayer.Position + movingLayers.Count;
                }

                int layerPos = 1;
                foreach (var movingLayer in movingLayers)
                {
                    movingLayer.Position = lastLayerInDestGroup + layerPos;
                    layerPos++;
                }
            }
        }

        // Switch the postion of the layers
        private void MoveLayer(Group newDestGroup, int newDestPosition, LayerGroup movingLayer)
        {
            if (movingLayer.Position < newDestPosition)
            {
                for (int i = (movingLayer.Position + 1); i <= newDestPosition; i++)
                {
                    var editLayer = _innerList.FirstOrDefault(elm => elm.Position == i);
                    editLayer.Position--;
                }

                movingLayer.Position = newDestPosition;
                movingLayer.Group = newDestGroup;
            }
            else
            {
                for (int i = (newDestPosition + 1); i < movingLayer.Position; i++)
                {
                    var editLayer = _innerList.FirstOrDefault(elm => elm.Position == i);
                    editLayer.Position++;
                }

                movingLayer.Position = newDestPosition + 1;
                movingLayer.Group = newDestGroup;
            }
        }

        public void Add(Layer item, Group group)
        {

            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be nothing.");
            }

            if (group == null)
            {
                throw new ArgumentNullException("Group cannot be nothing.");
            }

            Group groupToAdd;

            // controleer of het een nieuwe of al bestaande groep is
            LayerGroup searchLayerGroup = _innerList.FirstOrDefault(elm => elm.Group.Name == group.Name);
            if (searchLayerGroup == null)
            {
                groupToAdd = group;
            }
            else
            {
                groupToAdd = searchLayerGroup.Group;
            }

            LayerGroup layerGroup = LayerGroup.CreateLayerGroup(item, groupToAdd);

            _innerList.Add(layerGroup);

            Current = layerGroup;

        }

        public void Add(Layer item)
        {

            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be nothing.");
            }

            Group group;

            if (_innerList.Count == 0)
            {
                group = GetDefaultGroup();
            }
            else
            {
                // gebruik de group met de hoogste handle
                group = (_innerList.First(l2 => l2.Group.Handle == _innerList.Min(elm => elm.Group.Handle))).Group;
            }

            LayerGroup layerGroup = LayerGroup.CreateLayerGroup(item, group);

            _innerList.Add(layerGroup);

            Current = layerGroup;
        }

        public void Clear()
        {
            this._innerList.Clear();
        }

        public bool Contains(Layer item)
        {
            return (this.InnerList.FirstOrDefault(elm => elm.Handle ==
                                                         item.Handle) != null);
        }

        public void CopyTo(Layer[] array, int arrayIndex)
        {
            List<Layer> tempList = new List<Layer>();
            tempList.AddRange(this.InnerList);
            tempList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.InnerList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Layer item)
        {
            bool retVal = false;

            LayerGroup layerGroup = this.InnerList.FirstOrDefault(c => c.Handle == item.Handle);

            if (layerGroup != null)
            {
                this.InnerList.Remove(layerGroup);
                retVal = true;

            }

            return retVal;
        }

        public IEnumerator<Layer> GetEnumerator()
        {
            return new GenericEnumerator<LayerGroup>(this.InnerList);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool ContainsListCollection
        {
            get { return true; }
        }

        public System.Collections.IList GetList()
        {
            return this.InnerList;
        }
    }
    //public class LayerCollection : CollectionBase
    //{
    //    //public LayerCollection()
    //    //{

    //    //}

    //    public void Sort(string SortExpression, SortOrder Order)
    //    {
    //        // use as : col.Sort("Name", SortOrder.ASC);

    //        GenericComparer comp = new GenericComparer(SortExpression, Order);

    //        this.InnerList.Sort(comp);

    //    } 

    //    public VisibleLayerEnumerator GetVisibleLayerEnumerator()
    //    {

    //        VisibleLayerEnumerator enume = new VisibleLayerEnumerator(this);

    //        return enume;

    //    }


    //    public Layer Current
    //    {
    //        get
    //        {
    //            return new Layer();
    //        }

    //        set { ; }
    //    }

    //    public Layer this[int index]
    //    {

    //        get { return (Layer)this.List[index]; }

    //        set { this.List[index] = value; }

    //    }

    //    public int IndexOf(Layer item)
    //    {

    //        return base.List.IndexOf(item);

    //    }


    //    public int Add(Layer item)
    //    {
    //        return this.List.Add(item);
    //    }

    //    public void Remove(Layer item)
    //    {

    //        this.InnerList.Remove(item);

    //    }


    //    public void CopyTo(Array array, int index)
    //    {

    //        this.List.CopyTo(array, index);

    //    }

    //    public void AddRange(LayerCollection collection)
    //    {

    //        for (int i = 0; i < collection.Count; i++)
    //        {

    //            this.List.Add(collection[i]);

    //        }

    //    }



    //    public void AddRange(Layer[] collection)
    //    {

    //        this.AddRange(collection);

    //    }



    //    public bool Contains(Layer item)
    //    {

    //        return this.List.Contains(item);

    //    }



    //    public void Insert(int index, Layer item)
    //    {

    //        this.List.Insert(index, item);

    //    }

    //}

    //public class VisibleLayerEnumerator : IEnumerable
    //{
    //    LayerCollection list = new LayerCollection();



    //    public VisibleLayerEnumerator(LayerCollection emplist)
    //    {

    //        list = emplist;

    //    }

    //    public IEnumerator GetEnumerator()
    //    {

    //        for (int i = 0; i < list.Count; i++)
    //        {

    //            if (list[i].LayerVisible == true)
    //            {

    //                yield return list[i];

    //            }

    //        }

    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {

    //        return (GetEnumerator());

    //    }

    //}
}
