using UnityEngine;

namespace ZTools
{
    public class GameObjectSimplifyExample 
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/GameObject API激活简化", false, 6)]
#endif
        static void MenuClick7()
        {
            GameObject go = new GameObject();
            GameObjectSimplify.Hide(go);

            GameObjectSimplify.Show(go.transform);
        }
    }
}
