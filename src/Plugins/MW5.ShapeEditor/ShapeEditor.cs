﻿using System.Collections.Generic;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.ShapeEditor.Controls;
using MW5.Plugins.ShapeEditor.Menu;

namespace MW5.Plugins.ShapeEditor
{
    [MapWindowPlugin(loadOnStartUp: true)]
    public class ShapeEditor: BasePlugin
    {
        private IAppContext _context;
        private MapListener _mapListener;
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;
        private ProjectListener _projectListener;
        internal MenuUpdater _menuUpdater;

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;
            
            var container = context.Container;
            
            _mapListener = container.GetInstance<MapListener>();
            _menuGenerator = container.GetInstance<MenuGenerator>();
            _menuListener = container.GetInstance<MenuListener>();
            _projectListener = container.GetInstance<ProjectListener>();
            _menuUpdater = container.GetInstance<MenuUpdater>();
        }

        public override IEnumerable<IConfigPage> ConfigPages
        {
            get { yield return _context.Container.GetInstance<ShapeEditorConfigPage>(); }
        }
    }
}
