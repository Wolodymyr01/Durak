using System;

namespace Durak
{
    public class Randomizer
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return random.Next(min, max);
            }
        }
        public static bool MakeDecision(int procentYes)
        {
            var x = RandomNumber(0, 100);
            return (x < procentYes) ? true : false;
        }
    }
}