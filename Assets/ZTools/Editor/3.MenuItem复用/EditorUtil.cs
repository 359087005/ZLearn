
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public class EditorUtil
    {
        public static void OpenFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }

        public static void CallMenuItem(string menuName)
        {
            EditorApplication.ExecuteMenuItem(menuName);
        }

#if UNITY_EDITOR
        [MenuItem("ZTools/3.MenuItem复用", false, 3)]
        private static void MenuClick6()
        {
            CallMenuItem("2.复制文字到剪切板");
        }
#endif
    }
}