using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider mainSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider soundSlider;

    void Update()
    {
        AudioManager.instance.mainVol = (int)mainSlider.value;
        AudioManager.instance.bgmVol = (int)bgmSlider.value;
        AudioManager.instance.effectVol = (int)soundSlider.value;
    }

    private void OnEnable()
    {
        mainSlider.value = AudioManager.instance.mainVol;
        bgmSlider.value = AudioManager.instance.bgmVol;
        soundSlider.value = AudioManager.instance.effectVol;
    }
}
