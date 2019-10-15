
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public class PreviourFunc
    {

        public static string GetFileName()
        {
            return "ZTools" + DateTime.Now.ToString("yyyyMMdd_hh_mm");
        }

        public static void CopyText(string copyText)
        {
            GUIUtility.systemCopyBuffer = (copyText);
        }


        public static void OpenFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }


#if UNITY_EDITOR
        public static void CallMenuItem(string menuName)
        {
            EditorApplication.ExecuteMenuItem(menuName);
            Application.OpenURL("file:///" + Application.dataPath);
        }
        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);

            AssetDatabase.Refresh();
        }
        [MenuItem("ZTools/8.总结/1.获取文件名")]
        private static void Previour()
        {
            Debug.Log(GetFileName());
        }
        [MenuItem("ZTools/8.总结/2.复制到剪切板")]
        private static void MenuClick2()
        {
            CopyText("复制到剪切板");
        }
        [MenuItem("ZTools/8.总结/3.生成文件名到剪切板")]
        private static void MenuClick3()
        {
            CopyText(GetFileName());
        }
        [MenuItem("ZTools/8.总结/4.导出UnityPackage")]
        private static void MenuClick4()
        {
            ExportPackage( "Assets/ZTools", GetFileName() +".unitypackage");
        }
        [MenuItem("ZTools/8.总结/5.打开文件夹")]
        private static void MenuClick5()
        {
            OpenFolder(Application.dataPath);
        }
        [MenuItem("ZTools/8.总结/6.MenuItem复用")]
        private static void MenuClick6()
        {
            CallMenuItem("ZTools/4.导包自动命名");
        }
#endif
    }
}