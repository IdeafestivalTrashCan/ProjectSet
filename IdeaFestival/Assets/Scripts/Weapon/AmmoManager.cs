using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] Ammo;

    Image ammoImage;
    [SerializeField] int maxAmmo = 6;
    [SerializeField] int curAmmo = 6;
    [SerializeField] private AudioClip reloadClip;

    void Awake()
    {
        ammoImage = GetComponent<Image>();
        curAmmo = maxAmmo;
    }

    void Update()
    {
        switch (curAmmo)
        {
            case 0:
                ammoImage.sprite = Ammo[0];
                break;
            case 1:
                ammoImage.sprite = Ammo[1];
                break;
            case 2:
                ammoImage.sprite = Ammo[2];
                break;
            case 3:
                ammoImage.sprite = Ammo[3];
                break;
            case 4:
                ammoImage.sprite = Ammo[4];
                break;
            case 5:
                ammoImage.sprite = Ammo[5];
                break;
            case 6:
                ammoImage.sprite = Ammo[6];
                break;
            default:
                curAmmo = 6;
                break;

        }
    }


    public void Reload()
    {
        if (curAmmo != maxAmmo)
        {
            curAmmo = maxAmmo;
            AudioManager.instance.SFXPlay("Swing", reloadClip);
        }
    }

    public void Fire()
    {
        curAmmo--;
    }

    public bool isFireable()
    {
        return curAmmo != 0;
    }

}
