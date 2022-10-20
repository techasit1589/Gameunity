using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class musicBG : MonoBehaviour
{
    public static AudioClip  BGsound, bosssound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        BGsound = Resources.Load<AudioClip>("Jumpy");
        bosssound = Resources.Load<AudioClip>("Bossmusic");
        

        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = BGsound;
        audioSrc.Play();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Fboss":
                audioSrc.clip = bosssound;
                audioSrc.loop = true;
                audioSrc.Play();
                break;
            case "BG":
                audioSrc.clip = BGsound;
                audioSrc.loop = true;
                audioSrc.Play();
                break;
        }
    }
}
