using UnityEngine;
using System.Collections;
using System;

public class RotateAround : MonoBehaviour, IGvrGazeResponder
{

    public float _speed = 5.0f;

    public void Rotate() {
        transform.Rotate(Vector3.up*_speed);
    }

    public void OnGazeEnter()
    {
        InvokeRepeating("OnGazeStay", 0.0f, 1.0f / 30.0f);
    }

    public void OnGazeExit()
    {
        CancelInvoke("OnGazeStay");
    }

    public void OnGazeStay() {
        Rotate();
    }
    
    public void OnGazeTrigger()
    {
        throw new NotImplementedException();
    }
}
