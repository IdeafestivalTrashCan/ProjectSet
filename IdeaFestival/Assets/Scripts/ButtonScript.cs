using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Vector2 position;
    [SerializeField] int size;
    [SerializeField] bool useRemainMark;

    [SerializeField] GameObject settingPanel;

    public void StartButton()
    {
        GameManager.instance.moveSceneName = sceneName;
        StartCoroutine(Set(sceneName, position, useRemainMark));
        SceneManager.LoadScene("Loading");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void SettingOpenButton()
    {
        settingPanel.SetActive(true);
    }
    public void SettingExitButton()
    {
        settingPanel.SetActive(false);
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
