using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] UnityEvent onDeath;
    [SerializeField] string enemyTag;
    [SerializeField] bool canBeDamaged=true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDamaged)
            return;
        if(collision.CompareTag(enemyTag))
        {
            onDeath.Invoke();        
        }
    }

    public void EnableDamage()
    {
        canBeDamaged = true;
    }
}
