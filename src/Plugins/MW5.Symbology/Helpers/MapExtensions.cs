using System.Windows.Forms;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class MapExtensions
    {
        /// <summary>
        /// Check if final location is valid
        /// </summary>
        public static bool EventWithinMap(this IMuteMap map, MouseEventArgs e)
        {
            return !(e.X < 0 || e.Y < 0 || e.X > map.Width || e.Y > map.Height);
        }
    }
}
