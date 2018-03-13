using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour {
    Vector2 angle;
    bool ready = true;
    float cooldownMs = 1;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 vNewInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
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
            this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 0.2f;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            // Apply the transform to the object  
            var angle = Mathf.Atan2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle+90);
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            Vector3 newVector = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);
            this.GetComponent<Rigidbody>().AddForce(dir * 2,ForceMode.Impulse);
            ready = false;
            Invoke("DelayHandler",cooldownMs);
        }
        return;
    }
    void DelayHandler()
    {
        ready = true;
    }
}
