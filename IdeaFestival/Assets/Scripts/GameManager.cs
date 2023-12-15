using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text GameMoney;
    public int Cash;
    public float Sizemain = 5f;
    public bool BossCheck = false;

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
