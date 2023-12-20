using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
            if (Input.GetKeyDown(KeyCode.F))
                Debug.Log("���ƶ� ǳ�� �Ϸη�");
    }
    protected bool IsCheckDistance()
    {
        return 3 >= Vector2.Distance(transform.position, player.transform.position);
    }
}
