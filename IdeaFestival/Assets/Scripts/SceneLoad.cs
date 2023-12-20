using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public TextMeshProUGUI loadText;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

   
    IEnumerator LoadScene()
    {
        Debug.Log("그래그래");
        GameManager.instance.player.SetActive(false);
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameManager.instance.moveSceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return new WaitForSeconds(0.01f);
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if (progressbar.value >= 1f)
            {
                loadText.text = "Press SpaceBar";
            }

            if (Input.GetKeyDown(KeyCode.Space) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {

                GameManager.instance.player.SetActive(true);
                GameManager.instance.player.transform.position = GameManager.instance.aftPlayerTrans;
                operation.allowSceneActivation = true;
            }
        }
    }
}
