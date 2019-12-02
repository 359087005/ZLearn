using UnityEngine;

namespace ZTools
{
    public class GameObjectSimplifyExample 
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/GameObject API激活简化", false, 6)]

        static void MenuClick7()
        {
            GameObject go = new GameObject();
            go.Hide();
            go.Show();
        }
#endif
    }
}
