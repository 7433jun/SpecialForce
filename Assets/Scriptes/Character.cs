using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 넣었지만 확인용으로 쓰는걸 권장
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Character : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Material originMaterial;

    [SerializeField] Vector2 direction;
    [SerializeField] float health = 100f;
    [SerializeField] float speed;
    [SerializeField] Material flashMaterial;

    [SerializeField] List<Weapon> weaponList;
    [SerializeField] Weapon weapon;
    int weaponIndex;

    private WaitForSeconds waitForSeconds = new WaitForSeconds(0.125f);

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originMaterial = spriteRenderer.material;

        weapon = weaponList[weaponIndex];
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
            ChangeWeapon();
        }
    }

    public void OnHit(float damage)
    {
        health -= damage;
        Debug.Log($"health = {health}");

        StartCoroutine(Flash());

        if (health <= 0)
        {
            Debug.Log("Death");
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

    public void ChangeWeapon()
    {
        weaponIndex++;

        if (weaponIndex >= weaponList.Count) weaponIndex = 0;

        weapon = weaponList[weaponIndex];

        Debug.Log(weaponList[weaponIndex]);
    }

    IEnumerator Flash()
    {
        spriteRenderer.material = flashMaterial;

        yield return waitForSeconds;

        spriteRenderer.material = originMaterial;
    }
}
