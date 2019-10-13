/****************************************************
    文件：GeneratorPackageName.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

namespace ZTools
{
    public class GeneratorPackageName : MonoBehaviour
    {
#if UNITY_EDITOR
        /// <summary>
        /// 导出unitypackage包的时候 可以使用这个名字
        /// </summary>
        [MenuItem("ZTools/1.根据日期生成unityPackage名字")]
        static void ClickExport()
        {
            string packageName = "ZPackage_" + DateTime.Now.ToString("yyyy/MM/dd/HH.mm");
            Debug.Log(packageName);
            //GUIUtility.systemCopyBuffer = packageName;
        }
#endif
    }
}
