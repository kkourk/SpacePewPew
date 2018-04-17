using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {
    public Slider playerslider;
    public GameManager gameManager;

    PlayersStats stats;
    GameObject shieldObj2;

    private void Awake()
    {
        stats = GameObject.Find("GameManager").GetComponent<PlayersStats>();
        shieldObj2 = GameObject.Find("ShieldObj2");
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Projectile")
        {
            if (stats.shield2)
            {
                stats.shield2 = false;
                shieldObj2.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                stats.health2 -= stats.damage1;
                playerslider.value = stats.health2;
                //Debug.Log(stats.health2);
                if (stats.health2 <= 0)
                {
                    GameObject.Find("Main Camera").GetComponent<SoundScript>().playSound("Nyah1");
                    //Debug.Log("Ending round");
                    gameManager.EndRound(1);
                }
            }
        }
    }
}
