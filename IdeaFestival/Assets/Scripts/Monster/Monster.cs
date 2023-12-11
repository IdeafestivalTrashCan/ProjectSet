using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Vector2 size; // 공격범위
    [SerializeField] private float moveSpeed;
    [SerializeField] private int curHp = 100;

    private SpriteRenderer monsterSprite;

    [Header("CurBoolState")]
    [SerializeField] private bool monsterAttack = true;
    [SerializeField] private bool isAttack = false;
    [SerializeField] private bool isThinking = false;

    [Header("MonsterState")]
    [SerializeField] private bool isMeleeAttack = true;
    [SerializeField] private bool isNoAttack = true;

    [Header("Range And curCoroutine")]
    [SerializeField] Collider2D[] hit;
    [SerializeField] Coroutine curCoroutine = null;
    private bool isAttackDealy = false;

    private void Start()
    {
        monsterSprite = GetComponent<SpriteRenderer>();
        Init(100, true, true);
        Think();
    }



    private void Update()
    {

        hit = Physics2D.OverlapBoxAll(transform.position, size, 0f);

        foreach (Collider2D hitCollider2D in hit)
        {
            if (hitCollider2D.gameObject.CompareTag("Player"))
            {
                Vector3 curPos = transform.position;
                Vector3 direction = hitCollider2D.transform.position - curPos;
                transform.position = Vector3.MoveTowards(curPos, hitCollider2D.transform.position, moveSpeed * Time.deltaTime);

                float dot = Vector3.Dot(direction.normalized, transform.right);


                StopCoroutine(curCoroutine);
                isThinking = false;

                if (monsterAttack && !isAttack)
                {
                    if (dot > 0)
                        monsterSprite.flipX = true;
                    else
                        monsterSprite.flipX = false;

                    if (!isNoAttack)
                        StartCoroutine(AttackDirection(monsterSprite.flipX));
                }
            }
        }
        if (!isThinking)
        {
            bool check = false;
            foreach (Collider2D hitCollider2D in hit)
            {

                if (hitCollider2D.gameObject.CompareTag("Player"))
                {
                    check = true;
                }

            }
            if (!check)
            {
                Debug.Log("Check");
                StopCoroutine(curCoroutine);
                Think();
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
    IEnumerator AttackDelay(bool direction)
    {
        yield return new WaitForSeconds(1.5f);//공격 대기시간

        moveSpeed = 0f;
        transform.Find("AttackR").gameObject.SetActive(false);
        transform.Find("AttackL").gameObject.SetActive(false);

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

    protected void Init(int hp, bool ismeleeAttack, bool isNoAttack)
    {
        this.curHp = hp;
        this.isMeleeAttack = ismeleeAttack;
        this.isNoAttack = isNoAttack;
    }
    void Think()
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

        yield return new WaitForSeconds(0.5f);

        Think();
    }
    protected IEnumerator Work(Vector3 direction)
    {
        for (int i = 0; i < 100; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        Think();
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
            if (isNoAttack && !isAttackDealy)
            {
                isAttackDealy = true;
                monsterSprite.color = Color.red;
                curHp -= 10;
                Invoke("ColorDelay", 0.25f);
            }
        }
    }

    private void ColorDelay()
    {
        monsterSprite.color = Color.white;
        isAttackDealy = false;
    }
}
