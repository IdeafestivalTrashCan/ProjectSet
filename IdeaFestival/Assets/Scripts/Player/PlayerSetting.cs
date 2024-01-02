using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetting : MonoBehaviour
{
    public Button resume;
    public bool isPause;

    public GameObject pause;
    public GameObject setting;



    void Update()
    {
        if (GameManager.instance.isKeyMode)
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
                    GameManager.instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }
        else
        {
            if (!isPause)
            {
                if (Input.GetButtonDown("Menu"))
                {
                    isPause = true;
                    Time.timeScale = 0f;
                    pause.SetActive(true);
                    resume.Select();

                }
            }
            else if (isPause)
            {
                if (Input.GetButtonDown("Menu"))
                {
                    isPause = false;
                    Time.timeScale = 1f;
                    pause.SetActive(false);
                    GameManager.instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
            Debug.Log("¿Ã∞≈æﬂ");
        }
    }
}
