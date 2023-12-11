using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Level_2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 size;
    [SerializeField] private float distance;

    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, size, 0f);
        // RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance);
        
        foreach (Collider2D hitCollider2D in hit)
        {
            if (hitCollider2D.gameObject.CompareTag("Player"))
            {
                Vector3 direction = hitCollider2D.transform.position - transform.position; // 대상 오브젝트 방향 계산
                direction.y = 0;
                transform.Translate(direction.normalized * speed * Time.deltaTime);
                
                float dot = Vector3.Dot(direction.normalized, transform.right);

                if (dot > 0)
                    sprite.flipX = true;
                else
                    sprite.flipX = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
