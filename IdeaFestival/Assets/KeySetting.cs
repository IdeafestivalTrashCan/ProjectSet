using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeySetting : MonoBehaviour
{
    public Slider slider;
    public void KeySetOn()
    {
        GameManager.instance.isKeyMode = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void KeySetOff()
    {
        GameManager.instance.isKeyMode = false;
        EventSystem.current.SetSelectedGameObject(null); 
        slider.Select();
    }
}
