using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ZTools
{
    public class Exporter
    {
        public static string GetFileName()
        {
            return "ZTools" + DateTime.Now.ToString("yyyyMMdd_hh_mm");
        }

        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
            AssetDatabase.Refresh();
        }

#if UNITY_EDITOR
        [MenuItem("ZTools/1.导出unityPackage %e", false, 1)]
#endif
        public static void ShortCut()
        {
            Exporter.ExportPackage("Assets/ZTools", GetFileName() + ".unitypackage");
            EditorUtil.OpenFolder("file:///" + Application.dataPath);
            //EditorApplication.ExecuteMenuItem("ZTools/6.编辑器代码复用");

        }
    }
}