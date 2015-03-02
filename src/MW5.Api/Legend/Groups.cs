//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source. 
//
//The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
//Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
//public domain in March 2004.  
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//
//********************************************************************************************************

using System.Collections.Generic;
using System.Linq;

namespace MW5.Api.Legend
{
	/// <summary>
	/// Grouping of Layers within the legend
	/// </summary>
	public class Groups: IEnumerable<Group>
	{
		private Legend.LegendControl m_Legend;
		/// <summary>
		/// Constructor
		/// </summary>
		public Groups(Legend.LegendControl leg)
		{
			//The next line MUST GO FIRST in the constructor
			m_Legend = leg;
			//The previous line MUST GO FIRST in the constructor	
		}

        #region IEnumerable interface
        public IEnumerator<Group> GetEnumerator()
        {
            foreach (Group group in m_Legend.AllGroups)
            {
                // Return the current element and then on next function call 
                // resume from next element rather than starting all over again;
                yield return group;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }
        #endregion

        /// <summary>
		/// Adds a new group to the legend at the topmost position
		/// </summary>
		/// <returns>Handle to the group on success, -1 on failure</returns>
		public int Add()
		{
			return m_Legend.AddGroup("New Group");
		}

		/// <summary>
		/// Adds a new group to the legend at the topmost position with the specified Name (Caption)
		/// </summary>
		/// <param name="Name">The Caption for this group that appears in the legend</param>
		/// <returns>Handle to the group on success, -1 on failure</returns>
		public int Add(string Name)
		{
			return m_Legend.AddGroup(Name);
		}

		/// <summary>
		/// Adds a new group to the legend at the topmost position with the specified Name (Caption)
		/// </summary>
		/// <param name="Name">The Caption for this group that appears in the legend</param>
		/// <param name="Position">The desired 0-based index into the list of groups in the legend</param>
		/// <returns>Handle to the group on success, -1 on failure</returns>
		public int Add(string Name, int Position)
		{
			return m_Legend.AddGroup(Name,Position);
		}

		/// <summary>
		/// Remove a group and all of the layers contained within the group
		/// </summary>
		/// <param name="Handle">The handle to the group to be removed</param>
		/// <returns>True on success, False on failure</returns>
		public bool Remove(int Handle)
		{
			return m_Legend.RemoveGroup(Handle);
		}

		/// <summary>
		/// Gets the number of groups currently in the legend
		/// </summary>
		public int Count
		{
			get
			{
				return m_Legend.NumGroups;
			}
		}

		/// <summary>
		/// Allows you to iterate through the list of groups by position {get only}
		/// </summary>
		/// <param name="Position">The 0-based index into the list of groups</param>
		public Group this[int Position]
		{
			get
			{
				if(Position >=0 && Position < this.Count)
					return (Group)m_Legend.AllGroups[Position];
				else
				{
					LegendHelper.LastError = "Invalid Group Position ( Must be >= 0 and < Count )";
					return null;
				}
			}
		}

		/// <summary>
		/// Clears all groups and layers
		/// </summary>
		public void Clear()
		{
			m_Legend.ClearGroups();
		}

		/// <summary>
		/// Allows you to iterate through the list of groups by position {get only}
		/// </summary>
		/// <param name="Position">The 0-based index into the list of groups</param>
		/// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
		public Group ItemByPosition(int Position)
		{
			return this[Position];
		}	

		/// <summary>
		/// Looks up a group by handle
		/// </summary>
		/// <param name="Handle">The unique number representing that group from others</param>
		/// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
		public Group ItemByHandle(int Handle)
		{
			if(m_Legend.IsValidGroup(Handle))
				return this[(int)m_Legend.m_GroupPositions[Handle]];
			else
			{
                LegendHelper.LastError = "Invalid Group Handle";
				return null;
			}
		}


		/// <summary>
		///	Finds the position (index) in the list of groups
		/// </summary>
		/// <param name="GroupHandle">The unique number representing a particular group from others in the list</param>
		/// <returns>The Position of the specified group on success, -1 on Failure</returns>
		public int PositionOf(int GroupHandle)
		{
			if(m_Legend.IsValidGroup(GroupHandle))
			{
				return (int)m_Legend.m_GroupPositions[GroupHandle];
			}	
			else
			{
                LegendHelper.LastError = "Invalid Group Handle";
				return -1;
			}
		}

		/// <summary>
		/// Checks if the specified handle still exists within the list of groups
		/// </summary>
		/// <param name="Handle">Group handle to validate</param>
		/// <returns>True if the Group still exists, False otherwise</returns>
		public bool IsValidHandle(int Handle)
		{
			return m_Legend.IsValidGroup(Handle);
		}

		/// <summary>
		/// Moves a specified group to a new position
		/// </summary>
		/// <param name="GroupHandle">Handle of the group to move</param>
		/// <param name="NewPos">The 0-Based index into the list of groups where this group should be placed</param>
		/// <returns>True on success, False otherwise</returns>
		public bool MoveGroup(int GroupHandle,int NewPos)
		{
			return m_Legend.MoveGroup(GroupHandle,NewPos);
		}

		/// <summary>
		/// Collapses all groups
		/// </summary>
		public void CollapseAll()
		{
			m_Legend.Lock();
			int i, count;

			count = Count;
			for( i = 0; i < count; i++)
				this[i].Expanded = false;
			m_Legend.Unlock();
		}

		/// <summary>
		/// Expands all groups
		/// </summary>
		public void ExpandAll()
		{
			m_Legend.Lock();
			int i, count;

			count = Count;
			for( i = 0; i < count; i++)
				this[i].Expanded = true;
			m_Legend.Unlock();
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
                int handle = this.Add(groupName);
                group = this.ItemByHandle(handle);
            }
	        return group;
        }
    }
}
