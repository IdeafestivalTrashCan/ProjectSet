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

    [Header ("Bool State")]
    private SpriteRenderer Renderer;
    [SerializeField] private bool isJump = true;
    private Animator animator;
    private Rigidbody2D rigid;

    [Header("DashState")]
    [SerializeField] public bool canDash;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashingPower = 24;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCoolDown = 1f;


    private void Start()
    {
        GameManager.instance.player = gameObject;
        Renderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        GameManager.instance.player = gameObject;
        GameManager.instance.cam.orthographicSize = GameManager.instance.cameraSize;


        if (isDashing)
            return;
        if (GameManager.instance.isKeyMode)
        {
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

            if (Input.GetKeyDown(KeyCode.Z) && canDash)
            {
                StartCoroutine(Dash(Renderer.flipX));
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") == -1)
            {
                animator.SetBool("isRun", true);
                transform.Translate(-Speed * Time.deltaTime, 0f, 0f);
                Renderer.flipX = true;
            }

            else if (Input.GetAxis("Horizontal") == 1)
            {
                animator.SetBool("isRun", true);
                transform.Translate(Speed * Time.deltaTime, 0f, 0f);
                Renderer.flipX = false;
            }

            else
            {
                animator.SetBool("isRun", false);
            }

            if (Input.GetButtonDown("Jump") && isJump == true)
            {
                animator.SetBool("isRun", false);
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
           
            if (Input.GetButtonDown("Dash") && canDash)
            {
                  
                StartCoroutine(Dash(Renderer.flipX));
            }
        }
    }

    private IEnumerator Dash(bool isFlip)
    {
        canDash = false;
        isDashing = true;
        float originalGraviry = rigid.gravityScale;
        rigid.gravityScale = 0f;
        if (isFlip)
            rigid.velocity = new Vector3(-dashingPower, 0f);
        else
            rigid.velocity = new Vector3(dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rigid.velocity = Vector3.zero;
        rigid.gravityScale = originalGraviry;
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }
    

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = true;
            animator.SetBool("isIdle", true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
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
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            animator.SetBool("isIdle", false);
        }
    }
}
