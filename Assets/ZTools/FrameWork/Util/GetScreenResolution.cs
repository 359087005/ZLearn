using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class GetScreenResolution 
{

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