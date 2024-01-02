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
    [SerializeField] bool useRemainMark;
    [SerializeField] bool isDisalbePlayer;
    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    private void Update()
    {
        if (IsCheckDistance())
            if (GameManager.instance.isKeyMode)
            {
                if (Input.GetKeyDown(KeyCode.F))
                    MoveMap(sceneName, position);
            }
            else
            {
                if (Input.GetButtonDown("Interact"))
                    MoveMap(sceneName, position);
            }
    }
    protected bool IsCheckDistance()
    {
        return 10 >= Vector2.Distance(transform.position, player.transform.position);
    }

    protected void MoveMap(string SceneName, Vector2 position)
    {
        GameManager.instance.moveSceneName = SceneName;
        StartCoroutine(Set(sceneName, position));
        SceneManager.LoadScene("Loading");
    }

    IEnumerator Set(string SceneName, Vector2 position)
    {
        GameManager.instance.moveSceneName = SceneName;
        GameManager.instance.aftPlayerTrans = (Vector3)position;
        GameManager.instance.cameraSize = size;
        GameManager.instance.isDisablePlayer = isDisalbePlayer;
        GameManager.instance.useRemainMark = useRemainMark;
        yield return null;
    }
}
