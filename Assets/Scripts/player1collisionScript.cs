using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1collisionScript : MonoBehaviour {
    public Slider playerslider;
    public GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Projectile2")
        {
            this.gameObject.GetComponent<PlayerController>().health = this.gameObject.GetComponent<PlayerController>().health - other.gameObject.GetComponent<ProjectileScript>().ApplyDamage();
            playerslider.value = this.gameObject.GetComponent<PlayerController>().health;
            Debug.Log(this.gameObject.GetComponent<PlayerController>().health);
            if (this.gameObject.GetComponent<PlayerController>().health <= 0)
            {
                gameManager.EndRound(2);
            }
        }
    }
}
