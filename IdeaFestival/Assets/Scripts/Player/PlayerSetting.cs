using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    public bool isPause;

    public GameObject pause;
    public GameObject setting;



    void Update()
    {
        if (!isPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = true;
                Time.timeScale = 0f;
                pause.SetActive(true);


            }
        }
        else if (isPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = false;
                Time.timeScale = 1f;
                pause.SetActive(false);
            }
        }
    }
}
