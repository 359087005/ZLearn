using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
/// <summary>
/// 动态画线
/// </summary>
public class ZDynamicLineManager : MonoBehaviour
{
    public List<Transform> transformList = new List<Transform>();
    Vector3[] tempVector3s;

    [Range(0.001f, 1)]
    public float smoothSpeed;

    public int smoothValue = 2;
    LineRenderer lineRenderer;

    bool isDraw = true;
    void Start()
    {
        InitLineRenderer();
        InitPoints();
    }
    void Update()
    {
            DynamicDrawLine();
    }
    /// <summary>
    /// 初始化线段
    /// </summary>
    void InitLineRenderer()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }
    /// <summary>
    /// 初始化点     把子物体的transform添加到list
    /// </summary>
    void InitPoints()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transformList.Add(transform.GetChild(i));
        }
    }

    void DynamicDrawLine()
    {
        if (isDraw)
        {
            isDraw = false;
            GetPoints();
            StartCoroutine("MoveLine");
        }
    }

    /// <summary>
    /// 自动线条生成
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveLine()
    {
        WaitForSeconds wait = new WaitForSeconds((smoothSpeed* transformList.Count/2.0f) / transformList.Count);
        Debug.Log(tempVector3s.Length + "   tempVector3s.Length");
        for (int i = 0; i < tempVector3s.Length; i++)
        {
            lineRenderer.positionCount = i + 1;
            //render.SetVertexCount(i+1);
            lineRenderer.SetPosition(i, tempVector3s[i]);
            yield return  wait;
        }

        isDraw = true;
    }
    /// <summary>
    /// 根据Transform获取目标路径点
    /// </summary>
    void GetPoints()
    {
        Vector3[] vecs = new Vector3[transformList.Count];
        for (int i = 0; i < vecs.Length; i++)
        {
            vecs[i] = transformList[i].position;
        }
        tempVector3s = DrawPathHelper(vecs);
    }
    /// <summary>
    /// 根据给定路线点绘制路线
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private Vector3[] DrawPathHelper(Vector3[] path)
    {
        Vector3[] vector3s = PathControlPointGenerator(path);
        //Line Draw:
        Vector3 prevPt = Interp(vector3s, 0);
        int SmoothAmount = path.Length * 5* smoothValue;
        Vector3[] retValue = new Vector3[SmoothAmount + 1];
        retValue[0] = prevPt;

        for (int i = 1; i <= SmoothAmount; i++)
        {
            float pm = (float)i / SmoothAmount;
            Vector3 currPt = Interp(vector3s, pm);
            retValue[i] = currPt;
        }
        return retValue;
    }

    /// <summary>
    /// 路线控制点生成
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private Vector3[] PathControlPointGenerator(Vector3[] path)
    {
        Vector3[] suppliedPath;
        Vector3[] vector3s;

        suppliedPath = path;

        int offset = 2;
        vector3s = new Vector3[suppliedPath.Length + offset];
        Array.Copy(suppliedPath, 0, vector3s, 1, suppliedPath.Length);

        vector3s[0] = vector3s[1] + (vector3s[1] - vector3s[2]);
        vector3s[vector3s.Length - 1] = vector3s[vector3s.Length - 2] + (vector3s[vector3s.Length - 2] - vector3s[vector3s.Length - 3]);

        if (vector3s[1] == vector3s[vector3s.Length - 2])
        {
            Vector3[] tmpLoopSpline = new Vector3[vector3s.Length];
            Array.Copy(vector3s, tmpLoopSpline, vector3s.Length);
            tmpLoopSpline[0] = tmpLoopSpline[tmpLoopSpline.Length - 3];
            tmpLoopSpline[tmpLoopSpline.Length - 1] = tmpLoopSpline[2];
            vector3s = new Vector3[tmpLoopSpline.Length];
            Array.Copy(tmpLoopSpline, vector3s, tmpLoopSpline.Length);
        }

        return (vector3s);
    }

    /// <summary>
    /// 中间处理
    /// </summary>
    /// <param name="pts"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    private Vector3 Interp(Vector3[] pts, float t)
    {
        int numSections = pts.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)currPt;

        Vector3 a = pts[currPt];
        Vector3 b = pts[currPt + 1];
        Vector3 c = pts[currPt + 2];
        Vector3 d = pts[currPt + 3];

        return .5f * (
            (-a + 3f * b - 3f * c + d) * (u * u * u)
            + (2f * a - 5f * b + 4f * c - d) * (u * u)
            + (-a + c) * u
            + 2f * b
        );
    }
}
