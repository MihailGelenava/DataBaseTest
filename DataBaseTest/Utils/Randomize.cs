namespace DataBaseTest.Utils
{
    public static class Randomize
    {
        private static Random rd = new Random();

        public static int GetRandomInt(int maxValue)
        {
            return rd.Next(maxValue)+1;
        }
    }
}
