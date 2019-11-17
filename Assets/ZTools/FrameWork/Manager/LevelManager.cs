using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 现在基本遗弃这种做法 都是一场景搞定
/// </summary>
namespace ZTools
{
    public class LevelManager 
    {
        private static List<string> myNameList;

        public static int index;

        public static void Init(List<string> sceneNameList)
        {
            myNameList = sceneNameList;
            index = 0;
        }

        public static void LoadScene()
        {
            SceneManager.LoadScene(myNameList[index]);
        }

        public static void LoadNextScene()
        {
            index++;

            SceneManager.LoadScene(myNameList[index]);
        }
    }
}
