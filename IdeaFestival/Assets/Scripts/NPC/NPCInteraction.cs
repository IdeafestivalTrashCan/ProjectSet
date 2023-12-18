using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Transform Player;
    public GameObject Chating;
    public Animator animator;

    private bool isScan;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Scan();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isScan = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Chating.SetActive(false);
    }

    private void Init()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }

    private void Scan()
    {
        if (isScan)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Chating.SetActive(true);
            }
        }
    }
}
