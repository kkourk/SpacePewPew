using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    int playerOneHealth;
    int playerTwoHealth;
    int playerOneWinCounter;
    int playerTwoWinCounter;
    int basicAttackDmg = 5;
    int powerUpDmg = 10;
    bool win;


	// Use this for initialization
	void Start () {
        playerOneHealth = 100;
        playerTwoHealth = 100;
        playerOneWinCounter = 0;
        playerTwoWinCounter = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        Health();
        WinCount();
		
	}

    void Health()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerOneHealth = playerOneHealth - basicAttackDmg;
            Debug.Log("Player 1 health: " + playerOneHealth);
        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            playerTwoHealth = playerTwoHealth - basicAttackDmg;
            Debug.Log("Player 2 health: " + playerTwoHealth);
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            playerOneHealth = playerOneHealth - powerUpDmg;
            Debug.Log("Player 1 health: " + playerOneHealth);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerTwoHealth = playerTwoHealth - powerUpDmg;
            Debug.Log("Player 2 health: " + playerTwoHealth);
        }


    }

    void WinCount()
    {

        if (playerTwoHealth <= 0)
        {
            playerOneWinCounter++;
            Debug.Log("Player 1 wins " + playerOneWinCounter + " round");
            win = true;
        }

        else if (playerOneHealth <= 0)
        {
            playerTwoWinCounter++;
            Debug.Log("Player 2 wins " + playerTwoWinCounter + " round");
            win = true;
        }

        if(win)
        {
            playerOneHealth = 100;
            playerTwoHealth = 100;
            win = false;
            
        }


        if (playerOneWinCounter == 2)
        {
            Debug.Log("Player 1 wins!");
        }

        else if (playerTwoWinCounter == 2)
        {
            Debug.Log("Player 2 wins!");
        }
    }
}
