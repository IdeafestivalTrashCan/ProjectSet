using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCheck : MonoBehaviour
{
    public GameObject[] panelF;
    public GameObject[] panelT;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelFalse()
    {
        panelF[0].SetActive(false);
        panelT[0].SetActive(true);
        GameManager.instance.PlayerWeapon[0] = true;
    }
}