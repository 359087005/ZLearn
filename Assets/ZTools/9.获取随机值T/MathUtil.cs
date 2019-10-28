/****************************************************
    文件：MathUtil.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using System;
using UnityEditor;
using System.Linq;

public partial class MathUtil  
{
    public static qwer GetRandomValues<qwer>(params qwer[] values)  where  qwer :Component
    {
        return values[UnityEngine.Random.Range(0, values.Length)];
    }



    public void AAA()
    {

    }



#if UNITY_EDITOR
    [MenuItem("ZTools/9.生成随机值",false,9)]
#endif
    private static void MenuClick9()
    {
        //Debug.Log(GetRandomValues(1, 2, 3));

        //Debug.Log(GetRandomValues("111","ascfds"));
    }
}