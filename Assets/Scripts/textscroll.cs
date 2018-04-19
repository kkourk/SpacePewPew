using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textscroll : MonoBehaviour {

    AsyncOperation asyncOperation;
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync("Main Menu");
        asyncOperation.allowSceneActivation = false;
        Invoke("EndScene", 43f);
    }

    // Update is called once per frame
    void Update () {
        //Vector3 localtransform = gameObject.transform.InverseTransformPoint(transform.position);
        //localtransform += new Vector3(0,-1,0);
        this.gameObject.transform.position += new Vector3(0, 0.0055f, 0);
        if (Input.GetButtonDown("Cancel"))
        {
            asyncOperation.allowSceneActivation = true;
        }
    }
    void EndScene()
    {
        asyncOperation.allowSceneActivation = true;
    }
}
