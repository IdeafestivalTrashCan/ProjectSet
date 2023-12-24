using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTile : MonoBehaviour
{
    bool isPlayerTakeDamage = false;
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
            StartCoroutine(MonsterTrap(other));
        if (other.gameObject.CompareTag("Player") && !isPlayerTakeDamage )
            StartCoroutine(PlayerTrap(other));
    }

    IEnumerator MonsterTrap(Collision2D other)
    {
        other.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator PlayerTrap(Collision2D other)
    {
        isPlayerTakeDamage = true;
        PlayerUI pUI = other.gameObject.GetComponent<PlayerUI>();
        pUI.TakeDamage(20);
        yield return new WaitForSeconds(0.25f);
        isPlayerTakeDamage = false;
    }
}
