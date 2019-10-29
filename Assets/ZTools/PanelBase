using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buskit3D_CaiLiao
{
    /// <summary>
    /// 面板基类
    /// </summary>
    public abstract class PanelBase : MonoBehaviour
    {
        public string stringKey;

        public virtual void Start()
        {
            ZUIManager.instance.panelDic.Add(stringKey, this);
            OnExit();
        }

        public virtual void OnEnter()
        {
            transform.localPosition = Vector3.zero;
        }

        public virtual void OnExit()
        {
            Vector3 temp = this.transform.localPosition;
            temp.x = 2000;
            this.transform.localPosition = temp;
        }

        public virtual void OnInit()
        {

        }

        public virtual void OnPushPanel(string panelTypeString)
        {
            ZUIManager.instance.PushPanel(panelTypeString);
        }
    }
}
