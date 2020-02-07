using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggered;
    [SerializeField] UnityEvent onExit;
    [SerializeField] string enemyTag;
    [SerializeField] string dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag(enemyTag))
        {
            onTriggered.Invoke();
            GameManager.Instance.Say(dialogue);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag(enemyTag))
        {
            onExit.Invoke();
        }
    }
}
