using UnityEngine;
namespace ZTools
{
    public partial class CommonUtil
    {
        public static void CopyText(string copyText)
        {
            GUIUtility.systemCopyBuffer = (copyText);
        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/2.复制文字到剪切板", false, 2)]
#endif
        private static void MenuClick2()
        {
            CommonUtil.CopyText("要复制的文字");
        }
    }
}