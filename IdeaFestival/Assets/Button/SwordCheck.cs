using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCheck : MonoBehaviour
{
    GameObject origin;
    GameObject Yangchoo;
    private void Start()
    {
        origin = GameObject.Find("GameManager/Player/Origin").gameObject;
    }
    public void Check()
    {
        origin.SetActive(true);
        Yangchoo = GameObject.Find("Yangchoo");
        Yangchoo.GetComponent<YangChoo>().NextPage();
        GameManager.instance.PlayerWeapon[0] = true;
    }
}
