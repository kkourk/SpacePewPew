using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {
    public AudioClip[] audioClips;
    // Use this for initialization
    AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playSound(string soundClip)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip != null)
            {
                if (clip.name == soundClip)
                {
                    //audioSource.clip = clip;
                    audioSource.PlayOneShot(clip);

                }
            }
            
        }
    }
}
