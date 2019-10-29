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
            if (!mRegisterMsgs.ContainsKey(msgName))
            {
                mRegisterMsgs.Add(msgName, _=> { });
            }
            mRegisterMsgs[msgName] += onMsgReceives;
        }

        public static void UnRegisterAll(string msgName)
        {
            mRegisterMsgs.Remove(msgName);
        }
        public static void UnRegister(string msgName,Action<object> onMsgReceives)
        {
            if (mRegisterMsgs.ContainsKey(msgName))
            {
                mRegisterMsgs[msgName] -= onMsgReceives;
            }
        }

        public static void Send(string msgName, object data)
        {
            if(mRegisterMsgs.ContainsKey(msgName))
            mRegisterMsgs[msgName](data);
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/12.简易消息机制", false, 12)]
#endif
        static void MenuClick()
        {
            UnRegisterAll("消息1");

            Register("消息1", OnMsgReceived);
            Register("消息1", OnMsgReceived);

            Send("消息1", "Hello World");
            UnRegister("消息1", OnMsgReceived);


            Send("消息1", "Hello ");
        }
        static void OnMsgReceived(object data)
        {
            Debug.LogFormat("XXX:{0}",data);
        }
    }
}