using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dotscript : MonoBehaviour {
    string[] characters = new string[] { "M", "e", "a", "n", "w","h" ,"i", "l", "e" };
    int charnmb=0;
    AsyncOperation asyncOperation;
    // Use this for initialization
    void Start () {
        asyncOperation = SceneManager.LoadSceneAsync("Outro");
        asyncOperation.allowSceneActivation = false;
        Invoke("dot", 3f);
        Invoke("Meanwhile", 0.5f);
        Invoke("EndGame",8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void dot()
    {

        GetComponent<Text>().text = GetComponent<Text>().text + " .";
        Invoke("dot", 1f);
    }
    void Meanwhile()
    {
        if (charnmb<characters.Length)
        {
            GetComponent<Text>().text = GetComponent<Text>().text + "" + characters[charnmb];
            charnmb++;
            Invoke("Meanwhile",0.2f);
        }
        
    }
    void EndGame()
    {
        asyncOperation.allowSceneActivation = true;
    }
}
