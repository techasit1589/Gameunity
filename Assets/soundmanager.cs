using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static AudioClip playerHitsound, walksound, jumpsound, healsound, hitsound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitsound = Resources.Load<AudioClip>("playerHit");
        walksound = Resources.Load<AudioClip>("walk");
        jumpsound = Resources.Load<AudioClip>("jump");
        healsound = Resources.Load<AudioClip>("heal");
        hitsound = Resources.Load<AudioClip>("hit");
        audioSrc =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "walk":
                audioSrc.PlayOneShot(walksound);
                audioSrc.loop = true;
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpsound);
                break ;
            case "heal":
                audioSrc.PlayOneShot(healsound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitsound);
                break;
        }
    }
}
