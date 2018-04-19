using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int playerOneWins = 0;
    int playerTwoWins = 0;
    public Text textfield;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject powerupManager;
    Transform playerOneTransform;
    Transform playerTwoTransform;
    PlayersStats playerStats;
    public Slider playeroneslider;
    public Slider playertwoslider;
    public static GameManager instance = null;
    bool paused = false;
    public Text countdown;
    AsyncOperation asyncOperation;
    public GameObject shield1;
    public GameObject shield2;
    //Awake is always called before any Start functions
    void Awake()
    {
        playerOneTransform = playerOne.transform;
        playerTwoTransform = playerTwo.transform;
        paused = false;
        //Debug.Log(playerTwoTransform.position);
        //Check if instance already exists
        // if (instance == null)

        //if not, set instance to this
        //	instance = this;

        //If instance already exists and it's not this:
        //else if (instance != this)

        //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        //	Destroy (gameObject);    
        playerStats = this.GetComponent<PlayersStats>();
        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad (gameObject);

        Countdown();

    }
 
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync("Outro");
        asyncOperation.allowSceneActivation = false;
    }
    void Countdown()
    {
        //pause game
        Pause();
        //countdown
        StartCoroutine(Count());
        //unpause
        Invoke("Pause", 4);
    }

    IEnumerator Count()
    {

        countdown.text = "3";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.text = "GO!";
        yield return new WaitForSeconds(1);
        countdown.text = "";

    }

    void Pause()
    {
        //Debug.Log(paused);
        if (!paused)
        {
            foreach (MonoBehaviour scripts in playerOne.GetComponents<MonoBehaviour>())
            {
                scripts.enabled = false;
            }
            foreach (MonoBehaviour scripts in playerTwo.GetComponents<MonoBehaviour>())
            {
                scripts.enabled = false;
            }
            powerupManager.GetComponent<PowerupManager>().enabled = false;

            paused = true;
            //Debug.Log(paused);
        }
        else
        {
            //lock everything else
            foreach (MonoBehaviour scripts in playerOne.GetComponents<MonoBehaviour>())
            {
                scripts.enabled = true;
            }
            foreach (MonoBehaviour scripts in playerTwo.GetComponents<MonoBehaviour>())
            {
                scripts.enabled = true;
            }
            powerupManager.GetComponent<PowerupManager>().enabled = true;

            paused = false;
            //Debug.Log(paused);
        }

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

        Countdown();

        textfield.text = string.Format("{0} - {1}", playerOneWins, playerTwoWins);
        //reset game status (reloading scene won't work cause of the ui)
        playerTwo.transform.position = new Vector3(3, 0, 0);
        playerTwo.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerTwo.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        playerOne.transform.position = new Vector3(-3, 0, 0);
        playerOne.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerOne.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        playerTwo.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerOne.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerStats.health1 = 100;
        playerStats.health2 = 100;
        playerStats.shield1 = false;
        playerStats.shield2 = false;
        playerStats.damage1 = PlayersStats.defDamage;
        playerStats.damage2 = PlayersStats.defDamage;
        playeroneslider.value = 100;
        playertwoslider.value = 100;
        GameObject.Find("CrosshairOne").GetComponent<MeshRenderer>().material.color = Color.yellow;
        GameObject.Find("CrosshairTwo").GetComponent<MeshRenderer>().material.color = Color.yellow;
        shield1.GetComponent<Renderer>().enabled = false;
        shield2.GetComponent<Renderer>().enabled = false;
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("PowerUp");
        foreach (GameObject powerup in gameobjects)
        {
            Destroy(powerup);
        }
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject fire in projectiles)
        {
            Destroy(fire);
        }
        GameObject[] projectiles2 = GameObject.FindGameObjectsWithTag("Projectile2");
        foreach (GameObject fire in projectiles2)
        {
            Destroy(fire);
        }
        if (playerOneWins >= 3)
        {
            /*
                        playerTwoWins = 0;
                        playerOneWins = 0;
                        playerTwo.transform.position = new Vector3(3, 0, 0);
                        playerTwo.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        playerTwo.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        playerOne.transform.position = new Vector3(-3, 0, 0);
                        playerOne.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        playerOne.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        playerTwo.transform.rotation = Quaternion.Euler(0, 0, 0);
                        playerOne.transform.rotation = Quaternion.Euler(0, 0, 0);
                        playerStats.health1 = 100;
                        playerStats.health2 = 100;
                        playerStats.damage1 = PlayersStats.defDamage;
                        playerStats.damage2 = PlayersStats.defDamage;
                        playeroneslider.value = 100;
                        playertwoslider.value = 100;
                        SceneManager.LoadScene("Main Menu");
                        //end game*/
            BackgroundMusic.PlayerWon = 1;
            asyncOperation.allowSceneActivation = true;
        }
        if (playerTwoWins >= 3)
        {
            //end game
            /*
            playerTwoWins = 0;
            playerOneWins = 0;
            playerTwo.transform.position = new Vector3(3, 0, 0);
            playerTwo.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerTwo.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            playerOne.transform.position = new Vector3(-3, 0, 0);
            playerOne.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerOne.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            playerTwo.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerOne.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerStats.health1 = 100;
            playerStats.health2 = 100;
            playerStats.damage1 = PlayersStats.defDamage;
            playerStats.damage2 = PlayersStats.defDamage;
            playeroneslider.value = 100;
            playertwoslider.value = 100;
            SceneManager.LoadScene("Main Menu");*/
            BackgroundMusic.PlayerWon = 2;
            asyncOperation.allowSceneActivation = true;
        }
    }

    void EndGame()
    {
        //go to main menu
        //reset scores
    }
}
