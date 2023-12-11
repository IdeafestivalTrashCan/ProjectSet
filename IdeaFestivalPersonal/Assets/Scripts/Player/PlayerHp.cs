using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Slider HP;

    private int MaxHp = 100;
    private int curHp = 100;
    
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
        
        if (other.gameObject.CompareTag("Monster"))
            curHp -= 1;

        HP.value = (float)curHp / MaxHp;
    }

    void Die()
    {
        if (curHp <= 0)
            Debug.Log("Die");
    }
}
