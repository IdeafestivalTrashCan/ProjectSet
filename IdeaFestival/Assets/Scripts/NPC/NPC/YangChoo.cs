using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YangChoo : NPC
{
    [SerializeField] string[] choose;

    [Header("무기선택 버튼")]
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject gun;

    static protected bool isEndChat = false;

    void Update()
    {
        if (IsCheckDistance())
        {
            if (Input.GetKeyDown(KeyCode.F) && !isOnChat && !isEndChat)
            {
                Init(chatingDetail.Length, chatingDetail, true); 
                ChooseSetting(7);
                isOnChat = true;
            }

            if (((Input.GetKeyDown(KeyCode.Space) && isOnChat) || (Input.GetKeyDown(KeyCode.Return) && isOnChat)) && curPage != choosePage)
                NextPage();
            if(curPage  == choosePage)
            {
                button.SetActive(true);
            }
        }

    }

    public override void NextPage()
    {
        curPage++;
        if (curPage >= chatingDetail.Length)
        {
            isOnChat = false;
            curPage = 0;
            isEndChat = true;
            npcCanvas.SetActive(false);
            ScriptSwitch(true);
            button.SetActive(false);
        }
        else
        {
            chat.text = chatingDetail[curPage];
        }

    }

    private void Start()
    {
        sword = GameObject.Find("GameManager/Player/Origin").gameObject;
        gun = GameObject.Find("GameManager/Player/Gun").gameObject;


    }
}
