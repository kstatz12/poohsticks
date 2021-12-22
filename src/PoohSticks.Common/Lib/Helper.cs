using System.Text;

namespace PoohSticks.Common.Lib
{
    public static class Helper
    {
        public static long AsLong(this byte[] buffer)
        {
            return Math.Abs(BitConverter.ToInt64(buffer));
        }

        public static string AsString(this byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
