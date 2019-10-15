using UnityEngine;
using UnityEditor;

public class GetScreenResolution : MonoBehaviour 
{
#if UNITY_EDITOR
    [MenuItem("Ztools/9.获取设备分辨率")]
#endif
    static void MenuClick9()
    {
        bool isLandScape = Screen.width > Screen.height;
        //判断横屏还是竖屏
        float aspect;
        if (isLandScape)
        {
            aspect = (float)Screen.width / Screen.height;
        }
        else
            aspect = (float)Screen.height / Screen.width;
    }
}