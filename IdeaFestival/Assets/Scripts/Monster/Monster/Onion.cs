using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : Monster
{
    Animator atkAnimL;
    Animator atkAnimR;

    Collider2D[] atkArrR;
    Collider2D[] atkArrL;

    [SerializeField] Vector2 atkSize;
    private void Awake()
    {
        atkAnimR = transform.GetChild(1).GetComponent<Animator>();
        atkAnimL = transform.GetChild(2).GetComponent<Animator>();
    }
    private void Start()
    {
        Init(9, 3, 35, 10, 3, false, 5);
    }

    protected override void AttackPlay()
    {
        Debug.Log("ATtack GOOGOGOGO");
        PlayAnim("Attack");
        Invoke("InflictDamage", 0.3f);
        isAttacking = false;
    }

    void InflictDamage()
    {
        atkArrR = Physics2D.OverlapBoxAll((Vector2)transform.GetChild(1).position, atkSize, 0);
        atkArrL = Physics2D.OverlapBoxAll((Vector2)transform.GetChild(2).position, atkSize, 0);
        if (IsCheckDistance(attackDistance))
        {
            foreach (Collider2D collider in atkArrR)
            {
                if(collider.tag == "Player")
                    player.GetComponent<PlayerUI>().TakeDamage(damage);
            }
            foreach (Collider2D collider in atkArrL)
            {
                if (collider.tag == "Player")
                    player.GetComponent<PlayerUI>().TakeDamage(damage);
            }
        }
    }
    void PlayAnim(string trigger)
    {
        atkAnimL.SetTrigger(trigger);
        atkAnimR.SetTrigger(trigger);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube((Vector2)transform.GetChild(1).position, atkSize);
        Gizmos.DrawWireCube((Vector2)transform.GetChild(2).position, atkSize);
    }


}
