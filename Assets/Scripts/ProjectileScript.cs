using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public int dmg;


	public int ApplyDamage()
    {
        return dmg;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != this)
        {
            if (this.tag =="Projectile" && other.tag != "Player1")
            {
                Destroy(this.gameObject);
            }
            else if (this.tag == "Projectile2" && other.tag != "Player2" )
            {
                Destroy(this.gameObject);
            }
            
        }
       
    }
}
