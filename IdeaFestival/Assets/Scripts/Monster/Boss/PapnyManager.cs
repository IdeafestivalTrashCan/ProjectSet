using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PapnyManager : MonoBehaviour
{
    [SerializeField] Slider papnyHPBar;
    [SerializeField] GameObject papnyHP;
    Papny papny;
    void Start()
    {
        papny = GameObject.Find("Papny").GetComponent<Papny>();
        papnyHP = GameObject.Find("GameManager/Player/PlayerUI/Boss");
        papnyHPBar = GameObject.Find("GameManager/Player/PlayerUI/Boss/BossHP").GetComponent<Slider>();
        papnyHP.SetActive(true);
    }

    void Update()
    {
        
        papnyHPBar.value = (float) papny.curHp / papny.maxHp;
        if (papny.curHp <= 0)
            papnyHP.SetActive(false);
    }
}
