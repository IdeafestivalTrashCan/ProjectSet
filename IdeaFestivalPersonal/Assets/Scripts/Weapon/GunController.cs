using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject prefab;
    public SpriteRenderer GunSpriteRenderer;
    public SpriteRenderer Player;
    
    private GameObject bullet;
    private bool isSprite;
    private bool isGun = true;
    private Animator animator;
    
    private void Start()
    {
        GunSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        bool isSpritePlayer = Player.flipX;
        isSprite = GunSpriteRenderer.flipX;

        if (isSpritePlayer == true)
            GunSpriteRenderer.flipX = true;
        else
            GunSpriteRenderer.flipX = false;
        
        if (Input.GetKeyDown(KeyCode.X) && isGun == true
            && GameManager.instance.PlayerWeapon[1] == true)
        {
            bullet = Instantiate(prefab);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            
            bullet.transform.position = transform.position;
            bullet.transform.position += new Vector3(0, 0.05f,0);
            
            isGun = false;
            animator.SetTrigger("isGun 0");

            if (isSpritePlayer == true)
                bulletRb.AddForce(Vector2.left * 30, ForceMode2D.Impulse);
            else
                bulletRb.AddForce(Vector2.right * 30, ForceMode2D.Impulse);
            
            StartCoroutine(GunDaley());
        }
    }



    private IEnumerator GunDaley()
    {
        yield return new WaitForSeconds(1f);
        isGun = true;
        BulletDestory();
    }

    private void BulletDestory()
    {
        Destroy(bullet);
    }
}
