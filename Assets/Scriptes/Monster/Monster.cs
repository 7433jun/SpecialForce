using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    WALK,
    ATTACK,
    HIT,
    DIE
}

public abstract class Monster : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    protected Animator animator;
    [SerializeField] private float power = 10f;

    [SerializeField] STATE state;
    [SerializeField] Vector2 direction;
    [SerializeField] Transform characterPosition;

    [SerializeField] protected float attack;
    [SerializeField] protected float health;
    [SerializeField] protected float speed = 100f;

    [SerializeField] Sound sound = new Sound();

    protected void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        characterPosition = GameObject.Find("Character").transform;
    }

    protected virtual void FixedUpdate()
    {
        switch (state)
        {
            case STATE.WALK: Move();
                break;
            case STATE.ATTACK: Attack();
                break;
            case STATE.HIT:
                break;
            case STATE.DIE: Death();
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OnHit(attack));
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
        animator.SetBool("Attack", false);

        direction = new Vector2(characterPosition.position.x - transform.position.x, characterPosition.position.y - transform.position.y);

        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        InvertImage();
    }    

    public void Damage()
    {
        characterPosition.GetComponent<Character>().OnHit(attack);
    }

    public IEnumerator OnHit(float damage)
    {
        state = STATE.HIT;

        rigidbody2D.velocity = Vector2.zero;

        health -= damage;

        if (health <= 0)
        {
            state = STATE.DIE;

            yield break;
        }

        AudioManager.instance.Sound(sound.audioClip[0]);

        rigidbody2D.AddForce(-direction * power, ForceMode2D.Force);

        yield return CoroutineCache.waitForSeconds(0.25f);

        state = STATE.WALK;
    }

    public void Release()
    {
        Destroy(gameObject);
    }

    protected abstract void Attack();

    protected abstract void Death();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            if (state != STATE.DIE)
            {
                state = STATE.ATTACK;
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            if (state != STATE.DIE)
            {
                state = STATE.WALK;
            }
        }
    }
}
