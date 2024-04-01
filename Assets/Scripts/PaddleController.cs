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
public class PaddleController : MonoBehaviour
{
    private float paddleSpeed;
    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    private void Start()
    {
        paddleSpeed = 100f;
    }
    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
        transform.position = playerPos;
    }

}
