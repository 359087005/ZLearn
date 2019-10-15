using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public class CustomShortCut
    {
#if UNITY_EDITOR
        [MenuItem("ZTools/7.自定义快捷键 %e")]
#endif
        public static void ShortCut()
        {
            EditorApplication.ExecuteMenuItem("ZTools/6.编辑器代码复用");
        }
    }
}