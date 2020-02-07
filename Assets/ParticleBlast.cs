using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBlast : MonoBehaviour
{
    ParticleSystem blast;

    private void Awake()
    {
        blast = GetComponentInChildren<ParticleSystem>();
        blast.transform.parent = null;
    }

    public void Blast()
    {
        blast.transform.position = transform.position;
        blast.Play();
    }
}
