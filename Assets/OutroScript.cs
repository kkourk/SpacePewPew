using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroScript : MonoBehaviour {
    public GameObject[] pictureArray;
    int winner;
    int pictureNumber=1;
    // Use this for initialization
    AsyncOperation asyncOperation;

        
    
    void Start () {
        winner = BackgroundMusic.PlayerWon;
        Invoke("PictureSwap",4f);
        asyncOperation = SceneManager.LoadSceneAsync("Game");
        asyncOperation.allowSceneActivation = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Main Menu");
        }
	}
    void PictureSwap()
    {
        foreach (GameObject picture in pictureArray)
        {
            picture.gameObject.SetActive(false);
        }
        pictureArray[pictureNumber].SetActive(true);
        Invoke("WinnerSwap",8f);
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
}
