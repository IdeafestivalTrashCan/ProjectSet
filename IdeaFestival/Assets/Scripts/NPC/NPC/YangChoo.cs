
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YangChoo : NPC
{

    [Header("무기선택 버튼")]
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject gun;
    [SerializeField] private Button selectedButton;

    protected bool isEndChat = false;
    private bool isSelectOn = false;

    void Update()
    {
        if (IsCheckDistance())
        {
            if (GameManager.instance.isKeyMode)
            {
                if (Input.GetKeyDown(KeyCode.F) && !isOnChat && !isEndChat)
                {
                    Init(chatingDetail.Length, chatingDetail, true);
                    if (isChooseNPC)
                        ChooseSetting(15);
                    isOnChat = true;
                }

                if (((Input.GetKeyDown(KeyCode.Space) && isOnChat) || (Input.GetKeyDown(KeyCode.Return) && isOnChat)) && curPage != choosePage)
                    NextPage();
                if (curPage == choosePage)
                {
                    button.SetActive(true);
                }
            }
            else
            {
                if (Input.GetButtonDown("Interact") && isOnChat && curPage != choosePage)
                    NextPage();
                if (Input.GetButtonDown("Interact") && !isOnChat && !isEndChat && isChooseNPC)
                {
                    Init(chatingDetail.Length, chatingDetail, true);
                    if (isChooseNPC)
                        ChooseSetting(15);
                    isOnChat = true;
                }

                if (curPage == choosePage)
                {
                    button.SetActive(true);
                    if (!GameManager.instance.isKeyMode && !isSelectOn)
                    {
                        isSelectOn = true;
                        EventSystem.current.SetSelectedGameObject(null);
                        selectedButton.Select();
                    }
                }
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
        selectedButton = GameObject.Find("GameManager/Player/NPC Canvas/ChatPane/Button/SwordButton").GetComponent<Button>();

    }
}
