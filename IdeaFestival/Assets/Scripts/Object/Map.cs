using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Transform playerTrans;
    Vector3 playerDefault;

    private void Start()
    {
        playerDefault = GameObject.Find("GameManager/Player").transform.position;
        playerTrans = GameObject.Find("GameManager/Player").transform;
    }
    void Update()
    {
            transform.position = new Vector3(transform.position.x , playerTrans.position.y, -1f);
    }

}
