using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    public GameObject[] FalseObjects;
    public void BossroomButton()
    {
        GameManager.instance.Sizemain = 10f;
        GameManager.instance.BossCheck = true;

        for (int i = 0; i < FalseObjects.Length; i++)
        {
            FalseObjects[i].SetActive(false);
        }
    }
}
