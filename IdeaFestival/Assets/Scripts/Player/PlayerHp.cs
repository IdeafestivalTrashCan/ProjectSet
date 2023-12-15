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

    void Start()
    {
        HP.value = (float)curHp / MaxHp;
    }

    void Update()
    {
        HP.value = (float)curHp / MaxHp;
        Die();
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;
        Invoke("AttackDelay", 0.25f);
    }

    void Die()
    {
        if (curHp <= 0)
            Debug.Log("Die");
    }
}
