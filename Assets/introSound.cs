using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introSound : MonoBehaviour {
    public AudioClip[] introSoundClip;
    AudioSource audioSource;
    int Clip=0;
    bool Swappable = false;
	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = introSoundClip[0];
        audioSource.Play();
        Swappable = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Swappable == true)
        {
            if (!audioSource.isPlaying)
            {
                Swappable = false;
                Invoke("playSound", 1f);
            }
        }
        
	}
    void playSound()
    {
        Clip++;
        if (Clip>2)
        {
            return;
        }
        audioSource.clip = introSoundClip[Clip];
        audioSource.Play();
        Swappable = true;
    }

}
