using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject pauseMenu;

    public PlayerHealth playerHealth;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.OnDeath += GameOverActive;
            }
            gameOverPanel.SetActive(false);
        }
        else
        {
            //Do Nothing
        }
    }

    void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDeath -= GameOverActive;
        }

    }

    void GameOverActive()
    {
        gameOverPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();


    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Scene1");
    }
}