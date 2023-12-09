using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class Monster_Level_1 : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Slider Hp;


    private SpriteRenderer monsterSprite;
    private bool monsterAttack = true;
    private bool isAttack = false;

    private int maxHp = 100;
    private int curHp = 100;

    private void Start()
    {
        monsterSprite = GetComponent<SpriteRenderer>();
        Hp.value = (float)curHp / maxHp;
    }

    private void Update()
    {
        Hp.value = (float)curHp / maxHp;

        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, size, 0f);

        foreach (Collider2D hitCollider2D in hit)
        {
            if (hitCollider2D.gameObject.CompareTag("Player"))
            {
                Vector3 direction = hitCollider2D.transform.position - transform.position; // 대상 오브젝트 방향 계산
                direction.y = 0;
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

                float dot = Vector3.Dot(direction.normalized, transform.right);

               

                if (monsterAttack && !isAttack )
                {
                    if (dot > 0)
                        monsterSprite.flipX = true;
                    else
                        monsterSprite.flipX = false;
                    StartCoroutine(AttackDirection(monsterSprite.flipX));
                }
            }
        }

        if (curHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AttackDirection(bool direction)
    {
        if (!isAttack)
        {
            isAttack = true;
            if (direction != true)
            {
                transform.Find("AttackR").gameObject.SetActive(false);
                transform.Find("AttackL").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("AttackL").gameObject.SetActive(false);
                transform.Find("AttackR").gameObject.SetActive(true);
            }
            yield return null;
            StartCoroutine(AttackDelay(direction));
        }
    }

    private IEnumerator AttackDelay(bool dir)
    {
        yield return new WaitForSeconds(1.5f);

        moveSpeed = 0f;
        transform.Find("AttackR").gameObject.SetActive(false);
        transform.Find("AttackL").gameObject.SetActive(false);

        if (monsterAttack == true)
        {
            monsterAttack = false;
            GameObject attack = Instantiate(attackPrefab);
            Vector3 vector3 = new Vector3(transform.position.x, transform.position.y, 0f);
            attack.transform.position = vector3;

            if (dir != true)
            {
                attack.GetComponent<Rigidbody2D>().
                    AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
            }
            else
            {
                attack.GetComponent<Rigidbody2D>().
                    AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
            }
        }
        

        StartCoroutine(AttackDestory());
    }

    private IEnumerator AttackDestory()
    {
        yield return new WaitForSeconds(2.5f);
        moveSpeed = 2f;
        monsterAttack = true;
        isAttack = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Damge"))
        {
            monsterSprite.color = Color.red;
            curHp -= 10;
            Invoke("ColorDelay", 0.25f);
        }
    }

    private void ColorDelay()
    {
        monsterSprite.color = Color.white;
    }
}