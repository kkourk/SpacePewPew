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
                if (other.tag != "border")
                {


                    int rand = Random.Range(0, 3);
                    if (rand == 0)
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion1");
                    }
                    else if (rand == 1)
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion2");
                    }
                    else if (rand == 2)
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion3");
                    }
                    else
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion4");
                    }
                }

                Destroy(this.gameObject);
            }
            else if (this.tag == "Projectile2" && other.tag != "Player2" )
            {
                if (other.tag != "border")
                {
                    int rand = Random.Range(0, 3);
                    if (rand == 0)
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion1");
                    }
                    else if (rand == 1)
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion2");
                    }
                    else if (rand == 2)
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion3");
                    }
                    else
                    {
                        GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("explosion4");
                    }
                }

                Destroy(this.gameObject);
            }
            
        }
       
    }
}
