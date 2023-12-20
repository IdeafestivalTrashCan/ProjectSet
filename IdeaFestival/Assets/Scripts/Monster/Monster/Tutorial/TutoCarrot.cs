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
    private void OnDisable()
    {
        Debug.Log("Æ÷Å» »ý¼º ÀÌ¿¡¿¡¿¡¿¨");
        portal.SetActive(true);
    }
}
