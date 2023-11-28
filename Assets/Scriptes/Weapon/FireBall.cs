using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Weapon
{
    [SerializeField] float angle;

    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;

        Player = GameObject.Find("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;

        if (angle > Mathf.PI * 2) angle = 0;

        transform.position = Player.position + new Vector3(Mathf.Sin(angle * speed), Mathf.Cos(angle * speed), 0) * 3;
    }

    public override void Attack()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();

        Debug.Log(collision);

        if (monster != null)
        {
            monster.health -= attack;
        }
    }
}
