using UnityEngine;

public static class StaticThisExtension 
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("ZTools/Example/StaticThisExtension", false, 17)]
#endif
    static void MenuClick()
    {
        new object().Test();
        "aaa".Test();
    }

    static void Test(this object selfObj)
    {
        Debug.Log(selfObj);
    }
}