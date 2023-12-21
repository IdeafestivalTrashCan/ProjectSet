using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject[] objects;

    private void Update()
    {
        objects = GameObject.FindGameObjectsWithTag("Monster");
        if (objects.Length == 0)
        {
            portal.SetActive(true);
        }
    }
}
