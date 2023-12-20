using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header ("Setting")]
    [SerializeField] private Transform _Camera;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpPower;
    
    private SpriteRenderer Renderer;
    private bool isJump = true;
    private Animator animator;
    private Rigidbody2D rigid;
    private bool isDash = true;
    
    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        GameManager.instance.cam.orthographicSize = GameManager.instance.cameraSize;

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Tutorial_Scene");
            transform.position = new Vector3(-30, -2, 0);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("Vegetable_Scene 1");
            transform.position = new Vector3(-30, -2, 0);
        }

        
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isRun", true);
            transform.Translate(-Speed * Time.deltaTime, 0f, 0f);
            Renderer.flipX = true;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isRun", true);
            transform.Translate(Speed * Time.deltaTime, 0f, 0f);
            Renderer.flipX = false;
        }

        else
        {
            animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.C) && isJump == true)
        {
            animator.SetBool("isRun", false);
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Dash(rigid, Renderer.flipX);
        }
    }
    
    private void Dash(Rigidbody2D rb, bool sr)
    {
        if (isDash)
        {
            isDash = false;

            StartCoroutine(DashDelayTime());

            if (sr)
                rb.velocity = Vector2.left * 7;
            else
                rb.velocity = Vector2.right * 7;
            
            StartCoroutine(StopMovement(rb));
        }
    }
    
    private IEnumerator StopMovement(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(0.5f); 

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    private IEnumerator DashDelayTime()
    {
        yield return new WaitForSeconds(1f);
        isDash = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = true;
            animator.SetBool("isIdle", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            animator.SetBool("isIdle", false);
        }
    }
}
