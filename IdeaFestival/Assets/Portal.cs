using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
            if (Input.GetKeyDown(KeyCode.F))
                SceneManager.LoadScene("MainGame");
    }
    protected bool IsCheckDistance()
    {
        return 3 >= Vector2.Distance(transform.position, player.transform.position);
    }
}
