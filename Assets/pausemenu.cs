using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject playerMenuUI;
    public GameObject Player;

	void Start()
	{
        pauseMenuUI.SetActive(false);
        playerMenuUI.SetActive(true);
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerMenuUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Player.GetComponent<Movement>().mouseMove = true;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        playerMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Player.GetComponent<Movement>().mouseMove = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}