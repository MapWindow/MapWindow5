// -------------------------------------------------------------------------------------------
// <copyright file="CompositionRoot.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services.Views;
using MW5.Services.Views.Abstract;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Services;
using MW5.Tools.Toolbox;
using MW5.Tools.Views;
using MW5.Tools.Views.Abstract;
using MW5.Tools.Views.Custom;
using MW5.Tools.Views.Custom.Abstract;

namespace MW5.Tools
{
    /// <summary>
    /// The composition root.
    /// </summary>
    internal static class CompositionRoot
    {
        /// <summary>
        /// Composes the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IToolView, ToolView>()
                .RegisterView<ITaskLogView, TaskLogView>()
                .RegisterView<IRandomPointsView, RandomPointsView>()
                .RegisterView<ILongExecutionView, LongExecutionView>()
                .RegisterSingleton<ITaskCollection, TaskCollection>()
                .RegisterService<ParameterControlFactory>()
                .RegisterService<ParameterControlGenerator>()
                .RegisterSingleton<ToolboxPresenter>()
                .RegisterSingleton<ToolboxDockPanel>()
                .RegisterSingleton<TasksDockPanel>()
                .RegisterSingleton<TasksPresenter>()
                .RegisterService<OutputManager>();
        }
    }
}