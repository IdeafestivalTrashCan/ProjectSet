using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCheck : MonoBehaviour
{
    public GameObject Gun;
    GameObject Yangchoo;
    private GameObject ammoUI;

    private void Start()
    {
        Gun = GameObject.Find("GameManager/Player/Gun").gameObject;
        ammoUI = GameObject.Find("GameManager/Player/PlayerUI/Ammo");
    }
    public void PanelFalse()
    {
        ammoUI.SetActive(true);
        GameManager.instance.PlayerDamage = 450;
        Gun.SetActive(true);
        Yangchoo = GameObject.Find("Yangchoo");
        Yangchoo.GetComponent<YangChoo>().NextPage();
        Yangchoo.GetComponent<YangChoo>().button.SetActive(false);
        GameManager.instance.PlayerWeapon[1] = true;
    }
}
