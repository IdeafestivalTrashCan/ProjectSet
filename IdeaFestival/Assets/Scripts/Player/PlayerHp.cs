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
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ColorDelay", 0.25f);
    }

    protected void ColorDelay()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Die()
    {
        if (curHp <= 0)
            gameObject.SetActive(false);
    }
}
