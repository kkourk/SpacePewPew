using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

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
    void Start () {

        shootAngle = Mathf.Atan2(0, 1) * Mathf.Rad2Deg;
        shootInput = new Vector2(0, 1);
        stickInput = shootInput;
    }
	
	// Update is called once per frame
	void Update () {
        shootInput = new Vector2(Input.GetAxis("Rx"), Input.GetAxis("Ry"));
        if (shootInput.magnitude > deadzone)
        {
            stickInput = shootInput;
            angle = Mathf.Atan2(Input.GetAxis("Rx"), Input.GetAxis("Ry")) * Mathf.Rad2Deg;
            newAngle = Quaternion.Euler(0, 0, -angle + 90);
        }
        if (Input.GetAxis("Right Trigger") >0.5f)
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

           
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("PewPew1");
                }
                else if(rand == 1)
                {
                    GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("PewPew2");
                }
                else
                {
                    GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("PewPew4");
                }
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
        shootCooldown.value = 100;
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
