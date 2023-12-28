using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Vector3 aftPlayerTrans;
    public bool useRemainMark;

    public Camera cam;
    public int cameraSize = 6;
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
    private void Start()
    {
        Set();
    }

    void Set()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
