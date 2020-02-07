using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CheckPointSystem : ScriptableObject
{
    [System.NonSerialized]
    Vector3 checkPointPosition=new Vector3(-880,6,0);
    [System.NonSerialized]
    public bool canTeleport=false;

    public void SetCheckPoint(Vector3 position)
    {
        checkPointPosition = position;
    }

    public Vector3 GetPosition()
    { return checkPointPosition; }
}
