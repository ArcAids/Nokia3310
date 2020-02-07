using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed=1500;
    [SerializeField] float jumpPower=5;
    [SerializeField] LayerMask groundLayer;
    IWalkInput walkInput;
    IJumpInput jumpInput;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer sprite;
    float speed;
    
    int walkAnimationHash = Animator.StringToHash("Walking");

    float horizontalVel;
    float verticalVel;
    float gravityMult=25;
    float normalGravity;
    bool canJump;
    const float jumpDelay = 0.5f;
    float jumpTimer = 0;
    private void Start()
    {
        walkInput = GetComponent<IWalkInput>();
        jumpInput = GetComponent<IJumpInput>();
        rigid = GetComponent<Rigidbody2D>();
        
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        normalGravity = rigid.gravityScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(walkInput.Horizontal) > 0)
            horizontalVel = walkInput.Horizontal * speed * Time.deltaTime;
        else
            horizontalVel= rigid.velocity.x * Mathf.Pow(0.1f, Time.deltaTime * 10f);

        if(canJump && jumpInput.Jump)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            canJump = false;
            jumpTimer = jumpDelay;
        }

        if (rigid.velocity.y < -1f)
        {
            rigid.gravityScale = gravityMult;
        }
        else
            rigid.gravityScale =normalGravity;

        rigid.velocity = new Vector2(horizontalVel, rigid.velocity.y);
    }

    private void Update()
    {
        if (jumpTimer <= 0)
        {
            RaycastHit2D raycast = Physics2D.BoxCast(transform.position - transform.up * 5, Vector2.one, 0, Vector2.down, 1, groundLayer);

            if (raycast)
            {
                //Debug.Log("raycast hit" + raycast.collider.name);
                canJump = true;
            }
            else
                canJump = false;
        }
        else
        {
            jumpTimer -= Time.deltaTime;
            canJump = false;
        }


        Debug.DrawLine(transform.position - transform.up *5, transform.position - transform.up *5 + Vector3.down,Color.red);
        sprite.flipX = walkInput.Horizontal < 0 ? true:walkInput.Horizontal==0?sprite.flipX :false;
        animator.SetBool(walkAnimationHash, Mathf.Abs(walkInput.Horizontal) > 0.01f);

    }

    public void HalfSpeed()
    {
        speed = speed * 0.5f;
    }

    private void OnEnable()
    {
        speed = maxSpeed;
    }
}
