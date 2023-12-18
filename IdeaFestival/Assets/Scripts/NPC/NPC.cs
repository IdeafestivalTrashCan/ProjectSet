using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    GameObject npcCanvas;

    Image ilust;
    public Sprite ilustImage;

    TextMeshProUGUI chat;
    string[] chatingDetail;

    GameObject player;

    void Init(int chatLength, string[] chatDetail)
    {
        player = GameObject.Find("Player");
        ScriptSwitch(false);

        ilust = GameObject.Find("NPC Ilust").GetComponent<Image>();
        ilust.sprite = ilustImage;
        chat = GameObject.Find("ChatText").GetComponent<TextMeshProUGUI>();
        npcCanvas = GameObject.Find("NPC Canvas");
        chatingDetail = new string[chatLength];

        for (int i = 0; i < chatLength; i++)
            chatingDetail[i] = chatDetail[i];
    }

    void ScriptSwitch(bool b1)
    {
        player.GetComponent<PlayerController>().enabled = b1;
        player.GetComponent<PlayerController>().enabled = b1;
    }


    private void Update()
    {
        if (IsCheckDistance())
        {

        }
    }

    bool IsCheckDistance()
    {
        return 6 >= Vector2.Distance(transform.position, player.transform.position);
    }
}
