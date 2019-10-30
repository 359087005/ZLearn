using UnityEngine;
using System;

namespace ZTools
{
    public partial class MonoBehaviourSimplify
    {
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

    public class NewBehaviourScript : MonoBehaviour
    {

    }
}
