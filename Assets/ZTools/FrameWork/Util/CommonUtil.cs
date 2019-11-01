using UnityEngine;

namespace ZTools
{
    public partial class CommonUtil
    {
        public static void CopyText(string copyText)
        {
            GUIUtility.systemCopyBuffer = (copyText);
        }
    }
}