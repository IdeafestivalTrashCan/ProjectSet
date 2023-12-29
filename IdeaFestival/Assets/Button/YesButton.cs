using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    public GameObject[] FalseObjects;
    private GameObject ammoUI;
    private void Awake()
    {
        ammoUI = GameObject.Find("GameManager/Player/PlayerUI/Ammo").GetComponent<GameObject>();
    }
    public void BossroomButton()
    {
        GameManager.instance.BossCheck = true;

        for (int i = 0; i < FalseObjects.Length; i++)
        {
            FalseObjects[i].SetActive(false);
        }
    }
}
