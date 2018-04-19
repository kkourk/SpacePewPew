using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backbtn : MonoBehaviour {
    public GameObject help;
    public GameObject main;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            help.SetActive(false);
            main.SetActive(true);
        }
    }
}
