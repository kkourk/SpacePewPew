using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroScript : MonoBehaviour {
    public GameObject[] pictureArray;
    public AudioClip[] audiosounds;
    int winner;
    int pictureNumber=1;
    int clip = 0;
    // Use this for initialization
    AsyncOperation asyncOperation;
    AudioSource audioSource;
    bool Swappable = false;

    void Start () {
        winner = BackgroundMusic.PlayerWon;
        Invoke("PictureSwap",6f);
        asyncOperation = SceneManager.LoadSceneAsync("Main Menu");
        asyncOperation.allowSceneActivation = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audiosounds[clip];
        audioSource.Play();
        Swappable = true;
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
                Invoke("SwapAudio", 0.5f);
            }
        }
    }
    void PictureSwap()
    {
        foreach (GameObject picture in pictureArray)
        {
            picture.gameObject.SetActive(false);
        }
        pictureArray[pictureNumber].SetActive(true);
        Invoke("WinnerSwap",9f);
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
        Invoke("EndGame", 3f);
    }
    void EndGame()
    {
        //SceneManager.LoadScene("Main Menu");
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
}
