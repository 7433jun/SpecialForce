using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Monster
{
    protected override void Attack()
    {
        speed = 0;
        attack = 5f;
        health = 75;

        animator.SetBool("Attack", true);
    }

    protected override void Death()
    {
        throw new System.NotImplementedException();
    }
}
