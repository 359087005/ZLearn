﻿
using UnityEngine;

namespace ZTools
{
    public class CommonUtilExample 
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/复制文字到剪切板", false, 1)]
        private static void MenuClick2()
        {
            CommonUtil.CopyText("要复制的文字");

            
        }
#endif



    }
}