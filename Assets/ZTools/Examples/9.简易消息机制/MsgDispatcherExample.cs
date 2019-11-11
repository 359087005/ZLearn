
using UnityEngine;
namespace ZTools
{
    public class MsgDispatcherExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/简易消息机制", false, 9)]
#endif
        static void MenuClick()
        {
            MsgDispatcher.UnRegisterAll("消息1");

            MsgDispatcher.Register("消息1", OnMsgReceived);
            MsgDispatcher.Register("消息1", OnMsgReceived);

            MsgDispatcher.Send("消息1", "Hello World");
            MsgDispatcher. UnRegister("消息1", OnMsgReceived);

            MsgDispatcher.Send("消息1", "Hello ");
        }
        static void OnMsgReceived(object data)
        {
            Debug.LogFormat("XXX:{0}", data);
        }
    }
}
