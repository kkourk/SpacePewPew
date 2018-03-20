﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Shooting : MonoBehaviour {

    public int health = 100;
    public GameObject fireballPrefab;
    public Transform fireballSpawn;
    bool ready = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Right Trigger 2") > 0.5f)
        {
            Shoot();
        }

        //float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        //transform.Rotate(0, speed, 0);
    }


    public void Shoot()
    {
        if (ready)
        {
            float deadzone = 0.7f;
            Vector2 stickInput = new Vector2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2"));
            if (stickInput.magnitude > deadzone)
            {
                var angle = Mathf.Atan2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2")) * Mathf.Rad2Deg;
                var newAngle = Quaternion.Euler(0, 0, -angle + 90);
                GameObject fire = Instantiate(fireballPrefab, fireballSpawn.position, newAngle);
                fire.GetComponent<Rigidbody>().velocity = stickInput * 6;
                Destroy(fire, 2.0f);
            }




            Debug.Log("Fire");
            ready = false;
            Invoke("DelayHandler", 1);
        }


    }
    void DelayHandler()
    {
        ready = true;
    }
}