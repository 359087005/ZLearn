using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

namespace ZTools
{
    public class FrameworkExample: MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/框架实例", false,10)]

        private static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("Zhou").AddComponent<FrameworkExample>();
        }
#endif
        private void Awake()
        {
            UnRegisterMsg("Do");
            UnRegisterMsg("OK");

            RegisterMsg("Do", DoSth);
            RegisterMsg("Do", DoSth);
            RegisterMsg("Do1", _ => { });
            RegisterMsg("Do2", _ => { });
            RegisterMsg("Do3", _ => { });
            RegisterMsg("Do4", _ => { });

            RegisterMsg("OK", data =>
            {
                Debug.Log(data);

                UnRegisterMsg("OK");
            });
        }

        IEnumerator Start()
        {
            MsgDispatcher.Send("Do","123");
            yield return new WaitForSeconds(1f);
            MsgDispatcher.Send("Do", "456");

            SendMsg("OK", "hello");
            SendMsg("OK", "hello");
        }

        void DoSth(object data)
        {
            Debug.LogFormat("the data is {0}",data);
        }


        protected override void BeforeDestroy()
        {
           
        }
    }
}