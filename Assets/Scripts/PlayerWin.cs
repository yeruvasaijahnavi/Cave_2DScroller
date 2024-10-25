using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public GameObject gameWinScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameWinScreen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameWin();
        }
    }

    

    void GameWin()
    {
        gameWinScreen.SetActive(true);
        Time.timeScale = 0f;  // Stop game
    }

}
