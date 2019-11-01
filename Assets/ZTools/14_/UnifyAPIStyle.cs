using UnityEngine;
using System;

namespace ZTools
{
    public partial class MonoBehaviourSimplify
    {
        public void SendMsg(string msgName, object onMsgReceive)
        {
            MsgDispatcher.Send(msgName,onMsgReceive);
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

        public void UnRegisterMsg(string msgName,Action<object> onMsgReceive)
        {
            var selectRecords = mMsgRecorder.FindAll(record => record.MsgName == msgName && record.onMsgReceive== onMsgReceive);
            selectRecords.ForEach(record =>
            {
                MsgDispatcher.UnRegister(record.MsgName, record.onMsgReceive);
                mMsgRecorder.Remove(record);

                record.Recycle();
            });
            selectRecords.Clear();
        }
    }

    public class UnifyAPIStyle : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/14.统一API风格", false, 14)]
#endif
        private static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("AAA").AddComponent<UnifyAPIStyle>();
        }

        private void Awake()
        {
            RegisterMsg("OK",data=>
            {
                Debug.Log(data);

                UnRegisterMsg("OK");
            });
        }

        private void Start()
        {
            SendMsg("OK","hello");
            SendMsg("OK", "hello");
        }

        protected override void BeforeDestroy()
        {
           
        }
    }
}
