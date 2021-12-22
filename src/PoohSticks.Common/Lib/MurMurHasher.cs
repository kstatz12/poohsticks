using System.Security.Cryptography;
using System.Text;
using Murmur;

namespace PoohSticks.Common.Lib
{
    public class MurMurHasher : IHasher
    {
        public byte[] Hash(object obj)
        {
            var str = System.Text.Json.JsonSerializer.Serialize(obj);
            var bytes = Encoding.UTF8.GetBytes(str);
            using HashAlgorithm mm128 = MurmurHash.Create128(managed: false);
            return mm128.ComputeHash(bytes);
        }
    }
}
