using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 具体业务逻辑代码
/// </summary>
public class CommandTest : MonoBehaviour
{
    public Camera MainCamera; //主摄像机

    public Player ge; //玩家Player

    CmdMgr cmdMgr;
    void Awake()
    {
        Init();
    }
    void Update()
    {
        PlayerMove();
        BackCommand();
    }
    /// <summary>
    /// 控制场景Cube移动
    /// </summary>
    private void PlayerMove()
    {
        if (CheckGuiRaycastObjects())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ge.Move(hit.point);
            }
        }
    }
    string oldname;
    public InputField inputFiledName;
    string oldpw;
    public InputField pw;

    [Header("防止UI穿透")]
    public EventSystem myEventSystem;
    public GraphicRaycaster myRayCaster;
    /// <summary>
    /// 检测UI是否遮挡
    /// </summary>
    /// <returns></returns>
    bool CheckGuiRaycastObjects()
    {
        PointerEventData eventData = new PointerEventData(myEventSystem);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;

        List<RaycastResult> list = new List<RaycastResult>();
        myRayCaster.Raycast(eventData, list);
        return list.Count > 0;
    }

    /// <summary>
    /// 后退
    /// </summary>
    private void BackCommand()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cmdMgr.BackCommand();
            Debug.Log("我执行了BackCommand," + "可回退数量:" + cmdMgr.backCommands.Count);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            cmdMgr.CancleCommand();
        }
    }
    /// <summary>
    /// 初始化
    /// </summary>
    void Init()
    {
        cmdMgr = new CmdMgr();

        inputFiledName.onEndEdit.AddListener((string value) =>
        {
            cmdMgr.Execute(new InputCommand(inputFiledName, value,oldname));
            oldname = value;
            Debug.Log(cmdMgr.backCommands.Count);
        });
        pw.onEndEdit.AddListener((string value) =>
        {
            cmdMgr.Execute(new InputCommand(pw, value,oldpw));
            oldpw = value;
            Debug.Log(cmdMgr.backCommands.Count);
        });

        ge.MoveEvent += (Vector3 pos) =>
         {
             cmdMgr.Execute(new PlayerCommand(ge, ge.transform.position,pos));
             Debug.Log("我执行了移动..."+ cmdMgr.backCommands.Count);
         };
    }
}
