using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    WALK,
    ATTACK,
    DIE
}

public abstract class Monster : MonoBehaviour
{
    private float initSpeed;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    protected Animator animator;

    [SerializeField] STATE state;
    [SerializeField] Vector2 direction;
    [SerializeField] protected float speed = 100f;
    [SerializeField] Transform characterPosition;

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        characterPosition = GameObject.Find("Character").transform;

        initSpeed = speed;
    }

    protected virtual void FixedUpdate()
    {
        switch (state)
        {
            case STATE.WALK: Move();
                break;
            case STATE.ATTACK: Attack();
                break;
            case STATE.DIE: Death();
                break;
            default:
                break;
        }
    }

    public void InvertImage()
    {
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    protected void Move()
    {
        speed = initSpeed;

        animator.SetBool("Attack", false);

        direction = new Vector2(characterPosition.position.x - transform.position.x, characterPosition.position.y - transform.position.y);

        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        InvertImage();
    }    

    protected abstract void Attack();

    protected abstract void Death();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            state = STATE.ATTACK;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            state = STATE.WALK;
        }
    }
}
