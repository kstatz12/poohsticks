namespace PoohSticks.Common.Lib
{
    public static class KeyGen
    {
        public static long Generate()
        {
            var buffer = new Byte[8];
            var rand = new Random();
            rand.NextBytes(buffer);
            return Math.Abs(BitConverter.ToInt64(buffer));
        }
    }
}
