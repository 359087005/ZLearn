using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ZTools
{
    public class ExportUnityPackage : MonoBehaviour
    {
#if UNITY_EDITOR
        /// <summary>
        /// 导出unitypackage包的时候 可以使用这个名字
        /// </summary>
        [MenuItem("ZTools/4.导包自动命名")]
        static void ClickExport()
        {
            string assetPathName = "Assets/ZTools"; //需要导出的文件夹(在当前工程下的路径)

            string exportPath = Application.dataPath;

            string packageName =exportPath + "/ZPackage_" + DateTime.Now.ToString("yyyy_MM_dd_HH-mm") +".unitypackage";
            AssetDatabase.ExportPackage(assetPathName,packageName,ExportPackageOptions.Recurse);

            Debug.Log("导出完成...");
            EditorUtility.DisplayDialog("title","资源在"+ exportPath+"路径下导出完毕.", "ok");

            AssetDatabase.Refresh();
        }
    }
#endif
}