using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Vector2 position;
    [SerializeField] int size;
    [SerializeField] bool useRemainMark;

    [SerializeField] GameObject player;
    [SerializeField] Slider slider;

    private void Awake()
    {
        player = GameObject.Find("GameManager/Player");
    }
    public void ResumeButton()
    {
        player.GetComponent<PlayerSetting>().isPause = false;
        Time.timeScale = 1f;
        player.GetComponent<PlayerSetting>().pause.SetActive(false);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    public void SettingButton() 
    {
        player.GetComponent<PlayerSetting>().setting.SetActive(true);
        if (!GameManager.instance.isKeyMode)
        {
            EventSystem.current.SetSelectedGameObject(null);
            slider.Select();
        }
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
