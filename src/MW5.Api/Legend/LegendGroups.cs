using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Grouping of Layers within the legend
    /// </summary>
    public class LegendGroups: ILegendGroups
    {
        private const string NEW_GROUP_NAME = "New Group";
        private const string DATA_LAYERS_CAPTION = "Data Layers";
        private const int InvalidGroup = -1;

        protected readonly LegendControl _legend;
        protected List<ILegendGroup> _allGroups = new List<ILegendGroup>();
        protected List<int> _positions = new List<int>();     //Group Position Lookup table (use Group layerHandle as index)

        /// <summary>
        /// Initializes a new instance of the <see cref="LegendGroups"/> class.
        /// </summary>
        internal LegendGroups(LegendControl leg)
        {
            _legend = leg;      // must be first in constructor
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

        /// <summary>
        /// Adds a new group to the legend at the topmost position
        /// </summary>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public int Add()
        {
            return Add(NEW_GROUP_NAME);
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public int Add(string name)
        {
            return Add(name, -1);
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <param name="position">The desired 0-based index into the list of groups in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public int Add(string name, int position)
        {
            var grp = CreateGroup(name, position);
            if (grp == null)
            {
                return InvalidGroup;
            }

            _legend.Redraw();

            _legend.FireGroupAdded(grp.Handle);
            return grp.Handle;
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
                Text = caption.Length < 1 ? NEW_GROUP_NAME : caption,
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
        /// <param name="handle"> layerHandle of the group to remove </param>
        /// <returns> True on success, False otherwise </returns>
        protected bool Remove(int handle)
        {
            if (!IsValidHandle(handle))
            {
                return false;
            }
            
            var index = _positions[handle];
            var grp = _allGroups[index];

            // remove any layers within the specified group
            var layerInGroupWasSelected = false;
            while (grp.Layers.Count > 0)
            {
                var lyr = grp.Layers[0].Handle;
                if (_legend.SelectedLayer == lyr)
                {
                    layerInGroupWasSelected = true;
                }
                _legend.RemoveLayer(lyr);
            }

            _allGroups.RemoveAt(index);
            UpdateGroupPositions();

            if (layerInGroupWasSelected)
            {
                _legend.UpdateSelectedLayer();
            }

            _legend.Redraw();

            _legend.FireGroupRemoved(handle);

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
            _legend.ClearGroups();
        }

        /// <summary>
        /// Clears groups only
        /// </summary>
        internal void ClearCore()
        {
            _allGroups.Clear();
            _positions.Clear();
        }

        /// <summary>
        /// Allows you to iterate through the list of groups by position {get only}
        /// </summary>
        /// <param name="position">The 0-based index into the list of groups</param>
        /// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
        public ILegendGroup ItemByPosition(int position)
        {
            return this[position];
        }

        /// <summary>
        /// Looks up a group by handle
        /// </summary>
        /// <param name="handle">The unique number representing that group from others</param>
        /// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
        public ILegendGroup ItemByHandle(int handle)
        {
            if (!IsValidHandle(handle))
            {
                throw new IndexOutOfRangeException("Invalid group handle.");
            }
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
                return legendGroup != null && legendGroup.LayersInternal.Exists(l => l.Handle == layerHandle);
            });
        }

        public ILegendGroup GroupByName(string groupName, bool createIfNotExists = false)
        {
            var group = this.FirstOrDefault(g => String.Equals(g.Text, groupName, StringComparison.CurrentCultureIgnoreCase));
            if (group == null && createIfNotExists)
            {
                var handle = Add(groupName);
                group = ItemByHandle(handle);
            }

            return group;
        }

        /// <summary>
        /// Moves a group to a new location
        /// </summary>
        /// <param name="groupHandle"> layerHandle of group to move </param>
        /// <param name="newPos"> 0-Based index of new location </param>
        /// <returns> True on success, False otherwise </returns>
        protected internal bool MoveGroup(int groupHandle, int newPos)
        {
            if (IsValidHandle(groupHandle))
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
                    grp = CreateGroup(DATA_LAYERS_CAPTION, -1);
                    //GroupPositions[grp.Handle] = _groups.Count - 1;   // TODO: remove after testing
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
        public void ChangeLayerPosition(int currentPositionInGroup, ILegendGroup source, int targetPositionInGroup, ILegendGroup target)
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

            var lyr = sourceGroup.LayersInternal[currentPositionInGroup];
            sourceGroup.LayersInternal.Remove(lyr);

            if (targetPositionInGroup >= destinationGroup.Layers.Count)
            {
                destinationGroup.LayersInternal.Add(lyr);
            }
            else if (targetPositionInGroup <= 0)
            {
                destinationGroup.LayersInternal.Insert(0, lyr);
            }
            else
            {
                destinationGroup.LayersInternal.Insert(targetPositionInGroup, lyr);
            }

            sourceGroup.RecalcHeight();
            sourceGroup.UpdateGroupVisibility();

            if (sourceGroup.Handle != destinationGroup.Handle)
            {
                destinationGroup.RecalcHeight();
                destinationGroup.UpdateGroupVisibility();

                _legend.SetSelectedGroup(destinationGroup.Handle);
            }
        }

        internal LegendGroup GetGroup(int index)
        {
            return _allGroups[index] as LegendGroup;
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