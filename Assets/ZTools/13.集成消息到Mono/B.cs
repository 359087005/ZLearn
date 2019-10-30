using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

namespace ZTools
{
    public abstract partial class MonoBehaviourSimplify
    {
        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

        private class MsgRecord
        {
            private MsgRecord() { }

            static Stack<MsgRecord> msgRecordPool = new Stack<MsgRecord>();

            public static MsgRecord Allocate(string msgName,Action<object> msgReceive)
            {
                MsgRecord msg = null;
                if (msgRecordPool.Count > 0)
                {
                    msg = msgRecordPool.Pop();
                }
                else
                {
                    msg = new MsgRecord();
                }
                msg.MsgName = msgName;
                msg.onMsgReceive = msgReceive;
                return msg;
            }

            public void Recycle()
            {
                MsgName = null;
                onMsgReceive = null;

                msgRecordPool.Push(this);
            }

            public string MsgName;
            public Action<object> onMsgReceive;
        }

        public void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            //构造器初始化
            mMsgRecorder.Add(MsgRecord.Allocate(msgName,onMsgReceived));
        }

        void OnDestroy()
        {
            BeforeDestroy();
            foreach (var item in mMsgRecorder)
            {
                MsgDispatcher.UnRegister(item.MsgName, item.onMsgReceive);
                item.Recycle();
            }
            mMsgRecorder.Clear();
        }

        protected abstract void BeforeDestroy();
    }

    public class B : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/13.消息分发实例", false, 13)]
#endif
        private static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("Zhou").AddComponent<B>();
        }

        private void Awake()
        {
            RegisterMsg("Do", DoSth);
            RegisterMsg("Do", DoSth);
            RegisterMsg("Do1", _ => { });
            RegisterMsg("Do2", _ => { });
            RegisterMsg("Do3", _ => { });
            RegisterMsg("Do4", _ => { });
        }

        IEnumerator Start()
        {
            MsgDispatcher.Send("Do","123");
            yield return new WaitForSeconds(1f);
            MsgDispatcher.Send("Do", "456");
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