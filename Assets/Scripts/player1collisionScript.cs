using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1collisionScript : MonoBehaviour {
    public Slider playerslider;
    public GameManager gameManager;

    PlayersStats stats;

    private void Awake()
    {
        stats = GameObject.Find("GameManager").GetComponent<PlayersStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Projectile2")
        {
            //this.gameObject.GetComponent<PlayerController>().health = this.gameObject.GetComponent<PlayerController>().health - other.gameObject.GetComponent<ProjectileScript>().ApplyDamage();
            //playerslider.value = this.gameObject.GetComponent<PlayerController>().health;
            stats.health1 -= stats.damage2;
            playerslider.value = stats.health1;
            Debug.Log(stats.health1);
            if (stats.health1 <= 0)
            {
                Debug.Log("Ending round");
                gameManager.EndRound(2);
            }
        }
    }
}
