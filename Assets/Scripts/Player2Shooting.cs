using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Shooting : MonoBehaviour {

    public int health = 100;
    public GameObject fireballPrefab;
    public Transform fireballSpawn;
    bool ready = true;
    public Slider shootCooldown;
    float shootAngle;
    Vector2 shootInput;
    float angle;
    Quaternion newAngle;
    float deadzone = 0.3f;
    Vector2 stickInput;

    // Use this for initialization
    void Start()
    {
        shootAngle= Mathf.Atan2(0, 1) * Mathf.Rad2Deg;
        shootInput = new Vector2(0, 1);
        stickInput = shootInput;
    }

    // Update is called once per frame
    void Update()
    {
        shootInput = new Vector2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2"));
        if (shootInput.magnitude > deadzone)
        {
            stickInput = shootInput;
            angle = Mathf.Atan2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2")) * Mathf.Rad2Deg;
            newAngle = Quaternion.Euler(0, 0, -angle + 90);
        }
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
            
            //Vector2 stickInput = new Vector2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2"));
           // Debug.Log(stickInput);

                GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("MartinPewPew1");
              

                //angle = Mathf.Atan2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2")) * Mathf.Rad2Deg;
                //newAngle = Quaternion.Euler(0, 0, -angle + 90);
                GameObject fire = Instantiate(fireballPrefab, fireballSpawn.position, newAngle);
                fire.GetComponent<Rigidbody>().velocity = stickInput.normalized * 6; 
                shootCooldown.value = 0;
                StartCoroutine(AnimateSliderOverTime(1));
                Destroy(fire, 4.0f);
            





            Debug.Log("Fire");
            ready = false;
            Invoke("DelayHandler", 1);
        }


    }
    void DelayHandler()
    {
        ready = true;
    }
    IEnumerator AnimateSliderOverTime(float seconds)
    {
        float animationTime = 0f;
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            shootCooldown.value = Mathf.Lerp(0f, 100f, lerpValue);
            yield return null;
        }
    }
}
