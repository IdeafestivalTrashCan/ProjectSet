using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    public GameObject[] FalseObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossroomButton()
    {
        SceneManager.LoadScene("Boss_Level1");
        GameManager.instance.Sizemain = 10f;
        GameManager.instance.BossCheck = true;

        for (int i = 0; i < FalseObjects.Length; i++)
        {
            FalseObjects[i].SetActive(false);
        }
    }
}
