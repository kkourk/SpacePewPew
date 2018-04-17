using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textscroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 localtransform = gameObject.transform.InverseTransformPoint(transform.position);
        //localtransform += new Vector3(0,-1,0);
        this.gameObject.transform.position += new Vector3(0, 0.007f, 0);
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
