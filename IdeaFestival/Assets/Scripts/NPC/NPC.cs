
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] protected GameObject npcCanvas;
    [SerializeField] public GameObject button;

    Image ilust;
    public Sprite ilustImage;

    protected TextMeshProUGUI chat;

    [Header("Chat Detail")]
    [SerializeField] protected string[] chatingDetail;
    [Header("Setting")]
    [SerializeField] protected GameObject player;
    [SerializeField] protected bool isChooseNPC;


    protected bool isOnChat = false;

    [SerializeField] protected int curPage = 0;
    [SerializeField] protected int choosePage = 99;
    [SerializeField] private int distance;


    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
        {
            Debug.Log("인식이 되긴 함;;");
            if (Input.GetKeyDown(KeyCode.F) && !isOnChat)
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
        Debug.Log("출력");
        ScriptSwitch(false);

        npcCanvas = GameObject.Find("GameManager/Player/NPC Canvas").gameObject;
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

    protected void ChooseSetting(int count)
    {
        choosePage = count - 1;
    }



    protected void ScriptSwitch(bool b1)
    {
        player.GetComponent<PlayerController>().enabled = b1;
    }

    public virtual void NextPage()
    {
        curPage++;
        if (curPage >= chatingDetail.Length)
        {
            isOnChat = false;
            curPage = 0;
            npcCanvas.SetActive(false);
            ScriptSwitch(true);
        }
        else
        {
            chat.text = chatingDetail[curPage];
        }

    }

    protected bool IsCheckDistance()
    {
        if (!player.GetComponent<PlayerSetting>().isPause)
        {
            return distance >= Vector2.Distance(transform.position, player.transform.position);
        }
        return false;
    }
}