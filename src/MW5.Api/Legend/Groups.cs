namespace MW5.Api.Legend
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Grouping of Layers within the legend
    /// </summary>
    public class Groups : IEnumerable<Group>
    {
        private readonly LegendControl _legend;

        /// <summary>
        /// Constructor
        /// </summary>
        public Groups(LegendControl leg)
        {
            // The next line MUST GO FIRST in the constructor
            this._legend = leg;

            // The previous line MUST GO FIRST in the constructor	
        }

        /// <summary>
        /// Gets the number of groups currently in the legend
        /// </summary>
        public int Count
        {
            get
            {
                return this._legend.NumGroups;
            }
        }

        /// <summary>
        /// Allows you to iterate through the list of groups by position {get only}
        /// </summary>
        /// <param name="position">The 0-based index into the list of groups</param>
        public Group this[int position]
        {
            get
            {
                if (position >= 0 && position < this.Count)
                {
                    return this._legend.AllGroups[position];
                }

                LegendHelper.LastError = "Invalid Group Position ( Must be >= 0 and < Count )";
                return null;
            }
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position
        /// </summary>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public int Add()
        {
            return this._legend.AddGroup("New Group");
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public int Add(string name)
        {
            return this._legend.AddGroup(name);
        }

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <param name="position">The desired 0-based index into the list of groups in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        public int Add(string name, int position)
        {
            return this._legend.AddGroup(name, position);
        }

        /// <summary>
        /// Remove a group and all of the layers contained within the group
        /// </summary>
        /// <param name="handle">The handle to the group to be removed</param>
        /// <returns>True on success, False on failure</returns>
        public bool Remove(int handle)
        {
            return this._legend.RemoveGroup(handle);
        }

        /// <summary>
        /// Clears all groups and layers
        /// </summary>
        public void Clear()
        {
            this._legend.ClearGroups();
        }

        /// <summary>
        /// Allows you to iterate through the list of groups by position {get only}
        /// </summary>
        /// <param name="position">The 0-based index into the list of groups</param>
        /// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
        public Group ItemByPosition(int position)
        {
            return this[position];
        }

        /// <summary>
        /// Looks up a group by handle
        /// </summary>
        /// <param name="handle">The unique number representing that group from others</param>
        /// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
        public Group ItemByHandle(int handle)
        {
            if (this._legend.IsValidGroup(handle))
            {
                return this[(int)this._legend.m_GroupPositions[handle]];
            }

            LegendHelper.LastError = "Invalid Group Handle";
            return null;
        }

        /// <summary>
        ///	Finds the position (index) in the list of groups
        /// </summary>
        /// <param name="groupHandle">The unique number representing a particular group from others in the list</param>
        /// <returns>The Position of the specified group on success, -1 on Failure</returns>
        public int PositionOf(int groupHandle)
        {
            if (this._legend.IsValidGroup(groupHandle))
            {
                return (int)this._legend.m_GroupPositions[groupHandle];
            }

            LegendHelper.LastError = "Invalid Group Handle";
            return -1;
        }

        /// <summary>
        /// Checks if the specified handle still exists within the list of groups
        /// </summary>
        /// <param name="handle">Group handle to validate</param>
        /// <returns>True if the Group still exists, False otherwise</returns>
        public bool IsValidHandle(int handle)
        {
            return this._legend.IsValidGroup(handle);
        }

        /// <summary>
        /// Moves a specified group to a new position
        /// </summary>
        /// <param name="groupHandle">Handle of the group to move</param>
        /// <param name="newPos">The 0-Based index into the list of groups where this group should be placed</param>
        /// <returns>True on success, False otherwise</returns>
        public bool MoveGroup(int groupHandle, int newPos)
        {
            return this._legend.MoveGroup(groupHandle, newPos);
        }

        /// <summary>
        /// Collapses all groups
        /// </summary>
        public void CollapseAll()
        {
            this._legend.Lock();
            int i;

            var count = this.Count;
            for (i = 0; i < count; i++)
            {
                this[i].Expanded = false;
            }

            this._legend.Unlock();
        }

        /// <summary>
        /// Expands all groups
        /// </summary>
        public void ExpandAll()
        {
            this._legend.Lock();
            int i;

            var count = this.Count;
            for (i = 0; i < count; i++)
            {
                this[i].Expanded = true;
            }

            this._legend.Unlock();
        }

        /// <summary>
        /// Returns group to which particular layer belongs or null if no layer with such handle is found
        /// </summary>
        public Group GroupByLayerHandle(int layerHandle)
        {
            return this.FirstOrDefault(g => g.Layers.Exists(l => l.Handle == layerHandle));
        }

        public Group GroupByName(string groupName, bool createIfNotExists = false)
        {
            var group = this.FirstOrDefault(g => g.Text.ToLower() == groupName.ToLower());
            if (group == null && createIfNotExists)
            {
                var handle = this.Add(groupName);
                group = this.ItemByHandle(handle);
            }

            return group;
        }

        #region IEnumerable interface

        public IEnumerator<Group> GetEnumerator()
        {
            foreach (var group in this._legend.AllGroups)
            {
                // Return the current element and then on next function call 
                // resume from next element rather than starting all over again;
                yield return group;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }

        #endregion
    }
}