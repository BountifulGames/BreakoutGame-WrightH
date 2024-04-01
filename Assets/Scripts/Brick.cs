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
public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject brickParticle;
    private GameManager GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.DestroyBrick();
        Destroy(gameObject);
    }

}
