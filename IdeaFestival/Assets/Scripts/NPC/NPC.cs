
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    GameObject npcCanvas;
    [SerializeField] protected GameObject button;

    Image ilust;
    public Sprite ilustImage;

    protected TextMeshProUGUI chat;

    [Header("Chat Detail")]
    [SerializeField] protected string[] chatingDetail;
    protected string[] chooseDetail;
    [Header("Setting")]
    [SerializeField] protected GameObject player;
    [SerializeField] protected bool isChooseNPC;
    protected bool isEndChat = false;

    [SerializeField] TextMeshProUGUI[] choice;


    protected bool isOnChat = false;

    [SerializeField] protected int curPage = 0;
    [SerializeField] protected int choosePage = 99;

    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
        {
            if (Input.GetKeyDown(KeyCode.F) && !isOnChat && isChooseNPC && !isEndChat)
            {
                Debug.Log("대화 시작!");
                Init(chatingDetail.Length, chatingDetail, false);
                isOnChat = true;
            }

            if (((Input.GetKeyDown(KeyCode.Space) && isOnChat) || (Input.GetKeyDown(KeyCode.Return) && isOnChat)) )
                NextPage();
        }
    }

    protected void Init(int chatLength, string[] chatDetail, bool isChooseNPC)
    {
        ScriptSwitch(false);

        npcCanvas = player.transform.Find("NPC Canvas").gameObject;
        button = npcCanvas.transform.Find("ChatPane/Button").gameObject;

        ilust = npcCanvas.transform.Find("NPC Ilust").gameObject.GetComponent<Image>();
        ilust.sprite = ilustImage;

        chat = npcCanvas.transform.Find("ChatPane/ChatText").gameObject.GetComponent<TextMeshProUGUI>();

        chatingDetail = new string[chatLength];

        for (int i = 0; i < chatLength; i++)
            chatingDetail[i] = chatDetail[i];

        npcCanvas.SetActive(true);
        chat.text = chatingDetail[curPage];

        this.isChooseNPC = isChooseNPC;
    }

    protected void ChooseSetting(string[] choiceText, int count)
    {
        choosePage = count - 1;
        chooseDetail = choiceText;
    }



    protected void ScriptSwitch(bool b1)
    {
        player.GetComponent<PlayerController>().enabled = b1;
    }

    public void NextPage()
    {
        curPage++;
        if (curPage >= chatingDetail.Length)
        {
            isOnChat = false;
            curPage = 0;
            npcCanvas.SetActive(false);
            ScriptSwitch(true);
            isEndChat = true;
        }
        else
        {
            chat.text = chatingDetail[curPage];
        }

    }

    protected bool IsCheckDistance()
    {
        return 6 >= Vector2.Distance(transform.position, player.transform.position);
    }
}
