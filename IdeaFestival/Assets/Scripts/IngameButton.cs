using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Vector2 position;
    [SerializeField] int size;
    [SerializeField] bool useRemainMark;

    [SerializeField] GameObject player;

    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    public void ResumeButton()
    {
        player.GetComponent<PlayerSetting>().isPause = false;
        Time.timeScale = 1f;
        player.GetComponent<PlayerSetting>().pause.SetActive(false);
    }
    public void SettingButton() 
    {
        player.GetComponent<PlayerSetting>().setting.SetActive(true);
    }
    public void GoBackVillageButton()
    {
        GameManager.instance.moveSceneName = sceneName;
        StartCoroutine(Set(sceneName, position, useRemainMark));
        SceneManager.LoadScene("Loading");
    }


    IEnumerator Set(string SceneName, Vector2 position, bool useRemainMark)
    {

        GameManager.instance.moveSceneName = SceneName;
        GameManager.instance.aftPlayerTrans = (Vector3)position;
        GameManager.instance.useRemainMark = useRemainMark;
        GameManager.instance.cameraSize = size;
        yield return null;
    }
}
