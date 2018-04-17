using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1collisionScript : MonoBehaviour {
    public Slider playerslider;
    public GameManager gameManager;

    
    PlayersStats stats;
    GameObject shieldObj1;

    private void Awake()
    {
        stats = GameObject.Find("GameManager").GetComponent<PlayersStats>();
        shieldObj1 = GameObject.Find("ShieldObj1");
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Projectile2")
        {
            if (stats.shield1)
            {
                stats.shield1 = false;
                shieldObj1.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                stats.health1 -= stats.damage2;
                playerslider.value = stats.health1;
                //Debug.Log(stats.health1);
                if (stats.health1 <= 0)
                {
                    //Debug.Log("Ending round");
                    gameManager.EndRound(2);
                }
            }
            
        }
    }
}
