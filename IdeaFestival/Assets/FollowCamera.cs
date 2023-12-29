using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    GameObject player;
    Canvas canvas;
    void Start()
    {
        GameManager.instance.cam = GetComponent<Camera>();
        player = GameObject.Find("GameManager/Player");

        canvas = GameObject.Find("GameManager/Player/PlayerUI").GetComponent<Canvas>();
        canvas.worldCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.8f, -10);
    }
}
