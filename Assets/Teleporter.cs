using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour, ITeleport
{

    public bool Teleport { get => Input.GetKey(KeyCode.S); } 


}
