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

    GameObject[] pauseObjects;


    public PlayerHealth playerHealth;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.OnDeath += GameOverActive;
            }
            PauseMenu.SetActive(false);
            gameOverPanel.SetActive(false);
        }
        else
        {
            //Do Nothing
        }
    }


    void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
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

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            //g.SetActive(true);
            PauseMenu.SetActive(true);

        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            //g.SetActive(false);
            PauseMenu.SetActive(false);
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Scene1");
    }
}