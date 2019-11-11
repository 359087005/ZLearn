using UnityEngine;

namespace ZTools
{
    public partial class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }

        public static T GetRandomValues<T>(params T[] values)
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }
    }
}