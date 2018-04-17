using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//NEXT TIME

//Figure out how to control the stats of the 2 players


public enum PowerUps { DamageUp, HealthRegen , Shield};

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

    Slider playerOneSlider;
    Slider playerTwoSlider;

    PlayersStats stats;
    GameObject shieldObj1;
    GameObject shieldObj2;

    MeshRenderer crosshairOne;
    MeshRenderer crosshairTwo;

    MeshRenderer crosshairOne1;

    private void Awake()
    {
        stats = GameObject.Find("GameManager").GetComponent<PlayersStats>();
        shieldObj1 = GameObject.Find("ShieldObj1");
        shieldObj2 = GameObject.Find("ShieldObj2");

        playerOneSlider = GameObject.Find("PlayerOneHealth").GetComponent<Slider>();
        playerTwoSlider = GameObject.Find("PlayerTwoHealth").GetComponent<Slider>();

        crosshairOne = GameObject.Find("CrosshairOne").GetComponent<MeshRenderer>();
        crosshairTwo = GameObject.Find("CrosshairTwo").GetComponent<MeshRenderer>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            switch (type)
            {
                case PowerUps.DamageUp:
                    StartCoroutine(TempDmgBoost(other));
                    break;
                case PowerUps.HealthRegen:
                    HealthRegen(other);
                    break;
                case PowerUps.Shield:
                    Shield(other);
                    break;
                default:
                    break;
            }
        }
        else if (other.tag =="Projectile2" || other.tag =="Projectile")
        {
            Destroy(this.gameObject);
        }
    }

    void HealthRegen(Collider player)
    {
        Debug.Log("Health Regen Picked Up");

        //pickup animation
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //in-game effect

        if (player.CompareTag("Player1"))
        {
            stats.health1 += healthRegened;
            Debug.Log(stats.health1);
            playerOneSlider.value = stats.health1;
        }
        else 
        {
            stats.health2 += healthRegened;
            playerTwoSlider.value = stats.health2;
        }

    
        //remove powerup on pickup
        Destroy(gameObject);
    }


    IEnumerator TempDmgBoost(Collider player)
    {
        //pickup animation
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //in-game effect

        if (player.CompareTag("Player1"))
        {
            stats.damage1 = PlayersStats.defDamage * damageMultiplier;
            crosshairOne.material.color = Color.red;
        }
        else
        {
            stats.damage2 = PlayersStats.defDamage * damageMultiplier;
            crosshairTwo.material.color = Color.red;
        }

        

        #region HidePowerup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
       
        #endregion

        yield return new WaitForSeconds(duration);


        if (player.CompareTag("Player1"))
        {
            stats.damage1 = PlayersStats.defDamage;
            crosshairOne.material.color = Color.yellow;
        }
        else
        {
            stats.damage2 = PlayersStats.defDamage;
            crosshairOne.material.color = Color.yellow;
        }


        //remove powerup on pickup
        Destroy(gameObject);
    }

    void Shield(Collider player)
    {
        //pickup animation
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        
        //in-game effect

        if (player.CompareTag("Player1"))
        {
            stats.shield1 = true;
            shieldObj1.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            stats.shield2 = true;
            shieldObj2.GetComponent<Renderer>().enabled = true;
        }


        //remove powerup on pickup
        Destroy(gameObject);
    }

}
