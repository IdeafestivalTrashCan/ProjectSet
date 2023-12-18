using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Transform SwordOrigin;
    public SpriteRenderer CharacterFilpXCheck;
    public GameObject[] Slash;
    public GameObject[] DamgeLine;

    [SerializeField] private Collider2D[] rightCollider;
    [SerializeField] private Collider2D[] leftCollider;

    [SerializeField] private Vector2 boxSize;

    private bool DelayX = true;
    private bool isSprite;
    private bool SwordEulerAngles = false;
    private int dmg = 5;

    void Start()
    {
        CharacterFilpXCheck = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isSprite = CharacterFilpXCheck.flipX;

        FlipXCheck();

        if (Input.GetKeyDown(KeyCode.X) &&
            DelayX == true && isSprite == false &&
            GameManager.instance.PlayerWeapon[0] == true)
        {
            DelayX = false;

            rightCollider = Physics2D.OverlapBoxAll(transform.Find("SlashR").position, boxSize, 0);

            foreach(Collider2D collider in rightCollider)
            {
                if (collider.tag == "Monster")
                    collider.GetComponent<Monster>().TakeDamage(dmg);
            }

            for (int i = 0; i < 30; i++)
                SwordOrigin.Rotate(0f, 0f, -2.3f);

            Slash[0].SetActive(true);
            DamgeLine[0].SetActive(true);

            Invoke("Delay", 0.3f);
            SwordEulerAngles = false;
        }

        if (Input.GetKeyDown(KeyCode.X) &&
            DelayX == true && isSprite == true &&
            GameManager.instance.PlayerWeapon[0] == true)
        {
            DelayX = false;

            leftCollider = Physics2D.OverlapBoxAll(transform.Find("SlashL").position, boxSize, 0);

            foreach (Collider2D collider in leftCollider)
            {
                if (collider.CompareTag("Monster")) 
                    collider.GetComponent<Monster>().TakeDamage(dmg);
            }

            for (int i = 0; i < 30; i++)
                SwordOrigin.Rotate(0f, 0f, +2.3f);

            Slash[1].SetActive(true);
            DamgeLine[1].SetActive(true);

            Invoke("Delay", 0.3f);
            SwordEulerAngles = true;
        }
    }

    void FlipXCheck()
    {
        if (isSprite == false)
        {
            SwordOrigin.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
            SwordOrigin.transform.localPosition = new Vector3(0.68f, -0.27f);
        }

        if (isSprite == true)
        {
            SwordOrigin.transform.localScale = new Vector3(-0.2f, 0.2f, 0f);
            SwordOrigin.transform.localPosition = new Vector3(-0.68f, -0.27f);
        }
    }

    void Delay()
    {
        if (SwordEulerAngles == true)
            SwordOrigin.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else
            SwordOrigin.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        DelayX = true;

        for (int i = 0; i < Slash.Length; i++)
        {
            Slash[i].SetActive(false);
            DamgeLine[i].SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.Find("SlashR").position, boxSize);
        Gizmos.DrawWireCube(transform.Find("SlashL").position, boxSize);
    }
}
