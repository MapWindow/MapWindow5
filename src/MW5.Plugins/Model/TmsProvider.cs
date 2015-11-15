using System.Runtime.Serialization;
using MW5.Api.Enums;

namespace MW5.Plugins.Model
{
    [DataContract]
    public class TmsProvider
    {
        public TmsProvider()
        {
            MinZoom = 0;
            MaxZoom = 17;
            Name = string.Empty;
            Id = -1;
            Projection = TileProjection.SphericalMercator;
            Url = string.Empty;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TileProjection Projection { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public int MinZoom { get; set; }

        [DataMember]
        public int MaxZoom { get; set; }
    }
}
