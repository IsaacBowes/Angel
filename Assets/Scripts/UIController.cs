using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject PauseMenu;

    private bool paused;
    private int state = 1;




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


    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
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

    public void togglePause()
    {
        // not the optimal way but for the sake of readability
        if (PauseMenu.GetComponentInChildren<Canvas>().enabled)
        {
            PauseMenu.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            PauseMenu.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }

        Debug.Log("TimeScale: " + Time.timeScale);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Scene1");
    }
}