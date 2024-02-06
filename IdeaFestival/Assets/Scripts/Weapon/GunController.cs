using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class GunController : MonoBehaviour
{
    public GameObject prefab;
    private GameObject ammoUI;
    public SpriteRenderer GunSpriteRenderer;
    public SpriteRenderer Player;

    [SerializeField] private AmmoManager aM;

    private GameObject bullet;
    private bool isSprite;
    private bool isGun = true;
    private Animator animator;
    [SerializeField] private AudioClip FireClip;

    private void Awake()
    {
        ammoUI = GameObject.Find("GameManager/Player/PlayerUI/Ammo");
        aM = ammoUI.GetComponent<AmmoManager>();
        GunSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameManager.instance.player.GetComponent<PlayerUI>().isDead)
        {
            bool isSpritePlayer = Player.flipX;
            isSprite = GunSpriteRenderer.flipX;

            if (isSpritePlayer == true)
            {
                GunSpriteRenderer.flipX = true;
                transform.localPosition = new Vector2(-1, 0f);
            }
            else
            {
                GunSpriteRenderer.flipX = false;
                transform.localPosition = new Vector2(1, 0f);
            }
            if (GameManager.instance.isKeyMode)
            {
                if ((Input.GetKeyDown(KeyCode.X) && isGun == true
                    && GameManager.instance.PlayerWeapon[1] == true) && aM.isFireable())
                {
                    bullet = Instantiate(prefab);
                    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

                    bullet.transform.position = transform.position;
                    bullet.transform.position += new Vector3(0, 0.05f, 0);

                    isGun = false;
                    animator.SetTrigger("Fire");
                    aM.Fire();

                    if (isSpritePlayer == true)
                        bulletRb.AddForce(Vector2.left * 30, ForceMode2D.Impulse);
                    else
                        bulletRb.AddForce(Vector2.right * 30, ForceMode2D.Impulse);
                    AudioManager.instance.SFXPlay("Swing", FireClip);
                    StartCoroutine(GunDaley());
                }

                if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.R))
                    aM.Reload();
            }
            else
            {
                if ((Input.GetButtonDown("attack") && isGun == true
                    && GameManager.instance.PlayerWeapon[1] == true) && aM.isFireable())
                {
                    Gamepad.current.SetMotorSpeeds(0.75f, 0.75f);
                    Invoke("Vibration", 0.15f);
                    bullet = Instantiate(prefab);
                    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

                    bullet.transform.position = transform.position;
                    bullet.transform.position += new Vector3(0, 0.05f, 0);

                    isGun = false;
                    animator.SetTrigger("Fire");
                    aM.Fire();

                    if (isSpritePlayer == true)
                        bulletRb.AddForce(Vector2.left * 30, ForceMode2D.Impulse);
                    else
                        bulletRb.AddForce(Vector2.right * 30, ForceMode2D.Impulse);
                    AudioManager.instance.SFXPlay("Swing", FireClip);
                    StartCoroutine(GunDaley());
                }

                if (Input.GetButtonDown("Reload"))
                    aM.Reload();
            }
        }
    }



    private IEnumerator GunDaley()
    {
        yield return new WaitForSeconds(0.3f);
        BulletDestory();

        yield return new WaitForSeconds(0.2f);
        isGun = true;
        
    }

    private void BulletDestory()
    {
        Destroy(bullet);
    }

    void Vibration()
    {
                Gamepad.current.SetMotorSpeeds(0, 0);
    }
}
