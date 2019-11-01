using UnityEditor;
using UnityEngine;
namespace ZTools
{
    public class EditorUtilExample : MonoBehaviour
    {

#if UNITY_EDITOR
        [MenuItem("ZTools/Example/MenuItem复用", false, 2)]
        private static void MenuClick6()
        {
            EditorUtil.CallMenuItem("ZTools/Example/复制文字到剪切板");
        }
#endif
    }
}