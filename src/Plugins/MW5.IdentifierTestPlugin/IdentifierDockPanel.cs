using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.IdentifierTestPlugin
{
    public partial class IdentifierDockPanel: DockPanelControlBase
    {
        private readonly IMuteMap _map;

        public IdentifierDockPanel(IMuteMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            _map = map;

            InitializeComponent();

            InitModeCombo();
        }

        private void InitModeCombo()
        {
            _cboIdentifierMode.AddItemsFromEnum<IdentifierPluginMode>();
            _cboIdentifierMode.SetValue(IdentifierPluginMode.CurrentLayer);
            _cboIdentifierMode.SelectedIndexChanged += IdentifierModeChanged;
        }

        // TODO: better to fire it as an event
        private void IdentifierModeChanged(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case IdentifierPluginMode.CurrentLayer:
                    _map.Identifier.Mode = IdentifierMode.SingleLayer;
                    break;
                case IdentifierPluginMode.TopDownStopOnFirst:
                    _map.Identifier.Mode = IdentifierMode.AllLayerStopOnFirst;
                    break;
                case IdentifierPluginMode.AllLayers:
                case IdentifierPluginMode.LayerSelection:
                    _map.Identifier.Mode = IdentifierMode.AllLayers;
                    break;
            }
        }

        public IdentifierPluginMode Mode
        {
            get { return _cboIdentifierMode.GetValue<IdentifierPluginMode>(); }
        }

        public void OnShapeIdentified(IMuteMap map, Api.Events.ShapeIdentifiedEventArgs e)
        {
            treeViewAdv1.Nodes.Clear();
            foreach (var shape in map.IdentifiedShapes)
            {
                string msg = string.Format("LayerHandle: {0}; shape index: {1}", shape.LayerHandle, shape.ShapeIndex);
                treeViewAdv1.Nodes.Add(new TreeNodeAdv(msg));
            }
        }
    }
}
