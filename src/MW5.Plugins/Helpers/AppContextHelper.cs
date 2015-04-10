using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Helpers
{
    public static class AppContextHelper
    {
        /// <summary>
        /// Clears selection from all layers.
        /// </summary>
        internal static void ClearAllSelection(this IAppContext context)
        {
            foreach (var layer in context.Layers)
            {
                var fs = layer.FeatureSet;
                if (fs != null)
                {
                    fs.ClearSelection();
                }
            }
        }
    }
}
