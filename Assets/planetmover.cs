using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetmover : MonoBehaviour {
    public Vector3 movespeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += movespeed * Time.deltaTime;
	}
}
