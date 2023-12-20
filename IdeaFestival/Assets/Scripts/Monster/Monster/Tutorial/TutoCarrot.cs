using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCarrot : Carrot
{
    [SerializeField] GameObject portal;
    private void Awake()
    {
        portal = GameObject.Find("PortalParent").transform.Find("Portal").gameObject;
    }
    private void Start()
    {
        Init(10, 2.5f, 20, 5, 5, false, 2);
    }
    private void OnDisable()
    {
        Debug.Log("Æ÷Å» »ý¼º ÀÌ¿¡¿¡¿¡¿¨");
        portal.SetActive(true);
    }
}
