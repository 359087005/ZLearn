using System.Collections.Generic;
using UnityEngine;

namespace ZTools
{
    /// <summary>
    /// 维护全局资源缓存池
    /// </summary>
    public class ResMgr : MonoSingleton<ResMgr>
    {
        public  List<Res> sharedLoadRes = new List<Res>();

#if UNITY_EDITOR
        private void OnGUI()
        {
            if (Input.GetKey(KeyCode.F1))
            {
                GUILayout.BeginVertical("box");
                sharedLoadRes.ForEach(loadedRes =>
                {
                    GUILayout.Label(string.Format("Name:{0} RefCount:{1}", loadedRes.Name, loadedRes.RefCount));
                });
                GUILayout.EndVertical();
            }
        }
#endif
    }
}

