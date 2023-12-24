using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] private float distance;
    [SerializeField] bool isOpen;
    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
        {
            Debug.Log("ÀÎ½ÄÀÌ µÇ±ä ÇÔ;;");
            if (Input.GetKeyDown(KeyCode.F) && !isOpen)
            {
                Debug.Log("µþ±ï");
                StartCoroutine(Open());
            }
        }
    }
    protected bool IsCheckDistance()
    {
        Debug.Log(Vector2.Distance(transform.position, player.transform.position));
        return distance >= Vector2.Distance(transform.position, player.transform.position);
        
    }

    IEnumerator Open()
    {
        isOpen = true;
        while (transform.position.y < 20)
        {
            yield return new WaitForSeconds(0.05f);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x ,transform.position.y + 0.2f), 0.5f);
        }
    }
}
