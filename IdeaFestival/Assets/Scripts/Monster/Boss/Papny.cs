using System.Collections;
using UnityEngine;

public class Papny : Monster
{
    public int maxHp;
    private new bool isAttacking = false;
    private bool isDeath;
    private bool isAlive;

    [SerializeField] AudioClip[] attackSound;

    [SerializeField] Transform[] atkPos;
    [SerializeField] Collider2D[] collider2Ds;

    private void Start()
    {
        Init(20, 5f, 2000, 10, 2, false, 6);
        maxHp = curHp;
        Invoke("Alive", 4.1f);
    }

    void Alive()
    {
        isAlive = true;
    }

    private void Update()
    {
        if (!isDeath && isAlive)
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
                    StartCoroutine(Atk1());
                    StartCoroutine(AttackingFalse(2f));
                    break;
                case 1:
                    animator.SetTrigger("Atk2");
                    StartCoroutine(Atk2());
                    StartCoroutine(AttackingFalse(2f));
                    break;
                case 2:
                    animator.SetTrigger("Atk3");
                    StartCoroutine(Atk3());
                    StartCoroutine(AttackingFalse(2f));
                    break;
                case 3:
                    StartCoroutine(AttackingFalse(2f));
                    break;
            }
            isAttacking = true;

        }
    }

    IEnumerator AttackingFalse(float time)
    {
        yield return new WaitForSeconds(time);
        isAttack = false;
        isAttacking = false;
    }

    IEnumerator Atk1()
    {
        yield return new WaitForSeconds(0.43f);
        if (monsterSprite.flipX)
        {
            //collider2Ds = Physics2D.OverlapBoxAll(atkPos[0].position, new Vector2(4.8f, 2f), 0, 7);
            collider2Ds = Physics2D.OverlapBoxAll(atkPos[0].position, new Vector2(6f, 1.75f), 0);
            Damage();
        }
        else
        {
            //collider2Ds = Physics2D.OverlapBoxAll(atkPos[1].position, new Vector2(4.8f, 2f), 0, 7);
            collider2Ds = Physics2D.OverlapBoxAll(atkPos[1].position, new Vector2(6f, 1.75f), 0);
            Damage();
        }

        AudioManager.instance.SFXPlay("Atk1", attackSound[0]);

    }
    IEnumerator Atk2()
    {
        yield return new WaitForSeconds(0.35f);
        if (monsterSprite.flipX)
        {
            //collider2Ds = Physics2D.OverlapBoxAll(atkPos[2].position, new Vector2(10.4f, 3.2f), 0, 7);
            collider2Ds = Physics2D.OverlapBoxAll(atkPos[2].position, new Vector2(7, 4f), 0);
            Damage();
        }
        else
        {
            //collider2Ds = Physics2D.OverlapBoxAll(atkPos[3].position, new Vector2(10.4f, 3.2f), 0, 7);
            collider2Ds = Physics2D.OverlapBoxAll(atkPos[3].position, new Vector2(7, 4f), 0);
            Damage();
        }
        
        AudioManager.instance.SFXPlay("Atk2", attackSound[1]);
    }
    IEnumerator Atk3()
    {
        yield return new WaitForSeconds(0.8f);
        if (monsterSprite.flipX)
        {
            collider2Ds = Physics2D.OverlapBoxAll(atkPos[4].position, new Vector2(7.2f, 7.2f), 0);
            Damage();
        }
        else
        {
            collider2Ds = Physics2D.OverlapBoxAll(atkPos[5].position, new Vector2(7.2f, 7.2f), 0);
            Damage();
        }

        AudioManager.instance.SFXPlay("Atk3", attackSound[2]);
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

    void Damage()
    {
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player")
                collider.GetComponent<PlayerUI>().TakeDamage(15);
        }
    }
    IEnumerator Die()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}
