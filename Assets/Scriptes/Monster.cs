using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    [SerializeField] Vector2 direction;
    [SerializeField] float speed = 100f;
    [SerializeField] Transform characterPosition;

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterPosition = GameObject.Find("Character").transform;
    }

    protected virtual void FixedUpdate()
    {
        direction = new Vector2(characterPosition.position.x - transform.position.x, characterPosition.position.y - transform.position.y);

        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        State();
    }

    protected virtual void Update()
    {

    }

    public void State()
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

    protected abstract void Attack();
}
