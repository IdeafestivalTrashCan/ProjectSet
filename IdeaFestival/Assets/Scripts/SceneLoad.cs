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
    AsyncOperation operation;

    void Start()
    {
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        Debug.Log("그래그래");

        yield return null;
        operation = SceneManager.LoadSceneAsync(GameManager.instance.moveSceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return new WaitForSeconds(0.001f);
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
                loadText.text = "Loading!";
            }

            if (progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                StartCoroutine(Load());
            }
        }
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.instance.player.transform.position = GameManager.instance.aftPlayerTrans;
        GameManager.instance.player.GetComponent<PlayerController>().isDash = true;
        operation.allowSceneActivation = true;
        GameManager.instance.player.SetActive(true);

    }
}
