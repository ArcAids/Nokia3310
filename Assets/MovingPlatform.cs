using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] Transform platform;
    [SerializeField] float speed;
    [SerializeField] bool loop;
    [SerializeField] bool playOnAwake;

    Vector3 startPosition;

    private void Awake()
    {
        if (playOnAwake)
            StartPlatform();
    }

    public void StartPlatform()
    {
        startPosition = platform.transform.position;
        if (loop)
            StartCoroutine(LoopPlat());
        else
            StartCoroutine(MovePlat());
    }

    IEnumerator MovePlat()
    {
        while(platform.transform.position!=destination.position)
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, destination.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    
    IEnumerator LoopPlat()
    {
        while(true)
        {
            while (platform.transform.position != destination.position)
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, destination.position, speed * Time.deltaTime);
                yield return null;
            }
            while (platform.transform.position != startPosition)
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, startPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
