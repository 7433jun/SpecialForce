using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBall : Weapon
{
    [SerializeField] float angle;
    [SerializeField] float offset;

    [SerializeField] Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        attack = 10f;

        //Player = GameObject.Find("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        angle += Time.deltaTime;
        
        if (angle > Mathf.PI * 2) angle = 0;
        
        transform.position = Player.position + new Vector3(Mathf.Sin(angle * speed), Mathf.Cos(angle * speed), 0) * offset;
    }

    private IEnumerator AttackRoutine()
    {

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();

        Debug.Log(collision);

        if (monster != null)
        {
            StartCoroutine(monster.OnHit(attack));
        }
    }
}
