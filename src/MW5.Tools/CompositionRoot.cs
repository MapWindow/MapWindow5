// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositionRoot.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The composition root.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools
{
    #region

    using MW5.Plugins.Mvp;
    using MW5.Tools.Views;

    #endregion

    /// <summary>
    /// The composition root.
    /// </summary>
    internal static class CompositionRoot
    {
        #region Public Methods and Operators

        /// <summary>
        /// The compose.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IGisToolView, GisToolView>();
        }

        #endregion
    }
}