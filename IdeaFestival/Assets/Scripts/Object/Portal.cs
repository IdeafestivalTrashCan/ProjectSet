using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject player;
    [Header("PortalSet")]
    [SerializeField] string sceneName;
    [SerializeField] Vector2 position;
    [SerializeField] int size;
    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
            if (Input.GetKeyDown(KeyCode.F))
                MoveMap(sceneName, position, size);
    }
    protected bool IsCheckDistance()
    {
        return 10 >= Vector2.Distance(transform.position, player.transform.position);
    }

    protected void MoveMap(string SceneName, Vector2 position, int size)
    {
        GameManager.instance.moveSceneName = SceneName;
        StartCoroutine(Set(sceneName));
        SceneManager.LoadScene("Loading");
    }

    IEnumerator Set(string SceneName)
    {
        yield return null;
        GameManager.instance.moveSceneName = SceneName;
        GameManager.instance.aftPlayerTrans = position;
        GameManager.instance.cameraSize = size;
    }
}
