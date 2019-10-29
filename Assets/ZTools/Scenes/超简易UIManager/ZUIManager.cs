using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Buskit3D_CaiLiao
{
    /// <summary>
    /// UI管理  
    /// </summary>
    public class ZUIManager : MonoBehaviour
    {
        public static ZUIManager instance;
        public Dictionary<string, PanelBase> panelDic = new Dictionary<string, PanelBase>();
        public Stack<PanelBase> panelStack = new Stack<PanelBase>();

        public void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            //this.BuZhouTiShi("请选择实验内容");
            PushPanel("FirstPanel");
        }
        /// <summary>
        /// 把某个页面入栈，  把某个页面显示在界面上
        /// </summary>
        public void PushPanel(string panelStr)
        {
            //判断一下栈里面是否有页面
            if (panelStack.Count > 0)
            {
                PanelBase topPanel = panelStack.Peek();
                topPanel.OnExit();
            }
            PanelBase panel = GetPanel(panelStr);
            panel.OnInit();
            panel.OnEnter();
            panelStack.Push(panel);
        }

        public void PopPanel()
        {
            if (panelStack.Count <= 0) return;
            //关闭栈顶页面的显示
            PanelBase topPanel = panelStack.Pop();
            topPanel.OnExit();
            if (panelStack.Count <= 0) return;
            PanelBase topPanel2 = panelStack.Peek();
            topPanel2.OnInit();
            topPanel2.OnEnter();
        }

        PanelBase GetPanel(string panelStr)
        {
            PanelBase panel;
            if (panelDic.TryGetValue(panelStr, out panel))
            {
                return panel;
            }
            else
            {
                Debug.LogError("panel未添加");
                return panel;
            }
        }
    }
}
