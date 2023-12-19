using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCheck : MonoBehaviour
{
    public GameObject Gun;
    GameObject Yangchoo;
    private void Start()
    {
        Gun = GameObject.Find("GameManager/Player/Gun").gameObject;
    }
    public void PanelFalse()
    {
        Gun.SetActive(true);
        Yangchoo = GameObject.Find("Yangchoo");
        Yangchoo.GetComponent<YangChoo>().NextPage();
        GameManager.instance.PlayerWeapon[1] = true;
    }
}
