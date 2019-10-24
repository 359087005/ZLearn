using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZTools
{
    public partial class MonoBehaviourSimplify : MonoBehaviour 
    {
        public void Show()
        {
            GameObjectSimplify.Show(gameObject);
        }
        public void Hide()
        {
            GameObjectSimplify.Hide(gameObject);
        }
        public void Identity()
        {
            TransformSimplify.TransformReset(transform);
        }

    }
    public class Hide : MonoBehaviourSimplify
    {
        private void Awake()
        {
            
            

        }
        string[] AllFile = new string[] {".pgn",".pga",".png",".pgn",".tag",".tga","jpg" };
        private void Start()
        {
            Debug.Log("Start");

            string listTypes = "png|tga|jpg";
            for (int i = 0; i < AllFile.Length; i++)
            {
                if (Regex.IsMatch(AllFile[i], listTypes)) //win平台路径
                {
                    Debug.Log("匹配成功");
                }
            }
           
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/10.Mono简化",false, 10)]
        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            GameObject go = new GameObject();
            go.AddComponent<Hide>();
        }
#endif
    }
}