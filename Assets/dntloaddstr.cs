using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dntloaddstr : MonoBehaviour {
    public static GameObject uiinstance = null;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (uiinstance == null)

            //if not, set instance to this
            uiinstance = this.gameObject;

        //If instance already exists and it's not this:
        else if (uiinstance != gameObject)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
