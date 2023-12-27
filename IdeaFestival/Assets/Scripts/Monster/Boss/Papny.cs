using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papny : Monster
{
    public int maxHp;
    new bool isAttacking = false;
    private bool isDeath;

    private void Start()
    {
        Init(15, 7.5f, 2000, 10, 2, false, 6);
        maxHp = curHp;
    }

    private void Update()
    {
        if (!isDeath)
        {
            Chase();
            Attack();
        }
    }

    void Chase()
    {
        animator.SetBool("IsWalk", isChase);
        if (IsCheckDistance(detectDistance) && !isAttack)
        {
            Debug.Log("chase!!!");
            isChase = true;

            float direction = player.transform.position.x - transform.position.x;

            if (direction > 0)
            {
                monsterSprite.flipX = true; // 플레이어가 오른쪽에 있을 때
            }
            else if (direction < 0)
            {
                monsterSprite.flipX = false; // 플레이어가 왼쪽에 있을 때
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        }
        else
            isChase = false;
    }

    void Attack()
    {
        if (IsCheckDistance(attackDistance) && !isAttacking)
        {
            isAttack = true;
            switch (Random.Range(0, 3))
            {
                case 0:
                    animator.SetTrigger("Atk1");
                    break;
                case 1:
                    animator.SetTrigger("Atk2");
                    break;
                case 2:
                    animator.SetTrigger("Atk3");
                    break;
            }
            isAttacking = true;
            StartCoroutine(AttackingFalse(1f));
        }
    }

    IEnumerator AttackingFalse(float time)
    {
        yield return new WaitForSeconds(time);
        isAttack = false;
        isAttacking = false;
    }

    public override void TakeDamage(int damage)
    {
        monsterSprite.color = Color.red;
        curHp -= damage;

        if (curHp <= 0 && !isDeath)
        {
            isDeath = true;
            StartCoroutine("Die");
        }
        Invoke("ColorDelay", 0.25f);
    }

    IEnumerator Die()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}
