using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int curHp = 100;
    [SerializeField] protected int damage = 5;

    private SpriteRenderer monsterSprite;
    private Animator animator;
    [SerializeField] protected GameObject player;

    [Header("CurBoolState")]
    [SerializeField] private bool monsterAttack = true;
    [SerializeField] private bool isAttack = false;

    protected bool isAttacking = false;
    [Header("MonsterState")]
    [SerializeField] private bool isNoAttack = true;
    [SerializeField] private bool isChase;

    private Coroutine curCoroutine;

    [Header("Detect, Attack Distance")]
    [SerializeField] protected float attackDistance;
    [SerializeField] protected float detectDistance;

    [Header("Atk Info")]
    [SerializeField] private float atkCur = 0;
    [SerializeField] private float atkCool = 1.5f;

    private void Start()
    {
        Init(5, 3, 100, 8, 5, true, 1.5f);
    }



    private void Update()
    {
        if (!isNoAttack)
        {
            Idle();
            Chase();
            Attack();

        }
    }
    private void Idle()
    {
        if (!isChase && !isAttack)
        {
            transform.Find("WarningSign").gameObject.SetActive(false);
            //if (!isThinking)
            //    Think();
        }
        else
        {
            if (curCoroutine != null) StopCoroutine(curCoroutine);
        }
    }
    void Chase()
    {
        animator.SetBool("isWalk", isChase);
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
        if (IsCheckDistance(attackDistance))
        {
            Debug.Log("Attack!!!");
            isAttack = true;
            transform.Find("WarningSign").gameObject.SetActive(true);

            float direction = player.transform.position.x - transform.position.x;

            if (direction > 0)
            {
                monsterSprite.flipX = true;
            }
            else if (direction < 0)
            {
                monsterSprite.flipX = false;
            }

            if (atkCur > 0) atkCur -= Time.deltaTime;
            else
            {
                animator.SetTrigger("Attack");
                isAttacking = true;
                Invoke("AttackPlay", 0.2f);
                atkCur = atkCool;
            }
        }
        else if (!isAttacking)
        {
            isAttack = false;
            atkCur = 0;
        }
    }
    protected virtual void AttackPlay()
    {
        Debug.Log("ATtack GOOGOGOGO");
        isAttacking = false;
        if (IsCheckDistance(attackDistance))
        {
            player.GetComponent<PlayerHp>().TakeDamage(damage);
        }

    }
    protected void Init(float detectDistance, float attackDistance, int hp, int damage, int speed, bool isNoAttack, float atkCool)
    {
        monsterSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        this.damage = damage;
        moveSpeed = speed;
        this.detectDistance = detectDistance;
        this.attackDistance = attackDistance;
        curHp = hp;
        this.atkCool = atkCool;
        this.isNoAttack = isNoAttack;

    }


    protected bool IsCheckDistance(float distance)
    {
        return distance >= Vector2.Distance(transform.position, player.transform.position);
    }

    public void TakeDamage(int damage)
    {
        monsterSprite.color = Color.red;
        curHp -= damage;

        if (curHp <= 0)
            gameObject.SetActive(false);
        Invoke("ColorDelay", 0.25f);
    }

    protected void ColorDelay()
    {
        monsterSprite.color = Color.white;
    }
}
