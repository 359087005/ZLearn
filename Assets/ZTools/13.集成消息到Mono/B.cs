using UnityEngine;
using System.Collections.Generic;
using System;

namespace ZTools
{
    public abstract partial class MonoBehaviourSimplify
    {
        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

        private class MsgRecord
        {
            public string MsgName;
            public Action<object> onMsgReceive;
        }

        public void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            //构造器初始化
            mMsgRecorder.Add(new MsgRecord { MsgName = msgName,onMsgReceive = onMsgReceived});
        }

        void OnDestroy()
        {
            BeforeDestroy();
            foreach (var item in mMsgRecorder)
            {
                MsgDispatcher.UnRegister(item.MsgName, item.onMsgReceive);
            }
            mMsgRecorder.Clear();
        }

        protected abstract void BeforeDestroy();
    }

    public class B : MonoBehaviourSimplify
    {
        protected override void BeforeDestroy()
        {
           
        }
    }
}