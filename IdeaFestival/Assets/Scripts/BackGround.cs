using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x+speed, transform.position.y);
        if(transform.position.x >= 30)
            transform.position = new Vector3(-40, transform.position.y);
    }
}
