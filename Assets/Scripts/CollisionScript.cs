using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {
    public Slider playerslider;
    public GameManager gameManager;

    PlayersStats stats;

    private void Awake()
    {
        stats = GameObject.Find("GameManager").GetComponent<PlayersStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Projectile")
        {
            //this.gameObject.GetComponent<Player2Shooting>().health = this.gameObject.GetComponent<Player2Shooting>().health - other.gameObject.GetComponent<ProjectileScript>().ApplyDamage();
            //playerslider.value = this.gameObject.GetComponent<Player2Shooting>().health;
            //Debug.Log(this.gameObject.GetComponent<Player2Shooting>().health);
            //if (this.gameObject.GetComponent<Player2Shooting>().health <= 0)
            stats.health2 -= stats.damage1;
            playerslider.value = stats.health2;
            Debug.Log(stats.health2);
            if (stats.health2 <= 0)
            {
                Debug.Log("Ending round");
                gameManager.EndRound(1);
            }
        }
    }
}
