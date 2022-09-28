using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static AudioClip playerHitsound, walksound, jumpsound, healsound, hitsound, shootsound,bossdiesound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitsound = Resources.Load<AudioClip>("playerHit");
        walksound = Resources.Load<AudioClip>("walk");
        jumpsound = Resources.Load<AudioClip>("jump");
        healsound = Resources.Load<AudioClip>("heal");
        hitsound = Resources.Load<AudioClip>("hit");
        shootsound = Resources.Load<AudioClip>("shoot");
        bossdiesound = Resources.Load<AudioClip>("bossdie");

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
            case "shoot":
                audioSrc.PlayOneShot(shootsound);
                break;
            case "bossdie":
                audioSrc.PlayOneShot(bossdiesound);
                break;
        }
    }
}
