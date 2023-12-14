using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int curHp = 100;
    [SerializeField] private int damage = 5;

    private SpriteRenderer monsterSprite;
    private Animator animator;
    [SerializeField] private GameObject player;

    [Header("CurBoolState")]
    [SerializeField] private bool monsterAttack = true;
    [SerializeField] private bool isAttack = false;
    [SerializeField] private bool isThinking = false;

    [Header("MonsterState")]
    [SerializeField] private bool isNoAttack = true;
    [SerializeField] private bool isChase;

    private Coroutine curCoroutine;

    [Header("Detect, Attack Distance")]
    [SerializeField] private float attackDistance;
    [SerializeField] private float detectDistance;

    [Header("Atk Info")]
    [SerializeField] private float atkCur = 0;
    [SerializeField] private float atkCool = 0.5f;

    private void Start()
    {
        Init(5, 3, 100, true);
    }



    private void Update()
    {
        Idle();
        Chase();
        Attack();
    }
    private void Idle()
    {
        if (!isChase && !isAttack)
        {
            transform.Find("WarningSign").gameObject.SetActive(false);
           // if (!isThinking)
                //Think();
        }
        else
        {
            //if (curCoroutine != null) StopCoroutine(curCoroutine);
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

            if (atkCur > 0) atkCur -= Time.deltaTime;
            else
            {
                animator.SetTrigger("Attack");
                atkCur = atkCool;
            }
        }
        else
        {
            isAttack = false;
            atkCur = 0;
        }
    }

    protected void Init(float detectDistance, float attackDistance, int hp, bool isNoAttack)
    {
        monsterSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");

        this.detectDistance = detectDistance;
        this.attackDistance = attackDistance;
        curHp = hp;
        this.isNoAttack = isNoAttack;

    }
    protected void Think()
    {
        isThinking = true;
        int patternIndex = Random.Range(0, 3);

        switch (patternIndex)
        {
            case 0:
                curCoroutine = StartCoroutine(IdleCoroutine());
                break;
            case 1:
                curCoroutine = StartCoroutine(WalkCoroutine(new Vector3(1, transform.position.y)));
                monsterSprite.flipX = true;
                break;
            case 2:
                curCoroutine = StartCoroutine(WalkCoroutine(new Vector3(-1, transform.position.y)));
                monsterSprite.flipX = false;
                break;
        }
    }
    protected IEnumerator IdleCoroutine()
    {
        animator.SetBool("isIdle", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isIdle", false);
        Think();
    }
    protected IEnumerator WalkCoroutine(Vector3 direction)
    {
        animator.SetBool("isWalk", true);
        for (int i = 0; i < 100; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        animator.SetBool("isWalk", false);
        Think();
    }

    private bool IsCheckDistance(float distance)
    {
        return distance >= Vector2.Distance(transform.position, player.transform.position);
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
