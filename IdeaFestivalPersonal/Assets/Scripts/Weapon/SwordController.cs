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
    
    private bool DelayX = true;
    private bool isSprite;
    private Transform Player;
    private bool SwordEulerAngles = false;
    
    void Start()
    {
        Player = transform.Find("Player");
        CharacterFilpXCheck = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        isSprite = CharacterFilpXCheck.flipX;
        
        filpXCheck();
        
        if (Input.GetKeyDown(KeyCode.X) &&
            DelayX == true && isSprite == false &&
            GameManager.instance.PlayerWeapon[0] == true)
        {
            DelayX = false;
            
            for (int i = 0; i < 30; i++)
                SwordOrigin.Rotate(0f, 0f,-2.3f);
            
            Slash[0].SetActive(true);
            DamgeLine[0].SetActive(true);
            
            Invoke("Delay", 0.5f);
            SwordEulerAngles = false;
        }

        if (Input.GetKeyDown(KeyCode.X) &&
            DelayX == true && isSprite == true &&
            GameManager.instance.PlayerWeapon[0] == true)
        {
            DelayX = false;

            for (int i = 0; i < 30; i++)
                SwordOrigin.Rotate(0f, 0f, +2.3f);
            
            Slash[1].SetActive(true);
            DamgeLine[1].SetActive(true);
            
            Invoke("Delay", 0.5f);
            SwordEulerAngles = true;
        }
    }

    void filpXCheck()
    {
        if (isSprite == false)
        {
            SwordOrigin.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        }

        if (isSprite == true)
        {
            SwordOrigin.transform.localScale = new Vector3(-0.2f, 0.2f, 0f);
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
}
