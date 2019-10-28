using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class GetScreenResolution 
{
#if UNITY_EDITOR
    [MenuItem("ZTools/4.获取设备分辨率",false,4)]
#endif
    static void MenuClick4()
    {
        Debug.Log(IsPadResolution() ? "是 Pad" : "不是 Pad");
        Debug.Log(IsPhoneResolution() ? "是 phone" : "不是 phone");
        Debug.Log(IsPhone4SResolution() ? "是 4s" : "不是 4s");
        Debug.Log(IsiPhoneXRResolution() ? "是 XR" : "不是 XR");
    }

    public static float GetAspect()
    {
        bool isLandScape = Screen.width > Screen.height;
        return isLandScape ? ((float)Screen.width / Screen.height) : (float)Screen.height / Screen.width;
    }

    public static bool IsPadResolution()
    {
        return InAspectRange(4.0f / 3);
    }

    public static bool IsPhoneResolution()
    {
        return InAspectRange(16.0f / 9);
    }
    public static bool IsPhone4SResolution()
    {
        return InAspectRange(3.0f / 2);
    }
    public static bool IsiPhoneXRResolution()
    {
        return InAspectRange(2436.0f / 1125);
    }


    public static bool InAspectRange(float limit)
    {
        float aspect = GetAspect();
        return aspect > (limit - 0.05) && aspect < (limit + 0.05);
    }
}