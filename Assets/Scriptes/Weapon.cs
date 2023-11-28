using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected float attack;
    protected float speed;

    public abstract void Attack();
}
