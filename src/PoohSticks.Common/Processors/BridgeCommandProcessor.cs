using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PoohSticks.Common.Adapters;
using PoohSticks.Common.Commands;
using PoohSticks.Common.Events;
using PoohSticks.Common.Lib;

namespace PoohSticks.Common.Processors
{
    public class BridgeCommandProcessor :
        IProcessAsync<RegisterBridge, Result<BridgeRegistered>>
    {
        private readonly ILogger logger;
        private readonly IDataWriter writer;
        private readonly IGoogleAdapter googleAdapter;
        private readonly IHasher hasher;

        public BridgeCommandProcessor(ILogger logger,
                                      IDataWriter writer,
                                      IGoogleAdapter googleAdapter,
                                      IHasher hasher)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
            this.googleAdapter = googleAdapter ?? throw new ArgumentNullException(nameof(googleAdapter));
            this.hasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
        }

        public async Task<Result<BridgeRegistered>> ProcessAsync(RegisterBridge message)
        {
            var key = KeyGen.Generate();
            return await new Logger(logger).WithScopes(sb => {
                sb.WithValue("BridgeKey", key);
            }).Execute(async l => {
                try
                {
                    var address = await this.googleAdapter.GetAddressFromCoordinatesAsync(message.Lat, message.Lng);
                    var locationHash = this.hasher.Hash(new { Address = address });

                    var change = new ChangeSet<Bridge>(
                        predicate: x => x.Key == key,
                        transform: x => {
                            x.Name = message.Name;
                            x.Lat = message.Lat;
                            x.Lng = message.Lng;
                            x.FriendlyAddress = address;
                            x.LocationHash = locationHash.AsString();
                        },
                        init: () => new Bridge(key)
                    );

                    await writer.Execute(change);

                    var @event = new BridgeRegistered
                    {
                        Key = key,
                        Name = message.Name,
                        Lat = message.Lat,
                        Lng = message.Lng
                    };
                    return Result.Success(@event);
                }
                catch(Exception ex)
                {
                    l.LogError(ex, "Could Not Handle RegisterBridge Command");
                    return Result.Failure<BridgeRegistered>(ex.Message);
                }
            });
        }
    }
}
