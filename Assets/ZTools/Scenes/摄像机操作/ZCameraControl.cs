//using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCameraControl : MonoBehaviour
{
    public static ZCameraControl instance;   //zyq
    [Header("相机目标点")]
    public Transform target; //相机一点目标点
    public bool isCanRot = true;
    public float distance = 10.0f;
    public float MinDist = 0.3f;
    public float MaxDist = 10.0f;

    private float xSpeed = 250.0f;
    private float ySpeed = 250.0f;//120

    //private bool isAnim;

    //private float x = 0.0f;
    //private float y = 0.0f;
    //bool controlFlag = false;

    //CreateUI pre;

    //标记是否能旋转和移动
    public bool isCanMove = true;
    public float moveSpeed = 0.5f;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        var angles = transform.eulerAngles;
        //x = angles.y;
        //y = angles.x;
    }
    //public Transform start, end, cameraPos;

    ////10.09周寒冰 添加查看具体效果
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        MoveToDestination(
    //            start.transform.position,
    //            target.transform.eulerAngles,
    //            6, 2, 3);
    //    }
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        LookAtMoveToDestination(end.position, cameraPos.position, 10, 3);
    //    }
    //}

    void LateUpdate()
    {
        //if (isAnim)
        //    return;
        if (isCanRot)
        {
            UpdateRotate();
        }
        if (isCanMove)
        {
            UpdateMove();
        }
    }
    /// <summary>
    /// 更新旋转
    /// 1.获取当前摄像机旋转
    /// 2,修改该旋转 (通过鼠标的XY轴计算)
    /// 3,将新值重新赋值给当前
    /// 4.修改目标物体旋转与当前相同
    /// 5.远近距离限制.
    /// </summary>
    void UpdateRotate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 a = transform.eulerAngles;
            a.y += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            a.x -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            transform.rotation = Quaternion.Euler(a.x, a.y, a.z);
            target.transform.rotation = Quaternion.Euler(a.x, a.y, a.z);
        }
        distance = distance - Input.GetAxis("Mouse ScrollWheel") * 10;
        distance = Mathf.Clamp(distance, MinDist, MaxDist);
        transform.position = target.position - transform.forward * distance;
        //target永远在transformd物体的前方，target坐标假定恒定
        //target永远在transformd物体的前方，则transform的坐标需要用减法
    }
    /// <summary>
    /// 1,根据鼠标XY轴 修改目标物体位置 拉远拉近 
    /// 2,根据滑轮设置远近限制。
    /// </summary>
    void UpdateMove()
    {
        if (Input.GetMouseButton(1))
        {
            target.Translate(-Input.GetAxis("Mouse X") * moveSpeed,
                  -Input.GetAxis("Mouse Y") * moveSpeed,
                0, Space.Self);
            distance = distance - Input.GetAxis("Mouse ScrollWheel") * 10;
            distance = Mathf.Clamp(distance, MinDist, MaxDist);
            transform.position = target.position - transform.forward * distance;
        }
    }

    void SetDelay(float delay, Action action)
    {
        StartCoroutine(DelayAction(delay, action));
    }
    IEnumerator DelayAction(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    ///// <summary>
    ///// 摄像机动画
    ///// </summary>
    ///// <param name="targetPos"></param>
    ///// <param name="targeRot"></param>
    ///// <param name="dis"></param>
    ///// <param name="delay"></param>
    ///// <param name="time"></param>
    ///// <returns></returns>
    //public Tweener MoveToDestination(Vector3 targetPos, Vector3 targeRot, float dis, float delay, float time)
    //{
    //    SetDelay(delay, () => isAnim = true);
    //    Tweener t = default(Tweener);

    //    target.transform.DOLocalMove(targetPos, time).SetDelay(delay);
    //    target.transform.DOLocalRotate(targeRot, time).SetDelay(delay);
    //    transform.DOLocalRotate(targeRot, time).SetDelay(delay);
        
    //    t = DOTween.To(() => distance, x =>
    //    {
    //        distance = x;
    //        transform.position = target.position - transform.forward * distance;
    //    }, dis, time).SetDelay(delay).OnComplete(() =>
    //    {
    //        isAnim = false;
    //    });

    //    return t;
    //}

    ///// <summary>
    ///// 朝向物体的摄像机动画
    ///// </summary>
    ///// <param name="targetPos"></param>
    ///// <param name="cameraStartPos"></param>
    ///// <param name="dis"></param>
    ///// <param name="time"></param>
    ///// <returns></returns>
    //public Tweener LookAtMoveToDestination(Vector3 targetPos, Vector3 cameraStartPos, float dis, float time)
    //{
    //    isAnim = true;
    //    Tweener t = default(Tweener);

    //    target.transform.position = targetPos;
    //    Quaternion dir = Quaternion.LookRotation(target.transform.position - transform.position);
    //    target.transform.eulerAngles = dir.eulerAngles;
    //    Vector3 pos = target.transform.position - (target.transform.position - cameraStartPos).normalized * dis;
    //    transform.DOMove(pos, time).SetEase(Ease.InOutQuad);
    //    transform.DORotate(dir.eulerAngles, time).SetEase(Ease.InOutQuad).OnComplete(() =>
    //    {
    //        isAnim = false;
    //    });
           
    //    t = DOTween.To(() => distance, x =>
    //    {
    //        distance = x;
    //    }, dis, time);

    //    return t;
    //}

}
