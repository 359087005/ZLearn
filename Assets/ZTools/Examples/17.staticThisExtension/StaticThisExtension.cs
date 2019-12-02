using UnityEngine;

public static class StaticThisExtension 
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("ZTools/Example/StaticThisExtension", false, 17)]

    static void MenuClick()
    {
        new object().Test();
        "aaa".Test();
    }
#endif
    static void Test(this object selfObj)
    {
        Debug.Log(selfObj);
    }
}