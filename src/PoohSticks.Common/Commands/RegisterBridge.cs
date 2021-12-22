using MessagePack;

namespace PoohSticks.Common.Commands
{
    [MessagePackObject]
    public class RegisterBridge
    {
        public RegisterBridge()
        {
            Lat = string.Empty;
            Lng = string.Empty;
            Name = string.Empty;
        }

        [Key(0)]
        public string Lat { get; set; }
        [Key(1)]
        public string Lng { get; set; }
        [Key(2)]
        public string Name { get; set; }
    }
}
