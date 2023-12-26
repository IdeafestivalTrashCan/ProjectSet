using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] Slider mainSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider soundSlider;
    void Start()
    {
        bgm.Play();
    }

    void Update()
    {
        bgm.volume = (float)(soundSlider.value * mainSlider.value) / 10000;
        GameManager.instance.mainVol = (int)mainSlider.value;
        GameManager.instance.bgmVol = (int)bgmSlider.value;
        GameManager.instance.soundVol = (int)soundSlider.value;
    }
}
