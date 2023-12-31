using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpBar;
    public bool isDead = false;
    public int maxHp = 200;
    [SerializeField] public int curHp = 200;
    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject remainCount;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI remainCountText;
    

    void Start()
    {
        gameOver = GameObject.Find("GameManager/Player/PlayerUI/GameOver");
        curHp = maxHp;
        hpBar.value = (float)curHp / maxHp;
    }

    void Update()
    {
        objects = GameObject.FindGameObjectsWithTag("Monster");
        remainCount.SetActive(GameManager.instance.useRemainMark);
        remainCountText.text = "   " + objects.Length;

        if (curHp > 200)
            curHp = 200;
        hpBar.value = (float)curHp / maxHp;
        DieCheck();
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ColorDelay", 0.1f);
    }

    protected void ColorDelay()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void DieCheck()
    {
        if (curHp <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("�׾�");
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
