using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpBar;

    public int maxHp = 200;
    [SerializeField] public int curHp = 200;
    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject remainCount;
    [SerializeField] TextMeshProUGUI remainCountText;
    

    void Start()
    {
        curHp = maxHp;
        hpBar.value = (float)curHp / maxHp;
    }

    void Update()
    {
        objects = GameObject.FindGameObjectsWithTag("Monster");
        remainCount.SetActive(GameManager.instance.useRemainMark);
        Debug.Log(GameManager.instance.useRemainMark);
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
        Invoke("ColorDelay", 0.25f);
    }

    protected void ColorDelay()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void DieCheck()
    {
        if (curHp <= 0)
            gameObject.SetActive(false);
    }
}
