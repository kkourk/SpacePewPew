using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2crossHairScript : MonoBehaviour {
 
    // Use this for initialization
    void Start () {
       
    }

    void FixedUpdate()
    {

       Vector3 vNewInput = new Vector3(Input.GetAxis("Rx2"), Input.GetAxis("Ry2"), 0.0f);
        Move(vNewInput);
    }
    void Move(Vector3 vNewInput)
    {

       
        if (vNewInput.sqrMagnitude < 0.3f)
        {
            return;
        }
        //this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 0.2f;
        // this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        // Apply the transform to the object  
        // var angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
        //  transform.rotation = Quaternion.Euler(0, 0, angle + 270);
        //  Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        //  Vector3 newVector = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);
        //  gameObject.transform.rotation = dir;
        // Smoothly tilts a transform towards a target rotation.
        Vector2 stickInput = new Vector2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2"));

        Quaternion target = Quaternion.Euler(stickInput.x, stickInput.y, 0);
        var angle = Mathf.Atan2(Input.GetAxis("Rx2"), Input.GetAxis("Ry2")) * Mathf.Rad2Deg;
        var newAngle = Quaternion.Euler(0, 0, -angle);
        // Dampen towards the target rotation
        Debug.Log(newAngle);
        transform.rotation = newAngle;

    }

    
}
