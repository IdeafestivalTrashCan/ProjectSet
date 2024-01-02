using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] private float distance;
    [SerializeField] bool isOpen;

    [SerializeField] GameObject fMark;
    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
        {
            if (GameManager.instance.isKeyMode)
            {
                if (!isOpen)
                    fMark.SetActive(true);
                else fMark.SetActive(false);
                if (Input.GetKeyDown(KeyCode.F) && !isOpen)
                {
                    StartCoroutine(Open());
                }
            }
            else
            {
                if (!isOpen)
                    fMark.SetActive(true);
                else fMark.SetActive(false);
                if (Input.GetButtonDown("Interact") && !isOpen)
                {
                    StartCoroutine(Open());
                }
            }
        }
    }
    protected bool IsCheckDistance()
    {
        return distance >= Vector2.Distance(transform.position, player.transform.position);

    }

    IEnumerator Open()
    {
        isOpen = true;
        while (transform.position.y < 20)
        {
            yield return new WaitForSeconds(0.05f);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 0.2f), 0.5f);
        }
    }
}
