namespace PoohSticks.Common.Adapters
{
    public interface IGoogleAdapter
    {
        Task<string> GetAddressFromCoordinatesAsync(string lat, string lng);
    }
}
