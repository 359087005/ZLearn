using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

namespace ZTools
{
    public class CopyNameToCutPlane : MonoBehaviour
    {
#if UNITY_EDITOR
        /// <summary>
        /// 导出unitypackage包的时候 可以使用这个名字
        /// </summary>
        [MenuItem("ZTools/2.复制名字到剪切板(后期修改)")]
        static void ClickExport()
        {
            string packageName = "ZPackage_" + DateTime.Now.ToString("yyyy/MM/dd/HH.mm"); //后期自定义   TODO
            GUIUtility.systemCopyBuffer = packageName;
        }
#endif
    }
}