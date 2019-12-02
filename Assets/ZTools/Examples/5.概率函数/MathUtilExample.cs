using UnityEngine;


namespace ZTools
{
    public class MathUtilExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/概率函数 和 随机函数", false, 5)]

        static void MenuClick()
        {
            Debug.Log(MathUtil.Percent(36));

            Debug.Log(MathUtil.GetRandomValues(new int[] { 1, 2, 3 }));

            Debug.Log(MathUtil.GetRandomValues("111", "ascfds"));
        }

#endif
    }
}
