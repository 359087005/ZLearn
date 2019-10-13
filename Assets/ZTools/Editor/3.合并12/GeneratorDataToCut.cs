using System;
using UnityEditor;
using UnityEngine;

namespace ZTools
{
    public class GeneratorDataToCut : MonoBehaviour
    {
#if UNITY_EDITOR
        /// <summary>
        /// 导出unitypackage包的时候 可以使用这个名字
        /// </summary>
        [MenuItem("ZTools/3.根据日期生成导出包名到剪切板")]
        static void ClickExport()
        {
            string packageName = "ZPackage_" + DateTime.Now.ToString("yyyy/MM/dd/HH.mm");
            Debug.Log(packageName);
            GUIUtility.systemCopyBuffer = packageName;
        }
#endif
    }
}
