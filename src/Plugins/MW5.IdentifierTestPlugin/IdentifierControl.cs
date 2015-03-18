using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.UI.Helpers;

namespace MW5.Plugins.IdentifierTestPlugin
{
    public partial class IdentifierControl : UserControl
    {
        private readonly IMuteMap _map;

        public IdentifierControl(IMuteMap map)
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
                    _map.Identifier.Mode = Api.IdentifierMode.SingleLayer;
                    break;
                case IdentifierPluginMode.TopDownStopOnFirst:
                    _map.Identifier.Mode = Api.IdentifierMode.AllLayerStopOnFirst;
                    break;
                case IdentifierPluginMode.AllLayers:
                case IdentifierPluginMode.LayerSelection:
                    _map.Identifier.Mode = Api.IdentifierMode.AllLayers;
                    break;
            }
        }

        public IdentifierPluginMode Mode
        {
            get { return _cboIdentifierMode.GetValue<IdentifierPluginMode>(); }
        }

        public void OnShapeIdentified(IMuteMap map, Api.Events.ShapeIdentifiedEventArgs e)
        {
            // TODO: display info about shape
            Debug.Print("Shape identified: {0}; layer handle: {1}", e.ShapeIndex, e.LayerHandle);
        }
    }
}
