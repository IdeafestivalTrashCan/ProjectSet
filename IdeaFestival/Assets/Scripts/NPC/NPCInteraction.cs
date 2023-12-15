using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Transform Player;
    public GameObject Chating;
    public GameObject F;
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
            F.SetActive(true);
            isScan = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        F.SetActive(false);
        Chating.SetActive(false);
    }

    private void Init()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
        F.SetActive(false);
        Chating.SetActive(false);
    }

    private void Scan()
    {
        if (isScan)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                F.SetActive(false);
                Chating.SetActive(true);
            }
        }
    }
}
