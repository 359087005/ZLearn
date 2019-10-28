using UnityEditor;
using UnityEngine;

#if _UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public partial class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
#if UNITY_EDITOR
        [MenuItem("ZTools/6.概率函数", false, 6)]
#endif
        static void MenuClick()
        {
            Debug.Log(MathUtil.Percent(36));
        }
    }
}