using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papny : Monster
{
    public int maxHp;
    [SerializeField]bool isAlive = false;
    new bool isAttacking = false;
    private void Start()
    {
        Init(15, 7.5f, 2000, 10, 2, false, 6);
        maxHp = curHp;
    }

    private void Update()
    {
        Alive();
        Chase();
        Attack();
    }

    void Alive()
    {
        if(!isAlive && IsCheckDistance(detectDistance) && Input.GetKeyDown(KeyCode.F)) 
        { 
            animator.SetBool("isAlive", true);
            StartCoroutine(AliveCorou());
        }
        
    }
    void Chase()
    {
        if (isAlive)
        {
            animator.SetBool("IsWalk", isChase);
            if (IsCheckDistance(detectDistance) && !isAttack)
            {
                Debug.Log("chase!!!");
                isChase = true;

                float direction = player.transform.position.x - transform.position.x;

                if (direction > 0)
                {
                    monsterSprite.flipX = true; // �÷��̾ �����ʿ� ���� ��
                }
                else if (direction < 0)
                {
                    monsterSprite.flipX = false; // �÷��̾ ���ʿ� ���� ��
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);
            }
            else
                isChase = false;
        }
    }

    void Attack()
    {
        if (isAlive)
        {
            if(IsCheckDistance(attackDistance) && !isAttacking)
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
    }

    IEnumerator AliveCorou()
    {
        yield return new WaitForSeconds(2f);
        isAlive = true;
    }

    IEnumerator AttackingFalse(float time)
    {
        yield return new WaitForSeconds(time);
        isAttack= false;
        isAttacking = false;
    }

}