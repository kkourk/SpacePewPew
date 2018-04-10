using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NEXT TIME

//Figure out how to control the stats of the 2 players


public enum PowerUps { DamageUp, HealthRegen };

public class Powerup : MonoBehaviour
{

    public PowerUps type;
    //effect
    public GameObject pickupEffect;
    //hp
    public float healthRegened = 10f;
    //damage
    public float damageMultiplier = 2f;
    public float duration = 4f;// duration of boost in seconds


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            switch (type)
            {
                case PowerUps.DamageUp:
                    StartCoroutine(TempDmgBoost(other));
                    break;
                case PowerUps.HealthRegen:
                    HealthRegen(other);
                    break;
                default:
                    break;
            }
        }
        else if (other.CompareTag("Player2"))
        {
            switch (type)
            {
                case PowerUps.DamageUp:
                    StartCoroutine(TempDmgBoost(other));
                    break;
                case PowerUps.HealthRegen:
                    HealthRegen(other);
                    break;
                default:
                    break;
            }
        }
    }

    void HealthRegen(Collider player)
    {
        //pickup animation
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //in-game effect
        PlayersStats stats = player.GetComponent<PlayersStats>();
        if (player.CompareTag("Player1"))
        {
            stats.health1 += healthRegened;
        }
        else 
        {
            stats.health2 += healthRegened;
        }

    
        //remove powerup on pickup
        Destroy(gameObject);
    }


    IEnumerator TempDmgBoost(Collider player)
    {
        //pickup animation
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //in-game effect
        PlayersStats stats = player.GetComponent<PlayersStats>();

        if (player.CompareTag("Player1"))
        {
            stats.damage1 = PlayersStats.defDamage * damageMultiplier;
        }
        else
        {
            stats.damage2 = PlayersStats.defDamage * damageMultiplier;
        }

        

        #region HidePowerup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        #endregion

        yield return new WaitForSeconds(duration);


        if (player.CompareTag("Player1"))
        {
            stats.damage1 = PlayersStats.defDamage;
        }
        else
        {
            stats.damage2 = PlayersStats.defDamage;
        }


        //remove powerup on pickup
        Destroy(gameObject);
    }
}
