using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    AsyncOperation asyncOperation;
    void Start()
    {
       asyncOperation = SceneManager.LoadSceneAsync("Game");
       asyncOperation.allowSceneActivation = false;
    }
    void Update()
    {

    }
	public void LoadByIndex(int sceneIndex)
	{
        //SceneManager.LoadScene(sceneIndex);
       asyncOperation.allowSceneActivation = true;
    }
}
