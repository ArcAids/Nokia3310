using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float repeatRate=2;
    bool isSpawning=false;
    public void StartSpawning()
    {
        if (!isSpawning)
        { InvokeRepeating("InstansiateBall", 2, repeatRate);
            isSpawning = true;
        }
    }

    public void StopBalls()
    {
        CancelInvoke("InstansiateBall");
    }

    void InstansiateBall()
    {
        Instantiate(ballPrefab,transform.position,Quaternion.identity,null);
    }
}
