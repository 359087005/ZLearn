using UnityEditor;
using UnityEngine;

#if _UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
    }

    public class PercentFunc 
    {
#if UNITY_EDITOR
        [MenuItem("ZTools/12.概率函数")]
#endif
        static void MenuClick()
        {
          Debug.Log(MathUtil.Percent(36));
        }

        public static bool Percent(int percent)
        {
            return Random.Range(0,100)<=percent;
        }
    }
}