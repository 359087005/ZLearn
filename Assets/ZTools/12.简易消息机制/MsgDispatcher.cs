using UnityEngine;
using System.Collections.Generic;
using System;

namespace ZTools
{
    public class MsgDispatcher : MonoBehaviour
    {
        static Dictionary<string, Action<object>> mRegisterMsgs = new Dictionary<string, Action<object>>();

        public static void Register(string msgName, Action<object> onMsgReceives)
        {
            mRegisterMsgs.Add(msgName, onMsgReceives);
        }

        public static void UnRegister(string msgName)
        {
            mRegisterMsgs.Remove(msgName);
        }

        public static void Send(string msgName, object data)
        {
            mRegisterMsgs[msgName](data);
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/12.简易消息机制", false, 12)]
#endif
        static void MenuClick()
        {
            Register("消息1", (data) =>
             {
                 Debug.LogFormat("消息:{0}", data);
             });

            Send("消息1", "Hello World");

            UnRegister("消息1");

            Send("消息1", "Hello World");
        }
    }
}