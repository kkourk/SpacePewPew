﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {
    public Slider playerslider;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Projectile")
        {
            this.gameObject.GetComponent<Player2Shooting>().health = this.gameObject.GetComponent<Player2Shooting>().health - other.gameObject.GetComponent<ProjectileScript>().ApplyDamage();
            playerslider.value = this.gameObject.GetComponent<Player2Shooting>().health;
            Debug.Log(this.gameObject.GetComponent<Player2Shooting>().health);
        }
    }
}