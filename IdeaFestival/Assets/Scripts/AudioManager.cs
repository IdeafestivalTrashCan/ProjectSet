using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgSound;
    public AudioClip[] bgList;

    public int mainVol;
    public int bgmVol;
    public int effectVol;

    public float realEffectVol;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("¿€µø");
        for (int i = 0; i < bgList.Length; i++)
        {
            if (arg0.name == bgList[i].name)
            {
                BgSoundPlay(bgList[i]);
            }
        }
        
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.volume = realEffectVol;
        audiosource.Play();

        Destroy(go, clip.length);
    }

    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = bgmVol * mainVol / 10000;
        bgSound.Play();
    }

    private void Update()
    {
        bgSound.volume = (float)(bgmVol * mainVol) / 10000;
        realEffectVol = (float)(effectVol * mainVol) / 10000;
    }
}
