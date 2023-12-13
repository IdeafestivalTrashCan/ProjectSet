using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Slider HP;

    private int MaxHp = 100;
    [SerializeField] private int curHp = 100;
    private bool isAttackDealy = false;

    void Start()
    {
        HP.value = (float)curHp / MaxHp;
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Die();

        if (!isAttackDealy)
        {
            if (other.gameObject.CompareTag("Monster"))
            {
                isAttackDealy = true;
                curHp -= 1;
                Invoke("AttackDelay", 0.25f);
            }
        }


        HP.value = (float)curHp / MaxHp;
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;
    }

    void AttackDelay()
    {
        isAttackDealy = false;
    }

    void Die()
    {
        if (curHp <= 0)
            Debug.Log("Die");
    }
}
