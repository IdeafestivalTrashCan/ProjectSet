using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlat : MonoBehaviour
{
    private GameObject curOnewayPlat;

    [SerializeField] private BoxCollider2D playerCollider;
    private void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(curOnewayPlat != null)
            {
                StartCoroutine(DisableCollision());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlat"))
        {
            curOnewayPlat = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlat"))
        {
            curOnewayPlat = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platCollider = curOnewayPlat.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platCollider);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, platCollider, false);

    }
}
