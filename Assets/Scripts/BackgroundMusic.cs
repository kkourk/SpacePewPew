using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    static int playerWon = 0;
    public static BackgroundMusic instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public static int PlayerWon
    {
        get { return playerWon; }
        set { playerWon = value; }
    }
}
