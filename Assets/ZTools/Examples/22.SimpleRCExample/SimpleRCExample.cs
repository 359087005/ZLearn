using UnityEngine;

namespace ZTools
{
    public class mLight
    {
        public void Open()
        {
            Debug.Log("开灯");
        }
        public void Close()
        {
            Debug.Log("关灯");
        }
    }
    public class SimpleRCExample : SimpleRC
    {
        mLight light = new mLight();


        public void EnterPeople()
        {
            Retain();
            Debug.LogFormat("一个人进入了房间，房内有{0}人", RefCount);
            if (RefCount == 1)
            {
                light.Open();
            }
        }

        public void LeavePeople()
        {
            Release();
            Debug.LogFormat("一个人离开了房间，房内有{0}人", RefCount);
        }

        protected override void OnZeroRef()
        {
           
                light.Close();
           
        }


#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/SimpleRCExample", false, 22)]

        static void MenuItem()
        {
            SimpleRCExample exam = new SimpleRCExample();
            exam.EnterPeople();
            exam.EnterPeople();
            exam.EnterPeople();
            exam.LeavePeople();
            exam.LeavePeople();
            exam.LeavePeople();
            exam.EnterPeople();
        }
#endif
    }
}