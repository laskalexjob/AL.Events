using System.Runtime.Serialization;

namespace AL.Events.WCF.Entities
{
    [DataContract]
    public class Ad
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public string Link { get; set; }
    }
}
