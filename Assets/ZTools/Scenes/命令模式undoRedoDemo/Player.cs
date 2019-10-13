using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void MoveDelegate(Vector3 pos);
    public event MoveDelegate MoveEvent;

    public void Move(Vector3 pos)
    {
        if (MoveEvent != null)
        {
            MoveEvent(pos);
        }
    }
}
