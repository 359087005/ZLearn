using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ZTools
{
    public abstract partial class MonoBehaviourSimplify : MonoBehaviour 
    {
        #region Delay
        public void Delay(float second, Action onFinished)
        {
            StartCoroutine(DelayCoroutine(second, onFinished));
        }


        private IEnumerator DelayCoroutine(float second, Action onFinished)
        {
            yield return new WaitForSeconds(second);
            onFinished();
        }

        #endregion

        #region DisPatcher
        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

        private class MsgRecord
        {
            private MsgRecord() { }

            static Stack<MsgRecord> msgRecordPool = new Stack<MsgRecord>();

            public static MsgRecord Allocate(string msgName, Action<object> msgReceive)
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

        public void SendMsg(string msgName, object onMsgReceive)
        {
            MsgDispatcher.Send(msgName, onMsgReceive);
        }

        public void UnRegisterMsg(string msgName)
        {
            var selectRecords = mMsgRecorder.FindAll(record => record.MsgName == msgName);

            selectRecords.ForEach(record =>
            {
                MsgDispatcher.UnRegister(record.MsgName, record.onMsgReceive);
                mMsgRecorder.Remove(record);

                record.Recycle();
            });
            selectRecords.Clear();
        }

        public void UnRegisterMsg(string msgName, Action<object> onMsgReceive)
        {
            var selectRecords = mMsgRecorder.FindAll(record => record.MsgName == msgName && record.onMsgReceive == onMsgReceive);
            selectRecords.ForEach(record =>
            {
                MsgDispatcher.UnRegister(record.MsgName, record.onMsgReceive);
                mMsgRecorder.Remove(record);

                record.Recycle();
            });
            selectRecords.Clear();
        }

        public void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            //构造器初始化
            mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReceived));
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
        #endregion


        
    }
}