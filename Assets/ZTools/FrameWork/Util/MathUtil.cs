using System;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ZTools
{
    public partial class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }

        public static T GetRandomValues<T>(params T[] values)
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }

        /// <summary>
        /// 10转2
        /// </summary>
        /// <returns></returns>
        public static string DecimalToBinary(int num)
        {
            string binaryStr = Convert.ToString(num, 2);
            return binaryStr;
        }

        /// <summary>
        /// 10转16
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string DecimalToHex(int num)
        {
            string binaryStr = Convert.ToString(num, 16);
            return binaryStr;
        }

        /// <summary>
        /// 二进制转10进制
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int BinaryToDecimal(string num)
        {
            int decimalNum = Convert.ToInt32(num,2);
            return decimalNum;
        }
        
        /// <summary>
        /// 16进制转10进制
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string HexToDecimal(int num)
        {
           string decimalStr =  Convert.ToString(num, 10);
            return decimalStr;
            //hexStr = hexStr.ToString("") + "\n";
        }

        /// <summary>
        /// 16进制转10进制
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int HexToDecimal(string num)
        {
            int decimalStr = Convert.ToInt32(num,16);
            return decimalStr;
        }

        /// <summary>
        /// 16进制转2进制
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string HexToBinary(int num)
        {
            string decimalStr= Convert.ToString(num,2);
            return decimalStr;
        }
    }
}