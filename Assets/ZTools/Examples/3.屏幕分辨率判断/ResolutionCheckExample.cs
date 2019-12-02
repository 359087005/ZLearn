using UnityEngine;

namespace ZTools
{
    public class ResolutionCheckExample : MonoBehaviour
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/获取设备分辨率", false, 3)]

        static void MenuClick4()
        {
            Debug.Log(GetScreenResolution.IsPadResolution() ? "是 Pad" : "不是 Pad");
            Debug.Log(GetScreenResolution.IsPhoneResolution() ? "是 phone" : "不是 phone");
            Debug.Log(GetScreenResolution.IsPhone4SResolution() ? "是 4s" : "不是 4s");
            Debug.Log(GetScreenResolution.IsiPhoneXRResolution() ? "是 XR" : "不是 XR");
        }
#endif
    }
}