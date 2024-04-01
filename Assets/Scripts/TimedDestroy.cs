using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout
//Name: Hunter Wright
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 4/1/2024
/////////////////////////////////////////////
public class TimedDestroy : MonoBehaviour
{
    public float destroyTime = 1f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
