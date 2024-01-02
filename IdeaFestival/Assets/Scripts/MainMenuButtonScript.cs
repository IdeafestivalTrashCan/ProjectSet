using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonScript : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Vector2 position;
    [SerializeField] int size;
    [SerializeField] bool useRemainMark;
    [SerializeField] bool isDisablePlayer;

    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject gameOver;

    [SerializeField] Slider selectedSliderSet;
    [SerializeField] Button selectedMain;
    public void StartButton()
    {
        GameManager.instance.moveSceneName = sceneName;
        StartCoroutine(Set(sceneName, position, useRemainMark));
        SceneManager.LoadScene("Loading");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        GameManager.instance.moveSceneName = sceneName;
        GameManager.instance.PlayerWeapon[0] = false;
        GameManager.instance.PlayerWeapon[1] = false;
        GameManager.instance.player.transform.Find("Origin").gameObject.SetActive(false);
        gameOver.SetActive(false);
        GameManager.instance.isDisablePlayer = isDisablePlayer;
        GameManager.instance.player.GetComponent<PlayerUI>().curHp = GameManager.instance.player.GetComponent<PlayerUI>().maxHp;
        GameManager.instance.player.GetComponent<PlayerUI>().isDead = false;
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
        EventSystem.current.SetSelectedGameObject(null);
        if (!GameManager.instance.isKeyMode) { 
            selectedSliderSet.Select();
            }
    }
    public void SettingExitButton()
    {
        settingPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        if(!GameManager.instance.isKeyMode)
            selectedMain.Select();
    }
    IEnumerator Set(string SceneName, Vector2 position, bool useRemainMark)
    {

        GameManager.instance.moveSceneName = SceneName;
        GameManager.instance.aftPlayerTrans = (Vector3)position;
        GameManager.instance.useRemainMark = useRemainMark;
        GameManager.instance.isDisablePlayer = isDisablePlayer;
        GameManager.instance.cameraSize = size;
        yield return null;
    }
}
