using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ZTools
{
    public class Exporter
    {
        private static string GetFileName()
        {
            return "ZTools" + DateTime.Now.ToString("yyyyMMdd_hh_mm");
        }
#if UNITY_EDITOR
        [MenuItem("ZTools/ZFrameEork/Editor/导出unityPackage %e", false, 1)]

        private static void ShortCut()
        {
            EditorUtil.ExportPackage("Assets/ZTools", GetFileName() + ".unitypackage");
            EditorUtil.OpenFolder("file:///" + Application.dataPath);
            //EditorApplication.ExecuteMenuItem("ZTools/6.编辑器代码复用");

        }
#endif
    }
}