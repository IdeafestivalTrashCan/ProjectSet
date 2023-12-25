using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField]  AudioSource bgm;
    [SerializeField] Slider mainSlider;
    [SerializeField] Slider soundSlider;
    void Start()
    {
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        bgm.volume = soundSlider.value * mainSlider.value;
    }
}
