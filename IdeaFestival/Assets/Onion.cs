using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : Monster
{
    private void Start()
    {
        Init(7, 3, 30, 10, 3, false, 5);
    }

    protected override void AttackPlay()
    {
        Debug.Log("ATtack GOOGOGOGO");
        isAttacking = false;
        if (IsCheckDistance(attackDistance))
        {
            player.GetComponent<PlayerHp>().TakeDamage(damage);
        }

    }
}
