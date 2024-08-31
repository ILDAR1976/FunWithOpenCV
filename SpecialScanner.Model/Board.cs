using System.Runtime.Serialization;

namespace SpecialScanner.Model
{
    [Serializable]
    [DataContract]
    public class Board
    {
        [DataMember]
        public string BoardBrand { get; set; }
        [DataMember]
        public int АmountKnots { get; set; }

        public Board() { }
    }
}
