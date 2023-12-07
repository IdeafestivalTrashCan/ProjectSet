using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text GameMoney;
    public int Cash;
    public float Sizemain = 5f;
    public bool BossCheck = false;

    public bool[] PlayerWeapon;

    public int PlayerDamge = 100;
    public Transform playertrans;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        GameMoneyCash();
    }

    public void GameMoneyCash()
    {
        GameMoney.text = Cash.ToString();
    }
}
