using System.Runtime.Serialization;
using MW5.Api.Enums;

namespace MW5.Plugins.Model
{
    [DataContract]
    public class TmsProvider
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TileProjection Projection { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}
