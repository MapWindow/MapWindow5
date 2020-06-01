using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend.Abstract
{
    public interface ILegendGroups : IEnumerable<ILegendGroup>
    {
        ILegendLayer LayerByHandle(int layerHandle);
        
        /// <summary>
        /// Gets the number of groups currently in the legend
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Allows you to iterate through the list of groups by position {get only}
        /// </summary>
        /// <param name="position">The 0-based index into the list of groups</param>
        ILegendGroup this[int position] { get; }

        /// <summary>
        /// Gets the group at specified index. If the index is out of range a null will be returned.
        /// </summary>
        ILegendGroup GetGroupSafe(int position);

        /// <summary>
        /// Adds a new group to the legend at the topmost position
        /// </summary>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        ILegendGroup Add();

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        ILegendGroup Add(string name);

        /// <summary>
        /// Adds a new group to the legend at the topmost position with the specified Name (Caption)
        /// </summary>
        /// <param name="name">The Caption for this group that appears in the legend</param>
        /// <param name="position">The desired 0-based index into the list of groups in the legend</param>
        /// <returns>Handle to the group on success, -1 on failure</returns>
        ILegendGroup Add(string name, int position);

        /// <summary>
        /// Tells you if a group exists with the specified handle
        /// </summary>
        /// <param name="handle"> layerHandle of the group to check </param>
        /// <returns> True if the Group exists, False otherwise </returns>
        bool IsValidHandle(int handle);

        /// <summary>
        /// Clears all groups and layers
        /// </summary>
        void Clear();

        /// <summary>
        /// Looks up a group by handle
        /// </summary>
        /// <param name="handle">The unique number representing that group from others</param>
        /// <returns>A Group object allowing you to read/change properties, null (nothing) on failure</returns>
        ILegendGroup ItemByHandle(int handle);

        /// <summary>
        ///	Finds the position (index) in the list of groups
        /// </summary>
        /// <param name="groupHandle">The unique number representing a particular group from others in the list</param>
        /// <returns>The Position of the specified group on success, -1 on Failure</returns>
        int PositionOf(int groupHandle);

        /// <summary>
        /// Collapses all groups
        /// </summary>
        void CollapseAll();

        /// <summary>
        /// Expands all groups
        /// </summary>
        void ExpandAll();

        /// <summary>
        /// Returns group to which particular layer belongs or null if no layer with such handle is found
        /// </summary>
        ILegendGroup GroupByLayerHandle(int layerHandle);

        /// <summary>
        /// Searches groups by its name
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="createIfNotExists">if set to <c>true</c> [create if not exists].</param>
        ILegendGroup GroupByName(string groupName, bool createIfNotExists = false);

        /// <summary>
        /// Handles Layer position changes within groups
        /// </summary>
        /// <param name="currentPositionInGroup"> The Current Position In Group. </param>
        /// <param name="source"> The Source group </param>
        /// <param name="targetPositionInGroup"> The Target Position In Group. </param>
        /// <param name="target"> The Destination group. Can be the same as the Source </param>
        void ChangeLayerPosition(ILegendGroup source, int currentPositionInGroup, ILegendGroup target, int targetPositionInGroup = -1);

        /// <summary>
        /// Removes group with specified handle.
        /// </summary>
        bool Remove(int groupHandle);

        /// <summary>
        /// Moves group to the new position.
        /// </summary>
        bool MoveGroup(int groupHandle, int newPos);
    }
}
