using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCheck : MonoBehaviour
{
    public GameObject[] panelF;
    public GameObject[] panelT;
    // Start is called before the first frame update
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
        GameManager.instance.PlayerWeapon[1] = true;
    }
}
