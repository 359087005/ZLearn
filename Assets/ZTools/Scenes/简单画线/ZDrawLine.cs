using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ZDrawLine : MonoBehaviour
{
    public float radius = 10f;

    public int pointCount = 5;

    float angle = 0;

    List<Vector3> points = new List<Vector3>();


    LineRenderer lr;
    void Start()
    {
        angle = 360f / pointCount;
        lr = this.GetComponent<LineRenderer>();

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.startColor = Color.green;
        lr.endColor = Color.green;

        CalcutePoint();
    }
    void Update()
    {
        DrawLine();
    }

    void CalcutePoint()
    {
        Quaternion r = transform.rotation;

        for (int i = 0; i < pointCount; i++)
        {
            Quaternion q = Quaternion.Euler(r.eulerAngles.x,r.eulerAngles.y- (angle*i), r.eulerAngles.z);

            Vector3 pos = transform.position + (q * Vector3.forward) * radius;

            points.Add(pos);
        }
    }

    void DrawLine()
    {
        lr.positionCount = pointCount +1;

        for (int i = 0; i < points.Count; i++)
        {
            Debug.DrawLine(transform.position, points[i],Color.blue);
            lr.SetPosition(i,points[i]);
        }
        lr.SetPosition(pointCount,points[0]);
    }
}
