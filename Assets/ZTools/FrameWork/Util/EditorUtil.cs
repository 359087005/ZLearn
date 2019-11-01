
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public partial class EditorUtil
    {
        public static void OpenFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }
#if UNITY_EDITOR
        public static void CallMenuItem(string menuName)
        {
            EditorApplication.ExecuteMenuItem(menuName);
        }

        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
            AssetDatabase.Refresh();
        }
#endif
    }
}