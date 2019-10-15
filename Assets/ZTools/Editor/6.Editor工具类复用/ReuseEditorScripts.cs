using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ZTools
{
    public class ReuseEditorScripts 
    {
#if UNITY_EDITOR
        [MenuItem("ZTools/6.编辑器代码复用")]
#endif
        public static void ReuseScripts()
        {
            //自动复用 第四个的代码
            EditorApplication.ExecuteMenuItem("ZTools/4.导包自动命名");

            //Application.OpenURL("file:///" + Path.Combine(Application.dataPath,"../"));
            Application.OpenURL("file:///" + Application.dataPath);
        }
    }
}
