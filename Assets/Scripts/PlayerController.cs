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

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
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

            float deadzone = 0.7f;
            Vector2 stickInput = new Vector2(Input.GetAxis("Rx"), Input.GetAxis("Ry"));
            if (stickInput.magnitude > deadzone)
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
                    

                var angle = Mathf.Atan2(Input.GetAxis("Rx"), Input.GetAxis("Ry")) * Mathf.Rad2Deg;
                var newAngle = Quaternion.Euler(0, 0, -angle + 90);
                GameObject fire = Instantiate(fireballPrefab, fireballSpawn.position, newAngle);
                fire.GetComponent<Rigidbody>().velocity = stickInput * 6;
                shootCooldown.value = 0;
                StartCoroutine(AnimateSliderOverTime(1));
                Destroy(fire, 4.0f);
            }




            //Debug.Log("Fire");
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
