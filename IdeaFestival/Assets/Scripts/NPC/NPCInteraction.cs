using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Transform Player;
    public GameObject Chating;
    public GameObject F;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Player.transform.position.x >= 4 &&
            Player.transform.position.x <= 10 &&
            Player.transform.position.y <= 2)
        {
            F.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                F.SetActive(false);
                Chating.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Chating.SetActive(false);
                }
            }
        }
        else
        {
            F.SetActive(false);
            Chating.SetActive(false);
        }
    }
}
