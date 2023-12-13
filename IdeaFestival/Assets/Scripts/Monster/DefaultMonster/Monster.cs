using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Vector2 size; // 인식범위
    [SerializeField] private Vector2 attackSize; // 공격범위
    [SerializeField] private float moveSpeed;
    [SerializeField] private int curHp = 100;
    [SerializeField] private int damage = 5;

    private SpriteRenderer monsterSprite;
    private Animator animator;

    [Header("CurBoolState")]
    [SerializeField] private bool monsterAttack = true;
    [SerializeField] private bool isAttack = false;
    [SerializeField] private bool isThinking = false;

    [Header("MonsterState")]
    [SerializeField] private bool isMeleeAttack = true;
    [SerializeField] private bool isNoAttack = true;

    [Header("Range And curCoroutine")]
    [SerializeField] Collider2D[] detectHit;
    [SerializeField] Collider2D[] attackHit;
    private bool isAttackDealy = false;

    private Coroutine curCoroutine;
   

    private void Start()
    {
        Init(new Vector2(10, 3), new Vector2(3, 3), 100, true, true);
        Think();
    }



    private void Update()
    {

        detectHit = Physics2D.OverlapBoxAll(transform.position, size, 0f, 6);
        attackHit = Physics2D.OverlapBoxAll(transform.position, attackSize, 0f, 6);

        foreach (Collider2D hitCollider2D in detectHit)
        {
            if (hitCollider2D.gameObject.CompareTag("Player"))
            {
                Vector3 curPos = transform.position;
                Vector3 direction = hitCollider2D.transform.position - curPos;
                transform.position = Vector3.MoveTowards(curPos, hitCollider2D.transform.position, moveSpeed * Time.deltaTime);

                float dot = Vector3.Dot(direction.normalized, transform.right);

                StopCoroutine(curCoroutine);
                isThinking = false;
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalk", false);

                if (monsterAttack && !isAttack)
                {
                    if (dot > 0)
                        monsterSprite.flipX = true;
                    else
                        monsterSprite.flipX = false;

                    if (!isNoAttack && false)
                        foreach (Collider2D hitCollider in attackHit)
                        {

                            if (hitCollider.gameObject.CompareTag("Player"))
                            {
                               AttackDirection(monsterSprite.flipX);
                            }
                        }
                }
            }
        }
        if (!isThinking)
        {
            bool check = false;
            foreach (Collider2D hitCollider2D in detectHit)
            {

                if (hitCollider2D.gameObject.CompareTag("Player"))
                {
                    check = true;
                }

            }
            if (!check)
            {
                Debug.Log("Start Think");
                StopCoroutine(curCoroutine);
                Think();
            }

        }


        if (curHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void AttackDirection(bool direction)
    {
        Debug.Log("Attack");
        foreach (Collider2D hitCollider2D in attackHit)
        {
            if (hitCollider2D.gameObject.CompareTag("Player"))
            {
                if (!isAttack)
                {
                    isAttack = true;
                    transform.Find("WarningSign").gameObject.SetActive(true);
                    StartCoroutine(AttackDelay(direction));
                }
            }
            else
                Think();
        }
    }
    IEnumerator AttackDelay(bool direction)
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1.5f);//공격 대기시간
        foreach (Collider2D hitCollider2D in attackHit)
        {
            if (hitCollider2D.gameObject.CompareTag("Player"))
            {
                hitCollider2D.GetComponent<PlayerHp>().TakeDamage(damage);
            }
        }
        animator.SetBool("isAttack", false);

        transform.Find("WarningSign").gameObject.SetActive(false);

        if (monsterAttack == true)
        {
            monsterAttack = false;
        }
        StartCoroutine(AttackDestory());
    }
    protected IEnumerator AttackDestory()
    {
        yield return new WaitForSeconds(2.5f);
        moveSpeed = 2f;
        monsterAttack = true;
        isAttack = false;

        Think();
    }

    protected void Init(Vector2 size, Vector2 attackSize, int hp, bool ismeleeAttack, bool isNoAttack)
    {
        monsterSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();   
        this.size = size;
        this.attackSize = attackSize;
        this.curHp = hp;
        this.isMeleeAttack = ismeleeAttack;
        this.isNoAttack = isNoAttack;
    }
    protected void Think()
    {
        isThinking = true;
        int patternIndex = Random.Range(0, 3);

        switch (patternIndex)
        {
            case 0:
                curCoroutine = StartCoroutine(Idle());
                break;
            case 1:
                curCoroutine = StartCoroutine(Work(new Vector3(1, transform.position.y)));
                monsterSprite.flipX = true;
                break;
            case 2:
                curCoroutine = StartCoroutine(Work(new Vector3(-1, transform.position.y)));
                monsterSprite.flipX = false;
                break;
        }
    }
    protected IEnumerator Idle()
    {
        animator.SetBool("isIdle", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isIdle", false);
        Think();
    }
    protected IEnumerator Work(Vector3 direction)
    {
        animator.SetBool("isWalk", false);
        for (int i = 0; i < 100; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        animator.SetBool("isWalk", false);
        Think();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, attackSize);
    }

    public void TakeDamage(int damage)
    {
        monsterSprite.color = Color.red;
        curHp -= damage;
        Invoke("ColorDelay", 0.25f);
    }

    private void ColorDelay()
    {
        monsterSprite.color = Color.white;
    }
}
