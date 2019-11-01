using UnityEngine;

namespace ZTools
{
    public class CommonUtilExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/复制文字到剪切板", false, 1)]
#endif
        private static void MenuClick2()
        {
            CommonUtil.CopyText("要复制的文字");
        }
    }
}