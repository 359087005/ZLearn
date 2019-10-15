
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public class OpenInFile
    {
#if UNITY_EDITOR
        [MenuItem("ZTools/5.打开文件夹")]
#endif
        public static void OpenFile()
        {
            Application.OpenURL("file:///" + Application.dataPath);
        }
    }
}