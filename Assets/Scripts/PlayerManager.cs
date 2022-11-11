using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins = 0;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        gameOver = false;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        coinText.text = "Coins: " + numberOfCoins;

        if(SwipeManager.tap && !isGameStarted )
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
