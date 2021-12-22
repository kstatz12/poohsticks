using MessagePack;

namespace PoohSticks.Common.Events
{
    [MessagePackObject]
    public class BridgeRegistered
    {
        public BridgeRegistered()
        {
            Name = string.Empty;
            Lat = string.Empty;
            Lng = string.Empty;
        }

        [Key(0)]
        public long Key { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public string Lat { get; set; }
        [Key(3)]
        public string Lng { get; set; }
    }
}
