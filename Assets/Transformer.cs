using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Transformer : MonoBehaviour
{
    public UnityAction onAction;
    Animator animator;
    public UnityAction onDown;
    CharacterInput input;
    [SerializeField] SpriteRenderer chargeBar;

    [SerializeField] float transformationDelay=0;

    int actionAnimationHash = Animator.StringToHash("Action");
    float timer;

    private void Awake()
    {
        input=GetComponent<CharacterInput>();
        animator=GetComponent<Animator>();
    }

    private void Update()
    {
        if (input.Cloned && timer<0)
        {
            
            animator.SetTrigger(actionAnimationHash);
        }
        if (input.Teleport && onDown!=null)
        {
            onDown.Invoke();
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;

            if(chargeBar!=null)
                chargeBar.transform.localScale = new Vector2(6-(timer/transformationDelay)*6,1);
        }
    }

    public void Switch()
    {
        onAction.Invoke();
    }

    public void Disable()
    {
        input.Disable();
        if (chargeBar != null)
            chargeBar.enabled = false;
    }
    public void Activate(Vector3 position)
    {
        if(timer<=0)
            timer = transformationDelay;
        Enable();
        transform.position = position;
        gameObject.SetActive(true);
        if (chargeBar != null)
            chargeBar.enabled = true;
    }

    public void Enable()
    {
        input.Enable();
    }
}