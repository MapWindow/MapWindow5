using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Grouping of Layers within the legend
    /// </summary>
    public class LegendGroups: ILegendGroups
    {
        private const string NewGroupName = "New Group";
        private const string DataLayersCaption = "Data Layers";
        private const int InvalidGroup = -1;

        private readonly List<ILegendGroup> _allGroups = new List<ILegendGroup>();
        private readonly List<int> _positions = new List<int>();     //Group Position Lookup table (use Group layerHandle as index)
        private readonly LegendControl _legend;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegendGroups"/> class.
        /// </summary>
        internal LegendGroups(LegendControl leg)
        {
            _legend = leg;      // must be first in constructor
        }

        public ILegendLayer LayerByHandle(int layerHandle)
        {
            var group = _legend.Groups.GroupByLayerHandle(layerHandle);
            if (group != null)
            {
                return group.Layers.FirstOrDefault(l => l.Handle == layerHandle);
            }
            return null;
        }

        /// <summary>
        /// Gets the number of groups currently in the legend
        /// </summary>
        public int Count
        {
            get { return _allGroups.Count; }
        }

        /// <summary>
        /// Allows you to iterate through the list of groups by position {get only}
        /// </summary>
        /// <param name="position">The 0-based index into the list of groups</param>
        public ILegendGroup this[int position]
        {
            get
            {
                if (position < 0 || position >= Count)
                {
                    throw new IndexOutOfRangeException("Group index is out of bounds.");
                }
                return _allGroups[position];
            }
        }

        public ILegendGroup GetGroupSafe(int position)
        {
            if (position >= 0 && position < Count)
            {
                return _allGroups[position];
            }

            return null;
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position
        /// </summary>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public ILegendGroup Add()
        {
            return Add(NewGroupName);
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public ILegendGroup Add(string name)
        {
            return Add(name, -1);
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <param name="position">The desired 0-based index into the list of groups in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public ILegendGroup Add(string name, int position)
        {
            var grp = CreateGroup(name, position);
            if (grp == null)
            {
                return null;
            }

            _legend.Redraw();

            _legend.FireGroupAdded(grp.Handle);
            return grp;
        }

        internal int Add(LegendGroup group)
        {
            if (group == null)
            {
                throw new NullReferenceException("Group reference is null.");
            }

            _allGroups.Add(group);

            _legend.Redraw();
            _legend.FireGroupAdded(group.Handle);

            return group.Handle;
        }

        /// <summary>
        /// Creates a new group
        /// </summary>
        /// <param name="caption">  The caption. </param>
        /// <param name="position"> The position. </param>
        /// <returns> The <see cref="LegendGroup"/>. </returns>
        internal ILegendGroup CreateGroup(string caption, int position)
        {
            var grp = new LegendGroup(_legend, _positions.Count)
            {
                Text = caption.Length < 1 ? NewGroupName : caption,
            };

            _positions.Add(InvalidGroup);

            if (position < 0 || position >= _allGroups.Count)
            {
                // put it at the top
                _positions[grp.Handle] = _allGroups.Count;
                _allGroups.Add(grp);
            }
            else
            {
                // put it where they requested
                _positions[grp.Handle] = position;
                _allGroups.Insert(position, grp);

                UpdateGroupPositions();
            }

            return grp;
        }

        /// <summary>
        /// The update group positions.
        /// </summary>
        private void UpdateGroupPositions()
        {
            var grpCount = _allGroups.Count;
            var handleCount = _positions.Count;
            int i;

            // reset all positions
            for (i = 0; i < handleCount; i++)
            {
                _positions[i] = InvalidGroup;
            }

            // set valid group positions for existing groups
            for (i = 0; i < grpCount; i++)
            {
                _positions[_allGroups[i].Handle] = i;
            }
        }

        /// <summary>
        /// Removes a group from the list of groups
        /// </summary>
        /// <param name="groupHandle"> layerHandle of the group to remove </param>
        /// <returns> True on success, False otherwise </returns>
        public bool Remove(int groupHandle)
        {
            return RemoveGroupCore(groupHandle, false);
        }

        private bool RemoveGroupCore(int groupHandle, bool batch)
        {
            if (!IsValidHandle(groupHandle))
            {
                return false;
            }

            var index = _positions[groupHandle];
            var grp = _allGroups[index];

            // remove any layers within the specified group
            var layerInGroupWasSelected = false;

            while (grp.Layers.Count > 0)
            {
                var lyr = grp.Layers[0].Handle;
                if (_legend.SelectedLayerHandle == lyr)
                {
                    layerInGroupWasSelected = true;
                }

                _legend.RemoveLayer(lyr, true);
            }

            _allGroups.RemoveAt(index);

            UpdateGroupPositions();

            if (!batch)
            {
                if (layerInGroupWasSelected)
                {
                    _legend.UpdateSelectedLayer();
                }
            }

            _legend.Redraw();

            _legend.FireGroupRemoved(groupHandle);

            return true;
        }

        /// <summary>
        /// Tells you if a group exists with the specified handle
        /// </summary>
        /// <param name="handle"> layerHandle of the group to check </param>
        /// <returns> True if the Group extists, False otherwise </returns>
        public bool IsValidHandle(int handle)
        {
            if (handle >= 0 && handle < _positions.Count)
            {
                if (_positions[handle] >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Clears all groups and layers
        /// </summary>
        public void Clear()
        {
            _legend.Lock();
            _legend.AxMap.LockWindow(tkLockMode.lmLock);

            try
            {
                var handles = this.Select(item => item.Handle).ToList();

                foreach (var handle in handles)
                {
                    RemoveGroupCore(handle, true);
                }

                _allGroups.Clear();
                _positions.Clear();
            }
            finally
            {
                _legend.Unlock();
                _legend.AxMap.LockWindow(tkLockMode.lmUnlock);
            }
        }

        /// <summary>
        /// Looks up a group by handle
        /// </summary>
        /// <param name="handle">The unique number representing that group from others</param>
        /// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
        public ILegendGroup ItemByHandle(int handle)
        {
            return this[_positions[handle]];
        }

        /// <summary>
        ///	Finds the position (index) in the list of groups
        /// </summary>
        /// <param name="groupHandle">The unique number representing a particular group from others in the list</param>
        /// <returns>The Position of the specified group on success, -1 on Failure</returns>
        public int PositionOf(int groupHandle)
        {
            if (!IsValidHandle(groupHandle))
            {
                throw new IndexOutOfRangeException("Invalid group handle.");
            }

            return _positions[groupHandle];   
        }

        /// <summary>
        /// Collapses all groups
        /// </summary>
        public void CollapseAll()
        {
            CollapseCore(true);
        }

        /// <summary>
        /// Expands all groups
        /// </summary>
        public void ExpandAll()
        {
            CollapseCore(false);
        }

        private void CollapseCore(bool collapsed)
        {
            _legend.Lock();

            foreach (var g in _allGroups)
            {
                g.Expanded = collapsed;
            }

            _legend.Unlock();
        }

        /// <summary>
        /// Returns group to which particular layer belongs or null if no layer with such handle is found
        /// </summary>
        public ILegendGroup GroupByLayerHandle(int layerHandle)
        {
            return this.FirstOrDefault(g =>
            {
                var legendGroup = g as LegendGroup;
                return legendGroup != null && legendGroup.LayersList.Exists(l => l.Handle == layerHandle);
            });
        }

        public ILegendGroup GroupByName(string groupName, bool createIfNotExists = false)
        {
            var group = this.FirstOrDefault(g => String.Equals(g.Text, groupName, StringComparison.CurrentCultureIgnoreCase));
            if (group == null && createIfNotExists)
            {
                group = Add(groupName);
            }
            return group;
        }

        /// <summary>
        /// Moves a group to a new location
        /// </summary>
        /// <param name="groupHandle"> layerHandle of group to move </param>
        /// <param name="newPos"> 0-Based index of new location </param>
        /// <returns> True on success, False otherwise </returns>
        public bool MoveGroup(int groupHandle, int newPos)
        {
            if (!IsValidHandle(groupHandle))
            {
                throw new IndexOutOfRangeException("Invalid group handle");
            }

            var oldPos = PositionOf(groupHandle);

            if (oldPos == newPos)
            {
                return true;
            }

            var grp = ItemByHandle(groupHandle);

            if (newPos < 0)
            {
                newPos = 0;
            }

            if (newPos >= _allGroups.Count)
            {
                _allGroups.Remove(_allGroups[oldPos]);
                _allGroups.Add(grp);
            }
            else
            {
                _allGroups.Remove(_allGroups[oldPos]);
                _allGroups.Insert(newPos, grp);
            }

            if (grp.Layers.Count > 0)
            {
                // now we have to move the layers around
                _legend.UpdateMapLayerPositions();
            }

            UpdateGroupPositions();
            _legend.Redraw();

            _legend.FireGroupPositionChanged(grp.Handle, oldPos, newPos);
                
            return true;
        }

        internal ILegendGroup FindOrCreateGroup(int targetGroupHandle)
        {
            ILegendGroup grp;

            if (_allGroups.Count == 0 || IsValidHandle(targetGroupHandle) == false)
            {
                // we have to create or find a group to put this layer into
                if (_allGroups.Count == 0)
                {
                    grp = CreateGroup(DataLayersCaption, -1);
                    _legend.FireGroupAdded(grp.Handle);
                }
                else
                {
                    grp = _allGroups[_allGroups.Count - 1];
                }
            }
            else
            {
                grp = _allGroups[PositionOf(targetGroupHandle)];
            }
            return grp;
        }


        /// <summary>
        /// Handles Layer position changes within groups
        /// </summary>
        /// <param name="currentPositionInGroup"> The Current Position In Group. </param>
        /// <param name="source"> The Source group </param>
        /// <param name="targetPositionInGroup"> The Target Position In Group. </param>
        /// <param name="target"> The Destination group. Can be the same as the Source </param>
        public void ChangeLayerPosition(ILegendGroup source, int currentPositionInGroup, ILegendGroup target, int targetPositionInGroup = -1)
        {
            var sourceGroup = source as LegendGroup;
            var destinationGroup = target as LegendGroup;
            
            if (sourceGroup == null || destinationGroup == null)
            {
                throw new NullReferenceException("Group reference is null");
            }

            if (currentPositionInGroup < 0 || currentPositionInGroup >= sourceGroup.Layers.Count)
            {
                throw new IndexOutOfRangeException("Invalid layer index");
            }

            var lyr = sourceGroup.LayersList[currentPositionInGroup];
            sourceGroup.LayersList.Remove(lyr);

            if (targetPositionInGroup >= destinationGroup.Layers.Count || targetPositionInGroup == -1)
            {
                destinationGroup.LayersList.Add(lyr);
            }
            else if (targetPositionInGroup <= 0)
            {
                destinationGroup.LayersList.Insert(0, lyr);
            }
            else
            {
                destinationGroup.LayersList.Insert(targetPositionInGroup, lyr);
            }

            sourceGroup.RecalcHeight();
            sourceGroup.UpdateGroupVisibility();

            if (sourceGroup.Handle != destinationGroup.Handle)
            {
                destinationGroup.RecalcHeight();
                destinationGroup.UpdateGroupVisibility();

                _legend.SelectedGroupHandle = destinationGroup.Handle;
            }
        }

        private LegendGroup GetGroup(int index)
        {
            return _allGroups[index] as LegendGroup;
        }

        /// <summary>
        /// The calc total draw height.
        /// </summary>
        internal int TotalDrawHeight
        {
            get
            {
                int retval = 0;

                for (var i = 0; i < Count; i++)
                {
                    var g = GetGroup(i);
                    g.RecalcHeight();
                    retval += g.Height + Constants.ItemPad;
                }

                return retval;
            }
        }

        #region IEnumerable interface

        public IEnumerator<ILegendGroup> GetEnumerator()
        {
            return ((IEnumerable<ILegendGroup>) _allGroups).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}