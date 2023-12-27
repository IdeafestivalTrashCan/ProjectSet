using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    bool isPause;

    [SerializeField] GameObject pause;
    [SerializeField] GameObject setting;

    void Update()
    {
        if (!isPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

            }
        }
        if (isPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                
            }
        }
    }
}
