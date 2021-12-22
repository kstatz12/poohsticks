using FluentNHibernate.Mapping;
using PoohSticks.Common.Lib;

namespace PoohSticks.Common
{
    public class Bridge : Entity
    {

        public Bridge(long key) : this()
        {
            Key = key;
        }

        public Bridge()
        {
            Name = string.Empty;
            Lat = string.Empty;
            Lng = string.Empty;
            LocationHash = string.Empty;
            FriendlyAddress = string.Empty;
        }

        public string Name { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string LocationHash { get; set; }
        public string FriendlyAddress { get; set; }
    }

    internal class BridgeClassMap : ClassMap<Bridge>
    {
        public BridgeClassMap()
        {
            Id(x => x.Id);
            Map(x => x.Key).Not.Nullable().Unique();
            Map(x => x.Lat).Not.Nullable().Unique();
            Map(x => x.Lng).Not.Nullable().Unique();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.LocationHash).Not.Nullable().Unique();
            Map(x => x.FriendlyAddress).Not.Nullable().Unique();
        }
    }
}
