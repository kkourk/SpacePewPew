using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroScript : MonoBehaviour {
    public GameObject[] pictureArray;
    public AudioClip[] audiosounds;
    public GameObject bubble1;
    public GameObject bubble2;
    int winner;
    int pictureNumber=1;
    int clip = 0;
    // Use this for initialization
    AsyncOperation asyncOperation;
    AudioSource audioSource;
    AudioSource music;
    bool Swappable = false;

    void Start () {
        winner = BackgroundMusic.PlayerWon;
        GetComponent<AudioSource>().volume = 0.5f;
        asyncOperation = SceneManager.LoadSceneAsync("Main Menu");
        asyncOperation.allowSceneActivation = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audiosounds[clip];
        Invoke("Bubble1", 1f);
        Invoke("PictureSwap", 6f);
        //audioSource.Play();
       // Swappable = true;
        music = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        music.mute=true;
       
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (Swappable == true)
        {
            if (!audioSource.isPlaying)
            {
                Swappable = false;
                Invoke("SwapAudio", 1f);
            }
        }
    }
    void PictureSwap()
    {
        GetComponent<AudioSource>().volume = 1;
        foreach (GameObject picture in pictureArray)
        {
            picture.gameObject.SetActive(false);
        }
        pictureArray[pictureNumber].SetActive(true);
        Invoke("WinnerSwap",9.5f);
    }
    void WinnerSwap()
    {
        foreach (GameObject picture in pictureArray)
        {
            picture.gameObject.SetActive(false);
        }
        if (winner == 1)
        {
            pictureArray[2].SetActive(true);
        }
        else
        {
            pictureArray[3].SetActive(true);
        }
        Invoke("EndGame", 6f);
    }
    void EndGame()
    {
        //SceneManager.LoadScene("Main Menu");
        music.mute = false;
        asyncOperation.allowSceneActivation = true;
    }
    void SwapAudio()
    {
        clip++;
        audioSource.clip = audiosounds[clip];
        audioSource.Play();
        if (clip ==1)
        {

            Swappable = true;
        }
    }
    void Bubble1()
    {
        audioSource.Play();
        bubble1.SetActive(true);
        Invoke("Bubble2",2.5f);
        Swappable = true;
    }
    void Bubble2()
    {
        bubble2.SetActive(true);
       
    }
}
