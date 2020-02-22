using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip stayBark, followBark;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        stayBark = Resources.Load<AudioClip>("StayBarkLouder");
        followBark = Resources.Load<AudioClip>("FollowBarkLouder");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        switch (sound) {
            case "stayBark":
                audioSrc.PlayOneShot(stayBark);
                break;
            case "followBark":
                audioSrc.PlayOneShot(followBark);
                break;
        }
    }
}
