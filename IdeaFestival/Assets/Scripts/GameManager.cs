using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Vector3 aftPlayerTrans;

    [SerializeField] public Camera cam;
    public int cameraSize = 6;
    public Text GameMoney;
    public int Cash;
    public bool BossCheck = false;

    public string moveSceneName;

    public bool[] PlayerWeapon;

    public int PlayerDamage = 30;
    public Transform playerTrans;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        GameMoneyCash();
    }

    public void GameMoneyCash()
    {
        GameMoney.text = Cash.ToString();
    }
}
