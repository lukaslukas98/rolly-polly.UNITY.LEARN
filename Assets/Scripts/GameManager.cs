using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    [SerializeField] private GameObject gameOverText;


    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)||(Input.GetKeyDown(KeyCode.Space) && isGameOver))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isGameOver)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void gameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
}
