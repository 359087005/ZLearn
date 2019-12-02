/****************************************************
    文件：TestRotate.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;

namespace ZTools
{
    public class TestRotate : MonoBehaviour
    {
        private void Start()
        {
            //Debug.Log(Application.dataPath);
            //string newPath = Path.Combine(Application.dataPath, "ZTools");

            //Object mat = Selection.activeObject;
            //string testPath =  AssetDatabase.GetAssetPath(mat);
            //Debug.Log(testPath);
            //Material mat1 = AssetDatabase.LoadAssetAtPath<Material>(testPath);
            //Debug.Log(mat1.color);
            //string[] strs = Selection.assetGUIDs;
            //string path = AssetDatabase.GUIDToAssetPath(strs[0]);
            //Debug.Log(path);
            //System.IO.Directory.GetCurrentDirectory();
            //Material mat = AssetDatabase.LoadAssetAtPath<Material>(newPath + "/mat");
            //Debug.Log(mat.color);

            Debug.Log("10转2:" +  MathUtil.DecimalToBinary(8));
            Debug.Log("10转16:" + MathUtil.DecimalToHex(17));
            Debug.Log("2转10:" + MathUtil.BinaryToDecimal("101010"));
            Debug.Log("16转10:" + MathUtil.HexToDecimal(0xa));
            Debug.Log("16转10:" + MathUtil.HexToDecimal("0x13"));
            Debug.Log("16转2:" + MathUtil.DecimalToBinary(11));
        }


        public float speed = 36;
        private void Update()
        {
            transform.Rotate(-Vector3.forward, speed * Time.deltaTime);
        }
    }
}


#endif