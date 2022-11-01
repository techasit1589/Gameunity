using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumTest : MonoBehaviour
{
    public int scene;

    public Slider volumSlider;

    public static AudioClip BGsound,bosssound,ghostly,medieval,medieval2;

    private AudioSource audioSrc;

    public GameObject ObjectMusic;

    public GameObject Objectest;
    //public AudioSource audioSource;

    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        //โหลดเสียง
        BGsound = Resources.Load<AudioClip>("Jumpy");
        bosssound = Resources.Load<AudioClip>("Bossmusic");
        ghostly = Resources.Load<AudioClip>("Ghostly");
        medieval = Resources.Load<AudioClip>("Medieval");
        medieval2 = Resources.Load<AudioClip>("Medievall");

        volumSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        ObjectMusic = GameObject.FindGameObjectWithTag("music");
        audioSrc= ObjectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        audioSrc.volume = musicVolume;
        volumSlider.value = musicVolume;
        
        
        //audioSrc = GetComponent<AudioSource>();
        //audioSrc.clip = BGsound;
        //audioSrc.Play();
        if (scene == 0)
        {
            audioSrc.clip = BGsound;
            audioSrc.loop = true;
            audioSrc.Play();
        }
        else if (scene == 1)
        {
            audioSrc.clip = ghostly;
            audioSrc.loop = true;
            audioSrc.Play();
        }
        else if (scene == 2)
        {
            audioSrc.clip = medieval;
            audioSrc.loop = true;
            audioSrc.Play();
        }
        else if (scene == 3)
        {
            audioSrc.clip = medieval2;
            audioSrc.loop = true;
            audioSrc.Play();
            Objectest.SetActive(false);
        }
        else if (scene == 4)
        {
            audioSrc.clip = BGsound;
            audioSrc.loop = true;
            audioSrc.Play();
            Objectest.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (scene == 5)
        {
            audioSrc.clip = bosssound;
            audioSrc.loop = true;
            audioSrc.Play();
            scene = 10;
        }
        if (scene == 11)
        {
            audioSrc.clip = BGsound;
            audioSrc.loop = true;
            audioSrc.Play();
            scene = 10;
        }
        PlayerPrefs.SetFloat("volume", musicVolume);
        audioSrc.volume = musicVolume;
        
        
    }
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
