using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] GameObject portal;

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Monster") == null)
        {
            portal.SetActive(true);
        }
    }
}
