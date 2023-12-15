using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.GetComponent<Monster>().TakeDamage(GameManager.instance.PlayerDamage);
            Destroy(gameObject);
        }
    }
}
