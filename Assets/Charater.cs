using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int healthPoint = 5;
    [SerializeField] protected int maxHealthPoint = 5;
    [SerializeField] protected float movingSpeed = 10f;
    [SerializeField] public int damage = 1;
    protected virtual void TakeDamage(int damageTaking){

    }
    public virtual void CharacterMovement(){

    }
    protected virtual void BeKilled(){

    }
}
