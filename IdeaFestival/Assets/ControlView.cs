using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlView : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] string[] textString;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isKeyMode) 
            text.text = textString[0];
        else
            text.text = textString[1];

    }
}
