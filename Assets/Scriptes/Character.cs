using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 넣었지만 확인용으로 쓰는걸 권장
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Character : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Material originMaterial;

    [SerializeField] Vector2 direction;
    [SerializeField] float speed;
    [SerializeField] Material flashMaterial;

    private WaitForSeconds waitForSeconds = new WaitForSeconds(0.125f);

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originMaterial = spriteRenderer.material;
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        State();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Flash());
        }
    }

    public void State()
    {
        if (direction != Vector2.zero)
        {
            animator.SetBool("Walk", true);

            if(direction.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    IEnumerator Flash()
    {
        spriteRenderer.material = flashMaterial;

        yield return waitForSeconds;

        spriteRenderer.material = originMaterial;
    }
}
