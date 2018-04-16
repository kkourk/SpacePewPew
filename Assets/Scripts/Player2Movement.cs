using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : MonoBehaviour {

    Vector2 angle;
    bool ready = true;
    float cooldownMs = 1;
    public Slider moveCooldownSlider;
    public Animator soldierAnim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vNewInput = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0.0f);
        Move(vNewInput);
    }
    void Move(Vector3 vNewInput)
    {
        //    Debug.Log("moving");

        if (vNewInput.sqrMagnitude < 0.3f)
        {
            return;
        }
        if (ready)
        {
            //this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 0.2f;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            // Apply the transform to the object  
            var angle = Mathf.Atan2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2")) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 270);    // most likely needs to be changed as soon as we get a new sprites
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            //Vector3 newVector = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);
            this.GetComponent<Rigidbody>().AddForce(dir * 2, ForceMode.Impulse);
            ready = false;

            moveCooldownSlider.value = 0;
            StartCoroutine(AnimateSliderOverTime(1));
            soldierAnim.SetBool("Animating", true);
            Invoke("DelayHandler", cooldownMs);
            Invoke("StopAnimation", 0.5f);
        }
        return;
    }
    void DelayHandler()
    {
        ready = true;
    }
    void StopAnimation()
    {
        soldierAnim.SetBool("Animating", false);
    }
    IEnumerator AnimateSliderOverTime(float seconds)
    {
        float animationTime = 0f;
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            moveCooldownSlider.value = Mathf.Lerp(0f, 100f, lerpValue);
            yield return null;
        }
    }
}
