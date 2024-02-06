using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCheck : MonoBehaviour
{
    GameObject origin;
    private GameObject ammoUI;
    GameObject Yangchoo;
    private void Start()
    {
        origin = GameObject.Find("GameManager/Player/Origin");
    }
    public void Check()
    {
        origin.SetActive(true);
        GameManager.instance.PlayerDamage = 35;
        Yangchoo = GameObject.Find("Yangchoo");
        Yangchoo.GetComponent<YangChoo>().NextPage();
        Yangchoo.GetComponent<YangChoo>().button.SetActive(false);
        GameManager.instance.PlayerWeapon[0] = true;
    }
}
