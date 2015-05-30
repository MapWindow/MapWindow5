using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Shared;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlLayer
    {
        public bool ProjectStorage
        {
            get { return AppConfig.Instance.SymbolobyStorage == SymbologyStorage.Project; }
        }

        public XmlLayer(ILegendLayer layer)
        {
            if (ProjectStorage)
            {
                OcxLayer = LayerToXmlElement(layer);
            }
            else
            {
                if (layer.SaveOptions("", true, ""))
                {
                    Logger.Current.Warn("Failed to save layer options: " + layer.Name);
                }
            }

            Identity = layer.Identity;
            Expanded = layer.Expanded;
            HideFromLegend = layer.HideFromLegend;
            ColorSchemeCaption = layer.SymbologyCaption;
            Guid = layer.Guid;
            LayerType = layer.LayerType;
            Name = layer.Name;
            SkipLoading = false;

            SerializeCustomObjects(layer);
        }

        public void RestoreLayer(ILegendLayer layer)
        {
            if (OcxLayer != null)
            {
                layer.Deserialize(OcxLayer.OuterXml);
            }
            else
            {
                if (!ProjectStorage)
                {
                    string description = string.Empty;
                    layer.LoadOptions("", ref description);
                }
            }

            RestoreCustomObjects(layer);

            layer.Expanded = Expanded;
            layer.HideFromLegend = HideFromLegend;
            layer.SymbologyCaption = ColorSchemeCaption;
            layer.Guid = Guid;
        }

        private void SerializeCustomObjects(ILegendLayer layer)
        {
            CustomObjects = new List<XmlCustomObject>();

            var legendLayer = layer as LegendLayer;
            if (legendLayer == null)
            {
                return;
            }

            foreach (var item in legendLayer.CustomObjects)
            {
                var cob = new XmlCustomObject()
                {
                    Object = item.Value,
                    Guid = item.Key,
                };

                CustomObjects.Add(cob);
            }
        }

        private void RestoreCustomObjects(ILegendLayer layer)
        {
            var legendLayer = layer as LegendLayer;
            if (legendLayer == null)
            {
                return;
            }

            legendLayer.ClearCustomObjects();

            foreach (var cob in CustomObjects)
            {
                legendLayer.RestoreCustomObject(cob.Object, cob.Guid);
            }
        }

        private XmlElement LayerToXmlElement(ILegendLayer layer)
        {
            string xml = layer.Serialize();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }

        [DataMember] public List<XmlCustomObject> CustomObjects { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public Guid Guid { get; set; }
        [DataMember] public bool Expanded { get; set; }
        [DataMember] public bool HideFromLegend { get; set; }
        [DataMember] public string ColorSchemeCaption { get; set; }
        [DataMember] public XmlElement OcxLayer { get; set; }
        [DataMember] public LayerIdentity Identity { get; set; }
        [DataMember] public LayerType LayerType { get; set; }

        public bool SkipLoading { get; set; }
    }
}
