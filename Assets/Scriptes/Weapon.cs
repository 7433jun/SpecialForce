using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float attack;
    [SerializeField] protected float speed;

    public abstract void Attack();
}
