using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    int playerOneWins = 0;
    int playerTwoWins = 0;
    public Text textfield;
    public GameObject playerOne;
    public GameObject playerTwo;
    Transform playerOneTransform;
    Transform playerTwoTransform;
    public Slider playeroneslider;
    public Slider playertwoslider;
    public static GameManager instance = null;

	//Awake is always called before any Start functions
	void Awake()
	{
        playerOneTransform = playerOne.transform;
        playerTwoTransform = playerTwo.transform;
        //Debug.Log(playerTwoTransform.position);
        //Check if instance already exists
        if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);
	}
    void start()
    {
        
    }

    public void EndRound(int playernumber)
    {
        if (playernumber == 1)
        {
            playerOneWins++;
            //SceneManager.LoadScene("Game");
        }
        else if (playernumber == 2)
        {
            playerTwoWins++;
            //SceneManager.LoadScene("Game");
        }
        if (playerOneWins >=2)
        {
            //end game
        }
        if (playerTwoWins >= 2)
        {
            //end game
        }
        textfield.text = string.Format("{0} - {1}", playerOneWins, playerTwoWins);
        //reset game status (reloading scene won't work cause of the ui)
        playerTwo.transform.position = new Vector3(3, 0, 0);
        playerTwo.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerTwo.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        playerOne.transform.position = new Vector3(-3, 0, 0);
        playerOne.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerOne.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        playerTwo.transform.rotation = Quaternion.Euler(0,0,0);
        playerOne.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerTwo.GetComponent<Player2Shooting>().health = 100;
        playerOne.GetComponent<PlayerController>().health = 100;
        playeroneslider.value = 100;
        playertwoslider.value = 100;
    }

    void EndGame()
    {
        //go to main menu
        //reset scores
    }
}
