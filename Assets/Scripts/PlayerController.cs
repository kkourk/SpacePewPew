using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject fireballPrefab;
    public Transform fireballSpawn;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        //float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        //transform.Rotate(0, speed, 0);
    }


    public void Shoot()
    {
        

        float deadzone = 0.7f;
        Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (stickInput.magnitude > deadzone)     
        {
            GameObject fire = Instantiate(fireballPrefab, fireballSpawn.position, fireballSpawn.rotation);
            fire.GetComponent<Rigidbody2D>().velocity = stickInput * 6;
            Destroy(fire, 2.0f);
        }


        

        Debug.Log("Fire");
    }
}
